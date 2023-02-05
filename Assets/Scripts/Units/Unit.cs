using Coherence.Toolkit;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace WorldTree
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private SOUnit _stats;
        public SOUnit stats => _stats;
        private float _nextAttackTime;
        private float _currentHealth;
        public float currentHealth => _currentHealth;
        private UnitNavMode _navMode;
        public UnitNavMode navMode => _navMode;

        private static Dictionary<Faction, Dictionary<Unit, Vector3>> _unitPositions;

        private Unit _target;
        public Unit target => _target;
        [HideInInspector]
        public UnityEvent<Unit> OnCreate;
        [HideInInspector]
        public UnityEvent<Unit> OnSetTarget;
        [HideInInspector]
        public UnityEvent<Unit> OnDeath;
        [HideInInspector]
        public UnityEvent<Unit> OnAttack;

        private NavMeshAgent _meshAgent;
        public NavMeshAgent meshAgent => _meshAgent;

        private void Start()
        {
            _nextAttackTime = Time.time;
            _currentHealth = _stats.health;
            _navMode = UnitNavMode.Selection;

            _meshAgent = GetComponent<NavMeshAgent>();

            _unitPositions ??= new();
            if (!_unitPositions.ContainsKey(_stats.faction)) 
                _unitPositions[_stats.faction] = new();

            _unitPositions[_stats.faction].Add(this, transform.position);
            OnCreate.Invoke(this);
        }

        private void Update()
        {
            SetSpeed();
            if(_target != null)
            {
                _navMode = UnitNavMode.Target;
                Vector3 dist = transform.position - _target.transform.position;
                if (dist.sqrMagnitude <= stats.attackRadius * stats.attackRadius)
                {
                    // move
                    if (dist.sqrMagnitude >= stats.attackRadius * stats.attackRadius * 0.67f * 0.67f)
                    {
                        _meshAgent.speed *= 0.5f;
                    }
                    else
                    {
                        _meshAgent.speed = 0;
                        _meshAgent.SetDestination(transform.position);
                    }

                    // attack
                    if(_nextAttackTime <= Time.time)
                    {
                        _nextAttackTime = Time.time + 1 / _stats.attackSpeed;

                        OnAttack.Invoke(this);

                        _target.Damage(_stats.attackPower);
                    }
                }
            }
            else
            {
                _navMode = UnitNavMode.Selection;
            }
            GetTarget();
        }

        private void LateUpdate()
        {
            _unitPositions[_stats.faction][this] = transform.position;
        }

        private void SetSpeed()
        {
            _meshAgent.speed = _stats.moveSpeed * UnitMovement.Instance.terrain[transform.position].moveMultiplier; 
        }

        private void GetTarget()
        {
            if (_target != null) return;

            foreach (var dict in _unitPositions)
            {
                if (dict.Key == _stats.faction) continue;

                foreach (var unit in dict.Value)
                {
                    if ((unit.Value - transform.position).magnitude < _stats.agressionRadius)
                    {
                        _target = unit.Key;
                        _target.OnDeath.AddListener(RemoveTarget);
                        OnSetTarget.Invoke(this);
                        return;
                    }
                }
            }
        }

        private void RemoveTarget(Unit unit)
        {
            _target = null;
        }

        public void Damage(float damage)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
                Die();
        }

        public void Heal(float health)
        {
            _currentHealth += health;
        }

        public void Die()
        {
            CoherenceSync sync = GetComponent<CoherenceSync>();
            if(sync.HasStateAuthority)
            {
                OnDeath.Invoke(this);

                _unitPositions[_stats.faction].Remove(this);

                Destroy(gameObject);
            }
        }
    }
}
