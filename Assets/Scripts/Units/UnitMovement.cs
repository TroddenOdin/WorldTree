using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
 
namespace WorldTree
{
    public class UnitMovement : MonoBehaviour
    {
        private static UnitMovement _instance;
        public static UnitMovement Instance => _instance;
        Camera cam;
        public LayerMask ground;
        public static List<UnitManager> _units => Globals.UNITS;
        public static List<UnitManager> _selectedUnits => Globals.SELECTED_UNITS;

        private void Start()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);

            cam = Camera.main;
        }

        //cached for function
        //float stepAngle = 60; // angular step// max number in one round
        //float step = 1; // circle number
        private void Update()
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            bool clicked = Input.GetMouseButtonDown(1);
            bool didHit = Physics.Raycast(ray, out hit, Mathf.Infinity, ground);
            for (int i = 0; i < _units.Count; ++i)
            {
                if (_units[i].unit.navMode == UnitNavMode.Selection && clicked && didHit && _selectedUnits.Contains(_units[i]))
                {
                    _units[i].unit.meshAgent.SetDestination(hit.point);
                }
                else if (_units[i].unit.navMode == UnitNavMode.Target && _units[i].unit.target != null)
                {
                    _units[i].unit.meshAgent.SetDestination(_units[i].unit.target.transform.position);
                }
            }
        }

        private void OnDisable()
        {
            _units.Clear();
        }

        public void AddMeshAgent(UnitManager unit)
        {
            _units.Add(unit);
            unit.OnDeath.AddListener(RemoveUnit);
        }

        private void RemoveUnit(UnitManager unit)
        {
            int index = _units.IndexOf(unit);
            _units.RemoveAt(index);
        }
    }
}
