using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class PlayerOrchestrator : MonoBehaviour
    {
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
            Globals.faction = _faction;
            _selections.gameObject.SetActive(true);
            _movement.gameObject.SetActive(true);
            _cameraController.enabled = true;
        }
        // Queejon's Todo-list
        /* 
         * Disable scripts until lobby is joined
         * Prompt player for faction choice on join
         * Display health above units
         * 
         * Fix duplication of units in multiplayer
         * 
         * Start patching together other contributions to the project
         */
    }
}
