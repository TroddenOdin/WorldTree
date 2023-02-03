using UnityEngine;
using UnityEngine.InputSystem;

namespace WorldTree
{
    public class UnitDrag : MonoBehaviour
    {
        private Camera _myCam;

        //Graphics
        [SerializeField]
        private RectTransform boxVisual;

        //Logical
        private Rect _selectionBox;

        private Vector2 _startPosition;
        private Vector2 _endPosition;
        void Start()
        {
            _myCam = Camera.main;
            _startPosition = Vector2.zero;
            _endPosition = Vector2.zero;
            DrawVisual();
        }

        void Update()
        {

            //when clicked
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                _startPosition = Mouse.current.position.ReadValue();
                _selectionBox = new Rect();
            }
            //when dragging
            if (Mouse.current.leftButton.isPressed)
            {
                _endPosition = Mouse.current.position.ReadValue();
                DrawVisual();
                DrawSelection();
            }
            //when released click
            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                SelectUnits();
                _startPosition = Vector2.zero;
                _endPosition = Vector2.zero;
                DrawVisual();
            }
        }

        void DrawVisual()
        {
            Vector2 boxStart = _startPosition;
            Vector2 boxEnd = _endPosition;

            Vector2 boxCenter = (boxStart + boxEnd) / 2;
            boxVisual.position = boxCenter;

            Vector2 boxSize = new Vector2(Mathf.Abs(boxStart.x - boxEnd.x), Mathf.Abs(boxStart.y - boxEnd.y));

            boxVisual.sizeDelta = boxSize;



        }

        void DrawSelection()
        {
            //X Calcs
            if (Mouse.current.position.ReadValue().x < _startPosition.x)
            {
                //dragging left
                _selectionBox.xMin = Mouse.current.position.ReadValue().x;
                _selectionBox.xMax = _startPosition.x;
            }
            else
            {
                //dragging right
                _selectionBox.xMin = _startPosition.x;
                _selectionBox.xMax = Mouse.current.position.ReadValue().x;
            }

            //Y Calcs
            if (Mouse.current.position.ReadValue().y < _startPosition.y)
            {
                //dragging down
                _selectionBox.yMin = Mouse.current.position.ReadValue().y;
                _selectionBox.yMax = _startPosition.y;
            }
            else
            {
                //dragging up
                _selectionBox.yMin = _startPosition.y;
                _selectionBox.yMax = Mouse.current.position.ReadValue().y;
            }
        }

        void SelectUnits()
        {
            //loop thru units
            foreach (var unit in UnitSelections.Instance.unitList)
            {
                //if unit is within selection rect
                if (_selectionBox.Contains(_myCam.WorldToScreenPoint(unit.transform.position)))
                {
                    // add unit to selection if in box
                    UnitSelections.Instance.DragSelect(unit);
                }
            }
        }
    }
}
