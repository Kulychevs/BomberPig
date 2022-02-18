using UnityEngine;


namespace BomberPig
{
    public interface IMapInfo
    {
        public Vector2 GetCellCenter(CellCoordinatesModel coordinates);
        public bool IsObstacleCell(CellCoordinatesModel coordinates);
        public bool IsValudCoordinates(CellCoordinatesModel coordinates);
    }
}
