using System.Collections.Generic;
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
        private static List<UnitNavMode> agentModes = new();

        private void Start()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);

            cam = Camera.main;
        }

        //cached for function
        float stepAngle = 60; // angular step// max number in one round
        float step = 1; // circle number
        private void Update()
        {

            if (!Input.GetMouseButtonDown(1)) return;

            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                for(int i = 0; i < units.Count; ++i)
                {
                    if (UnitSelections.Instance.unitsSelected.Contains(units[i].gameObject) && agentModes[i] == UnitNavMode.Selection)
                        units[i].meshAgent.SetDestination(hit.point);
                }

                int countOnCircle = Mathf.FloorToInt(360 / stepAngle);
                float randomizeAngle = Random.Range(0, stepAngle);
                for (int i = 0; i < units.Count; ++i)
                {
                    if (!UnitSelections.Instance.unitsSelected.Contains(units[i].gameObject)) continue;

                    var vec = Vector3.forward;
                    vec = Quaternion.Euler(0, stepAngle * (countOnCircle - 1) + randomizeAngle, 0) * vec;
                    units[i].meshAgent.SetDestination(units[i].meshAgent.destination + vec * (units[0].meshAgent.radius + units[i].meshAgent.radius + 0.5f) * step);
                    countOnCircle--;
                    i++;
                    if (countOnCircle == 0)
                    {
                        if (step != 3 && step != 4 && step < 6 || step == 10) { stepAngle /= 2f; }

                        countOnCircle = (int)(360 / stepAngle);
                        step++;
                        randomizeAngle = Random.Range(0, stepAngle);
                    }
                }
            }
        }

        private void OnDisable()
        {
            units.Clear();
        }

        public void AddMeshAgent(Unit unit)
        {
            UnitMovement.units.Add(unit);
            agentModes.Add(UnitNavMode.Selection);
        }
    }
}
