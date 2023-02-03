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
        public static List<Unit> units = new();

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
            for (int i = 0; i < units.Count; ++i)
            {
                if (units[i].navMode == UnitNavMode.Selection && clicked && didHit && Globals.SELECTED_UNITS.Contains(units[i].manager))
                {
                    units[i].meshAgent.SetDestination(hit.point);
                }
                else if (units[i].navMode == UnitNavMode.Target && units[i].target != null)
                {
                    units[i].meshAgent.SetDestination(units[i].target.transform.position);
                }
            }
        }

        private void OnDisable()
        {
            units.Clear();
        }

        public void AddMeshAgent(Unit unit)
        {
            units.Add(unit);
            unit.OnDeath.AddListener(RemoveUnit);
        }

        private void RemoveUnit(Unit unit)
        {
            int index = units.IndexOf(unit);
            units.RemoveAt(index);
        }
    }
}
