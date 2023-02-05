using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class RootsManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _rootPrefab;
        private Unit _unit;
        private Vector3 _targetPos;

        private Ray _ray;
        private RaycastHit _raycastHit;

        private void Start()
        {
            _unit = _rootPrefab.GetComponent<Unit>();
        }

        public void BeginPlacePreview()
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _raycastHit, 1000f))
            {
                if (_raycastHit.transform.tag == "Ground")
                    _targetPos = _raycastHit.point;
                Debug.Log(_targetPos);
            }
        }
    }
}
