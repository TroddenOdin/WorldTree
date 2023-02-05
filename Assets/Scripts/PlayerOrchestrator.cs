using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    [RequireComponent(typeof(Player))]
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
        private Player _player;

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
            _player = GetComponent<Player>();
            _player.SetFaction(_faction);
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
         * 
         * Fix faction buttons
         */
    }
}
