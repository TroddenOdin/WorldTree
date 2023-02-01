using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace WorldTree
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Unit : MonoBehaviour, IDamageable
    {
        [SerializeField]
        private SOUnit _stats;
        public SOUnit stats => _stats;

        private static Dictionary<Faction, Dictionary<Unit, Vector3>> _unitPositions;

        private Unit _target;
        public Unit target => _target;
        private NavMeshAgent _meshAgent;
        public NavMeshAgent meshAgent => _meshAgent;

        private void Start()
        {
            _meshAgent = GetComponent<NavMeshAgent>();
            UnitSelections.Instance.unitList.Add(gameObject);
            UnitMovement.Instance.AddMeshAgent(this);

            _unitPositions ??= new();
            if (!_unitPositions.ContainsKey(_stats.type)) 
                _unitPositions[_stats.type] = new();
            
            _unitPositions[_stats.type].Add(this, transform.position);
        }

        private void Update()
        {
            GetTarget();
        }

        private void LateUpdate()
        {
            _unitPositions[_stats.type][this] = transform.position;
        }

        private void OnDestroy()
        {
            UnitSelections.Instance.unitList.Remove(gameObject);
        }

        private void GetTarget()
        {
            if (_target != null) return;

            foreach (var dict in _unitPositions)
            {
                if (dict.Key == _stats.type) continue;

                foreach (var unit in dict.Value)
                {
                    if ((unit.Value - transform.position).magnitude < _stats.agressionRadius)
                    {
                        _target = unit.Key;
                        return;
                    }
                }
            }
        }

        public void Damage(float damage)
        {
            throw new System.NotImplementedException();
        }

        public void Heal(float damage)
        {
            throw new System.NotImplementedException();
        }
    }
}
