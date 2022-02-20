using UnityEngine;


namespace BomberPig
{
    public interface IMapInfo
    {
        public Vector2 GetCellCenter(CellCoordinatesModel coordinates);
        public bool IsObstacleCell(CellCoordinatesModel coordinates);
        public bool IsValudCoordinates(CellCoordinatesModel coordinates);
        public void SetBomb(CellCoordinatesModel coordinates);
        public bool IsBomb(CellCoordinatesModel coordinates);
        public void SetPig(CellCoordinatesModel coordinates);
        public bool IsPig(CellCoordinatesModel coordinates);
        public bool IsEnemy(CellCoordinatesModel coordinates);
        public void SetEnemy(CellCoordinatesModel coordinates);
        public void RemoveEnemy(CellCoordinatesModel coordinates);
        public (MoveDirection direction, Vector2 destination)
            CalculateDestination(CellCoordinatesModel cellCoordinates, Vector2 direction);
        public CellCoordinatesModel GetRandomFreeCell();
    }
}
