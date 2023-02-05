using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WorldTree
{
    public class RootsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _rootPrefab;
        private Unit _unit;
        private Vector3 _targetPos;
        private bool _placing;
        public UnityEvent<Unit> OnPlace;

        private Ray _ray;
        private RaycastHit _raycastHit;

        private void Start()
        {
            _unit = _rootPrefab.GetComponent<Unit>();
        }

        public void SetFaction(Faction faction)
        {
            if (faction != Faction.Nature)
                Destroy(this);
        }

        private void Update()
        {
            if(_placing && Input.GetMouseButtonDown(0))
            {
                _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(_ray, out _raycastHit, 1000f))
                {
                    Debug.Log(_raycastHit.transform.gameObject.layer);
                    if (_raycastHit.transform.gameObject.layer == 6)
                    {
                        _targetPos = _raycastHit.point;
                        Unit root = null;
                        OnPlace.Invoke(root);
                    } 
                }
            }
        }

        public bool TogglePlacing()
        {
            _placing = !_placing;
            return _placing;
        }
    }
}
