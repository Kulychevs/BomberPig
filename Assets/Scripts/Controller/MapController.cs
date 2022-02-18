using UnityEngine;

namespace BomberPig
{
    public sealed class MapController : IMapInfo
    {
        private readonly CellModel[,] _map;
        private readonly int _rowCount;
        private readonly int _columnCount;

        public MapController(MapData data)
        {
            var mapCreator = new MapCreator();
            _map = mapCreator.CreateMap(data);
            _rowCount = data.GetMap.Count;
            _columnCount = data.GetMap[0].Cells.Count;
            var obstaclesBuilder = new ObstaclesBuilder();
            obstaclesBuilder.BuildObstacles(data.GetMap, _map);
        }


        #region IMapInfo

        public Vector2 GetCellCenter(CellCoordinatesModel coordinates)
        {
            return _map[coordinates.Row, coordinates.Column].Center;
        }

        public bool IsObstacleCell(CellCoordinatesModel coordinates)
        {
            return _map[coordinates.Row, coordinates.Column].IsObstacle;
        }

        public bool IsValudCoordinates(CellCoordinatesModel coordinates)
        {
            return coordinates.Row >= 0 && coordinates.Row < _rowCount
                && coordinates.Column >= 0 && coordinates.Column < _columnCount;
        }

        #endregion
    }
}
