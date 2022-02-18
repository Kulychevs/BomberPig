using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(EnemiesData), menuName = "Data/" + nameof(EnemiesData), order = 5)]
    public sealed class EnemiesData : ScriptableObject
    {
        public EnemyData[] Enemies;
    }
}
