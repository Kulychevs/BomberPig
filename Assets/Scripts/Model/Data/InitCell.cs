using System;
using UnityEngine;


namespace BomberPig
{
    [Serializable]
    public struct InitCell
    {
        public bool IsObstacle;
        public GameObject ObstaclePrefab;
    }
}
