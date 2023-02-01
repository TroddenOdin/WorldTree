using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTree
{
    [RequireComponent(typeof(MeshFilter))]
    public class MonoCell : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        [SerializeField]
        private CellType _type;
        public CellType type => _type;

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
        }
    }
}
