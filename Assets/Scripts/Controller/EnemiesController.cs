using System;
using System.Collections.Generic;
using UnityEngine;


namespace BomberPig
{
    public sealed class EnemiesController : IExecute, IRestart
    {
        public event Action OnEnemyCatchPig = delegate { };

        private readonly EnemiesData _data;
        private readonly IBuildPlayer _builder;
        private readonly IMapInfo _mapInfo;
        private readonly INavigator _navigator;
        private readonly IUnitMotor _motor;
        private readonly List<EnemyController> _enemyControllers;

        public EnemiesController(EnemiesData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor)
        {
            _data = data;
            _builder = builder;
            _mapInfo = mapInfo;
            _navigator = navigator;
            _motor = motor;
            _enemyControllers = new List<EnemyController>();
            Initialization();
        }

        private void Initialization()
        {
            foreach (var enemyData in _data.Enemies)
            {
                var enemy = new EnemyController(enemyData, _builder, _mapInfo, _navigator, _motor);
                enemy.OnCatchPig += Catch;
                _enemyControllers.Add(enemy);
            }
        }

        private void Catch()
        {
            OnEnemyCatchPig.Invoke();
        }

        public void Execute()
        {
            foreach (var enemy in _enemyControllers)
            {
                enemy.Execute();
            }
        }

        public void Restart()
        {
            foreach (var enemy in _enemyControllers)
            {
                enemy.OnCatchPig -= Catch;
                enemy.Restart();
                GameObject.Destroy(enemy.GetGameObject);
            }
            _enemyControllers.Clear();
            Initialization();
        }
    }
}
