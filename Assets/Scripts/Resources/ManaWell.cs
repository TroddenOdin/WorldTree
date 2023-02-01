using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree.Core
{ 
[CreateAssetMenu(fileName = "ManaWell", menuName = "WorldTree/ManaWell", order = 0)]
public class ManaWell : ScriptableObject
{
        public string wellName;
        public Faction unit;



}
}