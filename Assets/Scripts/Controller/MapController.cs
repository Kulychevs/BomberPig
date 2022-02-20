using UnityEngine;


namespace BomberPig
{
    public sealed class MapController : IMapInfo, IRestart
    {
        #region Fields

        private readonly IBombBuilder _bombBuilder;
        private readonly MapModel _mapModel;

        #endregion


        #region ClassLifeCycles

        public MapController(MapData data, IBombBuilder bombBuilder)
        {
            _bombBuilder = bombBuilder;
            var mapCreator = new MapBuilder();
            _mapModel = new MapModel(mapCreator.CreateMap(data), data.GetMap.Count, data.GetMap[0].Cells.Count);
        }

        #endregion


        #region Methods

        private void DetonateBomb(CellCoordinatesModel coordinates)
        {
            GameObject.Destroy(_mapModel[coordinates.Row, coordinates.Column].Bomb);
            _mapModel.GetMap[coordinates.Row, coordinates.Column].Bomb = null;
        }

        private void UpdateCellCoordinates(MoveDirection moveDirection, ref CellCoordinatesModel cellCoordinates)
        {
            switch (moveDirection)
            {
                case MoveDirection.None:
                    break;
                case MoveDirection.Right:
                    cellCoordinates.Column += 1;
                    break;
                case MoveDirection.Left:
                    cellCoordinates.Column -= 1;
                    break;
                case MoveDirection.Up:
                    cellCoordinates.Row -= 1;
                    break;
                case MoveDirection.Down:
                    cellCoordinates.Row += 1;
                    break;
                default:
                    break;
            }
        }

        #endregion


        #region IMapInfo

        public Vector2 GetCellCenter(CellCoordinatesModel coordinates)
        {
            return _mapModel[coordinates.Row, coordinates.Column].Center;
        }

        public bool IsObstacleCell(CellCoordinatesModel coordinates)
        {
            return _mapModel[coordinates.Row, coordinates.Column].IsObstacle;
        }

        public bool IsValudCoordinates(CellCoordinatesModel coordinates)
        {
            return coordinates.Row >= 0 && coordinates.Row < _mapModel.GetRows
                && coordinates.Column >= 0 && coordinates.Column < _mapModel.GetColumns;
        }

        public void SetBomb(CellCoordinatesModel coordinates)
        {
            if (_mapModel[coordinates.Row, coordinates.Column].Bomb == null)
            {
                _mapModel.GetMap[coordinates.Row, coordinates.Column].Bomb =
                    _bombBuilder.BuildBomd(_mapModel[coordinates.Row, coordinates.Column].Center, coordinates.Row);
            }
        }

        public bool IsBomb(CellCoordinatesModel coordinates)
        {
            if (_mapModel[coordinates.Row, coordinates.Column].Bomb != null)
            {
                DetonateBomb(coordinates);
                return true;
            }

            return false;
        }

        public void SetPig(CellCoordinatesModel coordinates)
        {
            _mapModel.PigCoordinates = coordinates;
        }

        public bool IsPig(CellCoordinatesModel coordinates)
        {
            return coordinates == _mapModel.PigCoordinates;
        }

        public bool IsEnemy(CellCoordinatesModel coordinates)
        {
            return _mapModel[coordinates.Row, coordinates.Column].EnemiesNumber > 0;
        }

        public void SetEnemy(CellCoordinatesModel coordinates)
        {
            _mapModel.GetMap[coordinates.Row, coordinates.Column].EnemiesNumber += 1;
        }

        public void RemoveEnemy(CellCoordinatesModel coordinates)
        {
            _mapModel.GetMap[coordinates.Row, coordinates.Column].EnemiesNumber -= 1;
        }

        public (MoveDirection direction, Vector2 destination)
            CalculateDestination(CellCoordinatesModel cellCoordinates, Vector2 direction)
        {
            var destination = Vector2.zero;
            var moveDirection = Services.Instance.MoveDirectionService.GetMoveDirection(direction);

            UpdateCellCoordinates(moveDirection, ref cellCoordinates);

            if (IsValudCoordinates(cellCoordinates)
                && !IsObstacleCell(cellCoordinates))
            {
                destination = GetCellCenter(cellCoordinates);
            }
            else
                moveDirection = MoveDirection.None;

            return (moveDirection, destination);
        }


        public CellCoordinatesModel GetRandomFreeCell()
        {
            CellCoordinatesModel cellCoordinates;
            do
            {
                cellCoordinates.Row = Random.Range(0, _mapModel.GetRows);
                cellCoordinates.Column = Random.Range(0, _mapModel.GetColumns);
            } 
            while (IsObstacleCell(cellCoordinates) || IsPig(cellCoordinates));

            return cellCoordinates;
        }

        #endregion


        #region IRestart

        public void Restart()
        {
            for (int i = 0; i < _mapModel.GetRows; i++)
            {
                for (int j = 0; j < _mapModel.GetColumns; j++)
                {
                    if (_mapModel[i, j].Bomb != null)
                        DetonateBomb(new CellCoordinatesModel { Row = i, Column = j });
                }
            }
        }

        #endregion
    }
}
