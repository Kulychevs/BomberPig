using UnityEngine;

namespace BomberPig
{
    public struct CellModel
    {
        public readonly Vector2 Center;
        public readonly bool IsObstacle;
        public GameObject Bomb;


        public CellModel(Vector2 center, bool isObstacle)
        {
            Center = center;
            IsObstacle = isObstacle;
            Bomb = null;
        }
    }
}
