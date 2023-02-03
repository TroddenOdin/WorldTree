using UnityEngine;

namespace WorldTree
{
    public class UnitClick : MonoBehaviour
    {
        private Camera _myCam;

        [SerializeField]
        private LayerMask clickable;

        [SerializeField]
        private LayerMask ground;


        void Start()
        {
            _myCam = Camera.main;
        }


        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _myCam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    //if we hit a clickable object

                    //Normal Click Vice Shift Click

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        //shift clicked
                        UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                    }
                    else
                    {
                        //normal clicked
                        UnitSelections.Instance.ClickSelect(hit.collider.gameObject);
                    }
                }
                else
                {
                    //if we didnt and NOT shifting
                    if (!Input.GetKey(KeyCode.LeftShift))
                    {
                        UnitSelections.Instance.DeselectAll();
                    }


                }






            }

        }

    }
}
