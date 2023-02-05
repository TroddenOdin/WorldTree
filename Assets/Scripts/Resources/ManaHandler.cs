using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree.Core
{


    public class ManaHandler : MonoBehaviour
    {
        private static ManaHandler instance;

        [SerializeField] private Transform manaWellTransform; //aka ManaWell
        [SerializeField] private Transform manaStorage; // aka MANA STORAGE!!!!!

        private void Awake()
        {
            instance = this;
        }

        private Transform GetResourceNode()
        {
            return manaWellTransform;
        }

        public static Transform GetResourceNode_Static()
        {
            return instance.GetResourceNode();
        }

        private Transform GetStorage()
        {
            return manaStorage;
        }

        public static Transform GetStorage_Static()
        {
            return instance.GetStorage();
        }


    }
}