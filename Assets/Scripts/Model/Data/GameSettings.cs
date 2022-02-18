using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Data/" + nameof(GameSettings), order = 1)]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField] private MapData _mapData;
        [SerializeField] private PlayerData _playerData;

        public MapData GetMapData => _mapData;
        public PlayerData GetPlayerData => _playerData;
    }
}
