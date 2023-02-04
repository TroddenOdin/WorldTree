using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTree
{
    [RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(BoxCollider))]
    public class MonoCell : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        [SerializeField]
        private CellType _type;
        public CellType type => _type;
        [SerializeField]
        private float _moveMultiplier = 1;
        public float moveMultiplier => _moveMultiplier;

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
        }
    }
}
