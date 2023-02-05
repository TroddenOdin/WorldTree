using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTree
{
    [RequireComponent(typeof(SphereCollider))]
    public class ManaWell : MonoBehaviour
    {
        public static List<ManaWell> manaWells { get; private set; } = new();

        private SphereCollider _area;
        private Dictionary<Faction, int> _claimCounts;
        private Faction _allegiance;
        public Faction allegiance => _allegiance;

        [SerializeField]
        private float _claimTotal;
        [SerializeField]
        private float _claimSpeed;
        private float _currentClaim;

        [Space(20)]

        [SerializeField]
        private Material _neutralMat;
        [SerializeField]
        private Material _natureMat;
        [SerializeField]
        private Material _civilizationMat;
        private MeshRenderer _renderer;

        [SerializeField] private GameObject progressBarPrefab;
        private GameObject progressBar = null;


        private void Start()
        {
            manaWells.Add(this);

            _area = GetComponent<SphereCollider>();
            _area.isTrigger = true;

            _allegiance = Faction.Neutral;
            _renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
            _renderer.material = _neutralMat;
            
            _currentClaim = _claimTotal;
            _claimCounts = new();
            _claimCounts[Faction.Nature] = 0;
            _claimCounts[Faction.Civilization] = 0;

            progressBar = ProgressBarContainer.progressBarContainer.CreateProgressBar(progressBarPrefab);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<UnitManager>(out UnitManager unit)) return;
            
            if (_claimCounts.ContainsKey(unit.unit.stats.faction))
                ++_claimCounts[unit.unit.stats.faction];
            else
                _claimCounts[unit.unit.stats.faction] = 1;
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<UnitManager>(out UnitManager unit)) return;
            
            if (_claimCounts.ContainsKey(unit.unit.stats.faction))
                --_claimCounts[unit.unit.stats.faction];
            else
                _claimCounts[unit.unit.stats.faction] = 0;
        }

        private void Update()
        {
            int total = (from claimCount in _claimCounts select claimCount.Value).Sum();

            if (total == 0) return;

            if (total == _claimCounts[Faction.Nature])
            {
                _currentClaim += (_allegiance == Faction.Nature ? 1 : -1) * _claimSpeed * Time.deltaTime;

                if (_currentClaim <= 0)
                {
                    _allegiance = Faction.Nature;
                    _currentClaim = Mathf.Epsilon;
                    _renderer.material = _natureMat;
                    //Debug.Log("Nature claims!");
                }
            }
            else if(total == _claimCounts[Faction.Civilization])
            {
                _currentClaim += (_allegiance == Faction.Civilization ? 1 : -1) *_claimSpeed * Time.deltaTime;

                if (_currentClaim <= 0)
                {
                    _allegiance = Faction.Civilization;
                    _currentClaim = Mathf.Epsilon;
                    _renderer.material = _civilizationMat;
                    //Debug.Log("Civ claims!");
                }
            }

            if (_currentClaim > _claimTotal)
            {
                _currentClaim = _claimTotal;
            }
        }

        private void LateUpdate()
        {
            if (_renderer.isVisible)
            {
                progressBar.GetComponent<Image>().enabled = true;
                progressBar.GetComponent<Image>().fillAmount = _currentClaim / _claimTotal;
                progressBar.transform.position = Camera.main.WorldToScreenPoint(_renderer.transform.position) + Vector3.up * 25f;
            }
            else
            {
                progressBar.GetComponent<Image>().enabled = false;
            }
        }

        private void OnDestroy()
        {
            Destroy(progressBar);
        }
    }
}
