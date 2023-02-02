using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    [CreateAssetMenu(fileName = "Unit", menuName = "WorldTree/Unit", order = 0)]
    public class SOUnit : ScriptableObject
    {
        public string unitName;
        public Faction type;
        public int cost;
        
        public float moveSpeed;
        
        public float attackPower;
        public float attackSpeed;
        
        public float health;
    }
}
