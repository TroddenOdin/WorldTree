using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class PlayerOrchestrator : MonoBehaviour
    {
        [SerializeField]
        private Faction _faction;
        public Faction faction => _faction;

        [SerializeField]
        private UnitsSelection _selections;
        [SerializeField]
        private UnitMovement _movement;
        [SerializeField]
        private CameraController _cameraController;

        private void Start()
        {
            _selections.gameObject.SetActive(false);
            _movement.gameObject.SetActive(false);
            _cameraController.enabled = false;
        }

        public void EnablePlayerScripts(Faction faction)
        {
            _faction = faction;
            Globals.FACTION = _faction;
            _selections.gameObject.SetActive(true);
            _movement.gameObject.SetActive(true);
            _cameraController.enabled = true;
        }

        [SerializeField]
        private GameObject _soldierPrefabNature;
        [SerializeField]
        private GameObject _soldierPrefabCivilization;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Instantiate(_faction == Faction.Nature ? _soldierPrefabNature : _soldierPrefabCivilization);
            }
        }
        /* Another Queejon to-do list:
         * Fix P2 faction choice based off P1 faction choice
         * Update dirt and grass textures
         * Implement mana well
         * 
         */
    }
}
