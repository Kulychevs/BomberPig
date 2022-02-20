using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(EnemiesData), menuName = "Data/" + nameof(EnemiesData), order = 6)]
    public sealed class EnemiesData : ScriptableObject
    {
        public EnemyData[] Enemies;
        public int SpawnAtOneTime;
    }
}
