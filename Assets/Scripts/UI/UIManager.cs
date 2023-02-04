using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


namespace WorldTree
{
    public class UIManager : MonoBehaviour
    {
        private BuildingPlacer _buildingPlacer;
        public Transform buildingMenu;
        public GameObject buildingButtonPrefab;
        public Transform resourcesUIParent;
        public GameObject gameResourceDisplayPrefab;
        private Dictionary<string, Button> _buildingButtons;
        private Dictionary<string, Text> _resourceTexts;

        private void Awake()
        {
            _buildingPlacer = GetComponent<BuildingPlacer>();

            // create texts for each in-game resource (mana, wood, stone...)
            _resourceTexts = new Dictionary<string, Text>();
            foreach (KeyValuePair<string, GameResource> pair in Globals.GAME_RESOURCES)
            {
                GameObject display = Instantiate(gameResourceDisplayPrefab, resourcesUIParent);
                display.name = pair.Key;
                _resourceTexts[pair.Key] = display.transform.Find("Text").GetComponent<Text>();
                _SetResourceText(pair.Key, pair.Value.Amount);
            }



            if (Globals.FACTION == Faction.Civilization)
            {
                //create buttons for each building type
                _buildingButtons = new Dictionary<string, Button>();
                int i = 0;
                foreach (BuildingData data in _buildingPlacer.buildings)
                {
                    GameObject button = Instantiate(buildingButtonPrefab);
                    button.name = data.unitName;
                    button.transform.Find("Text").GetComponent<Text>().text = data.unitName;
                    Button btn = null;
                    button.name = data.code;
                    button.transform.Find("Text").GetComponent<Text>().text = data.code;
                    btn = button.GetComponent<Button>();
                    _AddBuildingButtonListener(btn, i++);

                    _buildingButtons[data.code] = btn;
                    if (!data.CanBuy())
                    {
                        btn.interactable = false;
                    }
                }
            }
        }

        private void OnEnable()
        {
            EventManager.AddListener("UpdateResourceTexts", _OnUpdateResourceTexts);
            EventManager.AddListener("CheckBuildingButtons", _OnCheckBuildingButtons);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener("UpdateResourceTexts", _OnUpdateResourceTexts);
            EventManager.RemoveListener("CheckBuildingButtons", _OnCheckBuildingButtons);
        }

        private void _AddBuildingButtonListener(Button b, int i)
        {
            b.onClick.AddListener(() => _buildingPlacer.SelectPlacedBuilding(i));
        }

        private void _SetResourceText(string resource, int value)
        {
            _resourceTexts[resource].text = value.ToString();
        }

        private void _OnUpdateResourceTexts()
        {
            foreach (KeyValuePair<string, GameResource> pair in Globals.GAME_RESOURCES)
                _SetResourceText(pair.Key, pair.Value.Amount);
        }

        private void _OnCheckBuildingButtons()
        {
            foreach (BuildingData data in _buildingPlacer.buildings)
                _buildingButtons[data.code].interactable = data.CanBuy();
        }
    }
}
