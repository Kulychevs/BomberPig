using UnityEngine;


namespace BomberPig
{
    public sealed class Navigator : INavigator
    {
        private readonly IMapInfo _mapInfo;

        public Navigator(IMapInfo mapInfo)
        {
            _mapInfo = mapInfo;
        }


        public (MoveDirection direction, Vector2 destination) 
            CalculateDestination(CellCoordinatesModel cellCoordinates, Vector2 direction)
        {
            Vector2 destination = Vector2.zero;
            MoveDirection moveDirection;

            if (System.Math.Abs(direction.x) > System.Math.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    cellCoordinates.Column += 1;
                    moveDirection = MoveDirection.Right;
                }
                else
                {
                    cellCoordinates.Column -= 1;
                    moveDirection = MoveDirection.Left;
                }
            }
            else
            {
                if (direction.y < 0)
                {
                    cellCoordinates.Row += 1;
                    moveDirection = MoveDirection.Down;
                }
                else
                {
                    cellCoordinates.Row -= 1;
                    moveDirection = MoveDirection.Up;
                }
            }

            if (_mapInfo.IsValudCoordinates(cellCoordinates)
                && !_mapInfo.IsObstacleCell(cellCoordinates))
            {
                destination = _mapInfo.GetCellCenter(cellCoordinates);
            }
            else
                moveDirection = MoveDirection.None;

            return (moveDirection, destination);
        }
    }
}
