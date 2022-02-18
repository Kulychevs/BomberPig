using UnityEngine;
using System.Collections.Generic;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(MapData), menuName = "Data/" + nameof(MapData), order = 2)]
    public sealed class MapData : ScriptableObject
    {
        [SerializeField] private Vector2 _upperLeft;
        [SerializeField] private Vector2 _upperRight;
        [SerializeField] private Vector2 _lowerLeft;
        [SerializeField] private List<InitRow> _map;

        public Vector2 GetUpperLeft => _upperLeft;
        public Vector2 GetUpperRight => _upperRight;
        public Vector2 GetLowerLeft => _lowerLeft;
        public List<InitRow> GetMap => _map;
    }
}
