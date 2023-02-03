using System;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class UnitSelections : MonoBehaviour
    {
        public List<GameObject> unitList = new();
        public List<GameObject> unitsSelected = new();

        private static UnitSelections _instance;
        public static UnitSelections Instance
        {
            get { return _instance; }
        }

        private Faction _faction;
        public Faction faction
        {
            get => _faction;
            set => _faction = value;
        }

        private void Awake()
        {
            //if an instance of this already exists and it isnt this one
            if (_instance != null && _instance != this)
            {
                //we destroy this instance
                Destroy(this.gameObject);
            }
            else
            {
                //make this instance
                _instance = this;
            }
        }

        public void ClickSelect(GameObject unitToAdd)
        {
            DeselectAll();
            if (AddSelectedUnit(unitToAdd))
                unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            //unitToAdd.GetComponent<UnitMovement>().enabled = true;
        }

        public void ShiftClickSelect(GameObject unitToAdd)
        {
            if (!unitsSelected.Contains(unitToAdd))
            {
                if(AddSelectedUnit(unitToAdd))
                    unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
                //unitToAdd.GetComponent<UnitMovement>().enabled = true;
            }
            else
            {
                //unitToAdd.GetComponent<UnitMovement>().enabled = false;
                unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
                unitsSelected.Remove(unitToAdd);
            }
        }

        public void DragSelect(GameObject unitToAdd)
        {
            if (!unitsSelected.Contains(unitToAdd) && AddSelectedUnit(unitToAdd))
            {
                unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
                //unitToAdd.GetComponent<UnitMovement>().enabled = true;
            }
        }

        public void DeselectAll()
        {
            foreach (var unit in unitsSelected)
            {
                //unit.GetComponent<UnitMovement>().enabled = false;
                unit.transform.GetChild(0).gameObject.SetActive(false);
            }
            unitsSelected.Clear();
        }

        public void Deselect(GameObject unitToDeselect)
        {

        }

        public bool AddSelectedUnit(GameObject unitObject)
        {
            Unit unit = unitObject.GetComponent<Unit>();
            
            if (unit == null || unit.stats.type != _faction) return false;

            unitsSelected.Add(unitObject);

            return true;
        }
    }
}
