using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WorldTree.Core
{
    public enum ResourceTypes
    {
        Mana,
        Soil,
        Water,
        Light,
        Metal
    }


    public class ManaWell : MonoBehaviour
    {
        public string wellName;
        public Faction faction;
        public UnitNavMode itemMode = UnitNavMode.Selection;
        public ResourceTypes resource;




    }
}
