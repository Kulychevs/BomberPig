using UnityEngine;

namespace BomberPig
{
    public sealed class CellModel
    {
        public readonly Vector2 Center;
        public readonly bool IsObstacle;


        public CellModel(Vector2 center, bool isObstacle)
        {
            Center = center;
            IsObstacle = isObstacle;
        }
    }
}
