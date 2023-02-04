using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree
{
    public class TerrainManager : MonoBehaviour
    {
        [SerializeField]
        private Grid _terrainGrid;
        private BoundsInt _cellBounds;
        public List<List<MonoCell>> cells { get; private set; }

        private void Start()
        {
            GetCellBounds();
            GetCells();
        }

        private void GetCellBounds()
        {
            _cellBounds = new();
            int cellCount = _terrainGrid.transform.childCount;
            Vector3Int pos;
            for (int i = 0; i < cellCount; ++i)
            {
                pos = Vector3Int.FloorToInt(_terrainGrid.transform.GetChild(i).position);
                // mins
                if (pos.x < _cellBounds.min.x || pos.z < _cellBounds.min.z)
                    _cellBounds.min = new(pos.x < _cellBounds.min.x ? pos.x : _cellBounds.min.x, 0, pos.z < _cellBounds.min.z ? pos.z : _cellBounds.min.z);
                // maxes
                if (pos.x > _cellBounds.min.x || pos.z > _cellBounds.min.z)
                    _cellBounds.max = new(pos.x > _cellBounds.max.x ? pos.x : _cellBounds.max.x, 0, pos.z > _cellBounds.max.z ? pos.z : _cellBounds.max.z);
            }

            //Debug.Log($"X: {_cellBounds.max.x - _cellBounds.min.x}, Z: {_cellBounds.max.z - _cellBounds.min.z}");
        }

        private void GetCells()
        {
            cells = new(_cellBounds.size.x);
            for (int x = 0; x < _cellBounds.size.x + 1; ++x)
            {
                cells.Add(new(_cellBounds.size.z));
                for (int z = 0; z < _cellBounds.size.z + 1; ++z)
                {
                    cells[x].Add(null);
                }
            }

            int cellCount = _terrainGrid.transform.childCount;
            Vector3Int pos;
            MonoCell cell;
            for (int i = 0; i < cellCount; ++i)
            {
                pos = _terrainGrid.WorldToCell(_terrainGrid.transform.GetChild(i).position);
                cell = _terrainGrid.transform.GetChild(i).gameObject.GetComponent<MonoCell>();
                cells[pos.x - _cellBounds.x][pos.y - _cellBounds.z] = cell != null ? cell : cells[pos.x - _cellBounds.x][pos.y - _cellBounds.z];
            }
        }

        public MonoCell this[int x, int z]
        {
            get 
            { 
                if(0 <= x && x < cells.Count)
                    if(0 <= z && z < cells[x].Count)
                        return cells[x][z];
                Debug.LogWarning("Invalid TerrainManager index");
                return cells[0][0];
            }
        }

        public MonoCell this[Vector3 worldPosition]
        {
            get
            {
                Vector3Int cellSpace = _terrainGrid.WorldToCell(worldPosition);
                return this[cellSpace.x - _cellBounds.x, cellSpace.y - _cellBounds.z];
            }
        }
    }
}
