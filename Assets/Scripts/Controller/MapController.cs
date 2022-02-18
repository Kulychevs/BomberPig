using UnityEngine;


namespace BomberPig
{
    public sealed class MapController : IMapInfo
    {
        #region Fields

        private readonly IBombBuilder _bombBuilder;
        private readonly CellModel[,] _map;
        private readonly int _rowCount;
        private readonly int _columnCount;

        #endregion


        #region ClassLifeCycles

        public MapController(MapData data, IBombBuilder bombBuilder)
        {
            _bombBuilder = bombBuilder;
            var mapCreator = new MapCreator();
            _map = mapCreator.CreateMap(data);
            _rowCount = data.GetMap.Count;
            _columnCount = data.GetMap[0].Cells.Count;
            var obstaclesBuilder = new ObstaclesBuilder();
            obstaclesBuilder.BuildObstacles(data.GetMap, _map);
        }

        #endregion


        #region Methods

        private void DetonateBomb(CellCoordinatesModel coordinates)
        {
            GameObject.Destroy(_map[coordinates.Row, coordinates.Column].Bomb);
            _map[coordinates.Row, coordinates.Column].Bomb = null;
        }

        #endregion


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

        public void SetBomb(CellCoordinatesModel coordinates)
        {
            _map[coordinates.Row, coordinates.Column].Bomb = 
                _bombBuilder.BuildBomd(_map[coordinates.Row, coordinates.Column].Center, coordinates.Row);
        }

        public bool IsBomb(CellCoordinatesModel coordinates)
        {
            if (_map[coordinates.Row, coordinates.Column].Bomb != null)
            {
                DetonateBomb(coordinates);
                return true;
            }

            return false;
        }

        #endregion
    }
}
