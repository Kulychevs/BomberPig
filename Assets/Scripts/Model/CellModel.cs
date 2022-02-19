using UnityEngine;

namespace BomberPig
{
    public struct CellModel
    {
        public GameObject Bomb;
        public int EnemiesNumber;
        public readonly bool IsObstacle;
        public readonly Vector2 Center;


        public CellModel(Vector2 center, bool isObstacle)
        {
            Bomb = null;
            EnemiesNumber = 0;
            IsObstacle = isObstacle;
            Center = center;
        }
    }
}
