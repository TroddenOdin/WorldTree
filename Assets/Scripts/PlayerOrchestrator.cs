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

        private void Start()
        {
            Globals.faction = _faction;
        }
        // Queejon's Todo-list
        /* 
         * Make units move speed be affected by the terrain
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
