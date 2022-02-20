using UnityEngine;


namespace BomberPig
{
    public sealed class MoveDirectionService
    {
        public MoveDirection GetMoveDirection(Vector2 direction)
        {
            MoveDirection moveDirection;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                    moveDirection = MoveDirection.Right;
                else
                    moveDirection = MoveDirection.Left;
            }
            else
            {
                if (direction.y < 0)
                    moveDirection = MoveDirection.Down;
                else
                    moveDirection = MoveDirection.Up;
            }

            return moveDirection;
        }
    }
}
