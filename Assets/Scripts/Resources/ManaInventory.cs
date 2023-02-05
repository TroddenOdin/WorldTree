using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WorldTree.Core
{
    public enum resourceTypes
    {
        Mana,
        Soil,
        Water,
        Light,
        Metal
    }

    public class ManaInventory : MonoBehaviour
    {

        public int itemsinInventory = 0;
        public int maxItemsinInventory;

        public resourceTypes rType;


    }
}