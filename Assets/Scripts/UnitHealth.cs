using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WorldTree
{
    [RequireComponent(typeof(Unit))]
    public class UnitHealth : MonoBehaviour
    {
        [SerializeField] private GameObject _healthBarPrefab;
        private GameObject _healthBar;
        private Slider _slider;

        private Unit _unit;

        private Renderer _cachedRenderer = null;

        // Start is called before the first frame update
        void Start()
        {
            _unit = GetComponent<Unit>();

            _healthBar = HealthBarContainer.container.CreateHealthBar(_healthBarPrefab);
            _slider = _healthBar.GetComponent<Slider>();
            _slider.maxValue = _unit.stats.health;
            _slider.minValue = 0;
            _slider.value = _unit.currentHealth;
        }


        // Update is called once per frame
        void Update()
        {
            _cachedRenderer ??= transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Renderer>();
            if (_cachedRenderer.isVisible)
            {
                _healthBar.SetActive(true);
                _healthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position) + Vector3.up * 25f;
                _slider.value = _unit.currentHealth;
            }
            else
            {
                _healthBar.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            Destroy(_healthBar);
        }
    }
}
