using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldTree;

public class PlayerOrchestrator : MonoBehaviour
{
    [SerializeField]
    private Faction _faction;
    public Faction faction => _faction;

    [SerializeField]
    private UnitSelections _selections;
    [SerializeField]
    private UnitMovement _movement;

    private void Start()
    {
        _selections.faction = _faction;
    }
    // Queejon's Todo-list
    /*
     * Fix duplication of units in multiplayer 
     * Prompt player for faction choice on join
     * Display health above units
     * 
     * Start patching together other contributions to the project
     */
}
