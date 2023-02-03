using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    [CreateAssetMenu(fileName = "Unit", menuName = "WorldTree/Unit", order = 0)]
    public class SOUnit : ScriptableObject
    {
        public string unitName;
        public Faction faction;
        public int cost;
        
        public float moveSpeed;
        
        public float attackPower;
        public float attackSpeed;

        public float agressionRadius = 10;
        public float attackRadius = 2;

        public float health;
    }
}
