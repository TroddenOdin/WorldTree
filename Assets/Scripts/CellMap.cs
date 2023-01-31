#define VISUAL_STANDIN
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldTree.Map
{
    public class CellMap : MonoBehaviour
    {
        private List<List<MonoCell>> _grid;
        public List<List<MonoCell>> grid => _grid;
        [SerializeField]
        private Vector2Int _gridSize;
        public Vector2Int gridSize => _gridSize;
        [SerializeField]
        private GameObject _cellPrefab;
        private Bounds _cellBounds;
#if VISUAL_STANDIN
        public Color evenColor = Color.white;
        public Color oddColor = Color.black;
#endif

        private void Start()
        {

            _grid = new(_gridSize.x);
            
            for (int x = 0; x < _gridSize.x; ++x)
            {
                _grid.Add(new(_gridSize.y));
                for (int y = 0; y < _gridSize.y; ++y)
                {
                    _grid[x].Add(Instantiate(_cellPrefab, transform).GetComponent<MonoCell>());
                    _grid[x][y].SetCell(new(x, y));
                    if (x == 0 && y == 0)
                        _cellBounds = _grid[x][y].GetComponent<BoxCollider>().bounds;
                    Vector3 pos = new((_gridSize.x / 2 - x) * _cellBounds.size.x, transform.position.y, (_gridSize.y / 2 - y) * _cellBounds.size.z);
                    _grid[x][y].transform.position = pos;
#if VISUAL_STANDIN
                    _grid[x][y].GetComponent<MeshRenderer>().material.color = x % 2 == 0 ? (y % 2 == 0 ? oddColor : evenColor) : (y % 2 == 0 ? evenColor : oddColor);
#endif
                }
            }
        }
    }
}
