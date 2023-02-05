using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace WorldTree
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private BuildingPlacer _buildingPlacer;
        public Transform buildingMenu;
        public GameObject buildingButtonPrefab;
        private Dictionary<string, Button> _buildingButtons;

        private void Start()
        {
            _buildingPlacer = GetComponent<BuildingPlacer>();

            //create buttons for each building type
            _buildingButtons = new Dictionary<string, Button>();
            int i = 0;
            foreach (BuildingData data in _buildingPlacer.buildings)
            {
                GameObject button = Instantiate(buildingButtonPrefab, buildingMenu);
                button.name = data.unitName;
                button.transform.Find("Text").GetComponent<Text>().text = data.unitName;
                Button btn = null;
                button.name = data.code;
                button.transform.Find("Text").GetComponent<Text>().text = data.code;
                btn = button.GetComponent<Button>();
                _AddBuildingButtonListener(btn, i++);

                _buildingButtons[data.code] = btn;
                if (!data.CanBuy(_buildingPlacer.player.currentMana))
                {
                    btn.interactable = false;
                }
            }
        }

        private void OnEnable()
        {
            EventManager.AddListener("CheckBuildingButtons", _OnCheckBuildingButtons);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener("CheckBuildingButtons", _OnCheckBuildingButtons);
        }

        private void _AddBuildingButtonListener(Button b, int i)
        {
            b.onClick.AddListener(() => _buildingPlacer.SelectPlacedBuilding(i));
        }

        private void _OnCheckBuildingButtons()
        {
            foreach (BuildingData data in _buildingPlacer.buildings)
                _buildingButtons[data.code].interactable = data.CanBuy(_buildingPlacer.player.currentMana);
        }
    }
}
