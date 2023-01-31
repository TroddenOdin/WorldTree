using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldTree.Map
{
    [RequireComponent(typeof(MeshFilter))]
    public class MonoCell : MonoBehaviour
    {
        private Cell _cell;
        public Cell cell
        {
            get { return _cell; }
            set { _cell = value; }
        }
        private MeshFilter _meshFilter;

        private void Start()
        {
            _meshFilter = GetComponent<MeshFilter>();
        }

        public void SetCell(Cell cell)
        {
            _cell = cell;
            _cell.OnChange.AddListener(UpdateVisual);
        }

        public void UpdateVisual()
        {
            // TODO: switch statement to set sprite based off _cell.type
        }
    }
}
