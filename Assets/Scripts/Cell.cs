using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace WorldTree.Map
{
    public struct Cell
    {
        private int _x;
        public int x => _x;
        private int _y;
        public int y => _y;

        private CellType _type;
        public CellType type => _type;

        [HideInInspector]
        public UnityEvent OnChange;

        public Cell(int x, int y, CellType type = CellType.Special)
        {
            _x = x;
            _y = y;

            _type = type;
            OnChange = new();
        }

        public void SetCoordinates(Vector2Int coords)
        {
            _x = coords.x;
            _y = coords.y;

            OnChange?.Invoke();
        }

        public void SetType(CellType type)
        {
            _type = type;

            OnChange?.Invoke();
        }
    }
}
