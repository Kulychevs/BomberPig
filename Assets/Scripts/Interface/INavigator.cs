using UnityEngine;


namespace BomberPig
{
    public interface INavigator
    {
        public (MoveDirection direction, Vector2 destination) 
            CalculateDestination(CellCoordinatesModel cellCoordinates, Vector2 direction);
    }
}
