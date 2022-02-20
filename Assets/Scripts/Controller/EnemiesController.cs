using System;
using System.Collections.Generic;
using UnityEngine;


namespace BomberPig
{
    public sealed class EnemiesController : IExecute, IRestart
    {
        #region Fields

        public event Action OnEnemyCatchPig = delegate { };
        public event Action<int> OnEnemyBlownUp = delegate { };

        private readonly EnemiesModel _enemiesModel;
        private readonly IMapInfo _mapInfo;


        #endregion


        #region ClassLifeCycles

        public EnemiesController(EnemiesData data, IMapInfo mapInfo)
        {
            _enemiesModel = new EnemiesModel(data);
            _mapInfo = mapInfo;
            Initialization();
        }

        #endregion


        #region Methods

        private void Initialization()
        {
            SpawnEnemies();
            OnEnemyBlownUp.Invoke(_enemiesModel.EnemiesBlownUp);
        }

        private void CreateEnemy(EnemyData enemyData)
        {
            var enemy = new EnemyController(enemyData, _mapInfo, _mapInfo.GetRandomFreeCell());
            enemy.OnCatchPig += Catch;
            enemy.OnBlownUp += ListenerOnBlownUp;
            _enemiesModel.AddEnemy(enemy);
        }

        private void ListenerOnBlownUp()
        {
            IncreaseBlownUpEnemiesAmount();
            CheckBlownUpEnemies();
        }

        private void Catch()
        {
            OnEnemyCatchPig.Invoke();
        }

        private void IncreaseBlownUpEnemiesAmount()
        {
            OnEnemyBlownUp.Invoke(++_enemiesModel.EnemiesBlownUp);
        }

        private void CheckBlownUpEnemies()
        {
            var isBlownUp = true;
            foreach (var enemy in _enemiesModel)
            {
                if (!enemy.IsBlownUp)
                {
                    isBlownUp = false;
                    break;
                }
            }

            if (isBlownUp)
                SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            for (int i = 0; i < _enemiesModel.GetEnemyData.SpawnAtOneTime; i++)
            {
                var enemyIndex = UnityEngine.Random.Range(0, _enemiesModel.GetEnemyData.Enemies.Length);
                CreateEnemy(_enemiesModel.GetEnemyData.Enemies[enemyIndex]);
            }
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            for (int i = 0; i < _enemiesModel.Count; i++)
            {
                _enemiesModel[i].Execute();
            }
        }

        #endregion


        #region IRestart

        public void Restart()
        {
            foreach (var enemy in _enemiesModel)
            {
                enemy.OnCatchPig -= Catch;
                enemy.OnBlownUp -= ListenerOnBlownUp;
                enemy.Restart();
                GameObject.Destroy(enemy.GetGameObject);
            }
            _enemiesModel.Reset();
            Initialization();
        }

        #endregion
    }
}
