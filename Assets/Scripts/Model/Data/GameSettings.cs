using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(GameSettings), menuName = "Data/" + nameof(GameSettings), order = 1)]
    public sealed class GameSettings : ScriptableObject
    {
        [SerializeField] private MapData _mapData;
        [SerializeField] private PlayerData _playerData;
        [SerializeField] private EnemiesData _enemiesData;
        [SerializeField] private GameObject _bombPrefab;

        public MapData GetMapData => _mapData;
        public PlayerData GetPlayerData => _playerData;
        public EnemiesData GetEnemiesData => _enemiesData;
        public GameObject getBombPrefab => _bombPrefab;
    }
}
