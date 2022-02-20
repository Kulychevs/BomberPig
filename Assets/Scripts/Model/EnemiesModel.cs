using System.Collections.Generic;


namespace BomberPig
{
    public sealed class EnemiesModel
    {
        #region Fields

        public int EnemiesBlownUp;
        private readonly List<EnemyController> _enemyControllers;
        private readonly EnemiesData _data;
        private readonly int _spawnAtOneTime;

        #endregion


        #region Properties
        public IEnumerator<EnemyController> GetEnumerator() => _enemyControllers.GetEnumerator();
        public EnemyController this[int i] => _enemyControllers[i];
        public EnemiesData GetEnemyData => _data;
        public int GetSpawnAtOneTime => _spawnAtOneTime;
        public int Count => _enemyControllers.Count;

        #endregion


        #region ClassLifeCycles

        public EnemiesModel(EnemiesData data)
        {
            EnemiesBlownUp = 0;
            _enemyControllers = new List<EnemyController>();
            _data = data;
            _spawnAtOneTime = data.SpawnAtOneTime;
        }

        #endregion


        #region Methods

        public void AddEnemy(EnemyController enemy)
        {
            _enemyControllers.Add(enemy);
        }

        public void Reset()
        {
            EnemiesBlownUp = 0;
            _enemyControllers.Clear();
        }

        #endregion
    }
}
