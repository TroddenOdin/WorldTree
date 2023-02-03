using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WorldTree
{
    public class UnitManager : MonoBehaviour
    {
        public GameObject selectionCircle;
        [SerializeField]
        private Unit _unit;
        public Unit unit => _unit;

        [HideInInspector]
        public UnityEvent<UnitManager> OnSetTarget;
        [HideInInspector]
        public UnityEvent<UnitManager> OnDeath;
        [HideInInspector]
        public UnityEvent<UnitManager> OnAttack;

        private void Start()
        {
            if(_unit != null)
            {
                Globals.UNITS.Add(this);
                _unit.OnSetTarget.AddListener((unit) => OnSetTarget.Invoke(this));
                _unit.OnDeath.AddListener((unit) => OnDeath.Invoke(this));
                _unit.OnAttack.AddListener((unit) => OnAttack.Invoke(this));
            }
        }

        private void OnMouseDown()
        {
            if (IsActive())
                Select(
                    true,
                    Input.GetKey(KeyCode.LeftShift) ||
                    Input.GetKey(KeyCode.RightShift)
                );
        }

        protected virtual bool IsActive()
        {
            return true;
        }

        public void Select() { Select(false, false); }
        public void Select(bool singleClick, bool holdingShift)
        {
            // basic case: using the selection box
            if (!singleClick)
            {
                _SelectUtil();
                return;
            }

            // single click: check for shift key
            if (!holdingShift)
            {
                List<UnitManager> selectedUnits = new List<UnitManager>(Globals.SELECTED_UNITS);
                foreach (UnitManager um in selectedUnits)
                    um.Deselect();
                _SelectUtil();
            }
            else
            {
                if (!Globals.SELECTED_UNITS.Contains(this))
                    _SelectUtil();
                else
                    Deselect();
            }
        }

        private void _SelectUtil()
        {
            if (Globals.SELECTED_UNITS.Contains(this) || _unit.stats.faction != Globals.faction) return;

            Globals.SELECTED_UNITS.Add(this);
            selectionCircle.SetActive(true);
        }

        public void Deselect()
        {
            if (!Globals.SELECTED_UNITS.Contains(this)) return;

            Globals.SELECTED_UNITS.Remove(this);
            selectionCircle.SetActive(false);
        }

        private void OnDestroy()
        {
            Globals.UNITS.Remove(this);
            Globals.SELECTED_UNITS.Remove(this);
        }
    }
}
