using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace BomberPig
{
    public sealed class MapModel
    {
        public CellCoordinatesModel PigCoordinates;
        private readonly CellModel[,] _map;
        private readonly int _rowsCount;
        private readonly int _columnsCount;

        public CellModel this[int i, int j] => _map[i,j];
        public CellModel[,] GetMap => _map;
        public int GetRows => _rowsCount;
        public int GetColumns => _columnsCount;


        public MapModel(CellModel[,] map, int rowsCont, int columnsCount)
        {
            _map = map;
            _rowsCount = rowsCont;
            _columnsCount = columnsCount;
        }
    }
}
