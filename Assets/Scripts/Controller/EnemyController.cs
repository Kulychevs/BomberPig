using UnityEngine;
using System;


namespace BomberPig
{
    public sealed class EnemyController : AUnitController
    {
        #region Fields

        public event Action OnCatchPig = delegate { };
        public event Action OnBlownUp = delegate { };

        private const int MAX_DIRECTIONS = 4;

        private readonly EnemyModel _enemyModel;

        #endregion


        #region Properties

        public bool IsBlownUp => _enemyModel.IsBlownUp;

        #endregion


        #region ClassLifeCycles

        public EnemyController(EnemyData data, IMapInfo mapInfo, CellCoordinatesModel startCell) :
            base(new EnemyModel(data, startCell, mapInfo.GetCellCenter(startCell)), 
                data.GetPrefab, mapInfo, new UnitBuilder())
        {
            _enemyModel = GetUnitModel as EnemyModel;
            _mapInfo.SetEnemy(_enemyModel.GetCoordinates);
        }

        #endregion


        #region Methods

        public void Restart()
        {
            _mapInfo.RemoveEnemy(_enemyModel.GetCoordinates);
        }

        public override void Execute()
        {
            base.Execute();

            if (!_enemyModel.IsMoving && !_enemyModel.IsWaiting)
            {
                Services.Instance.TimerService.Add(_enemyModel.GetWaitTime, SetNewDestination, null);
                _enemyModel.IsWaiting = true;
            }
        }

        protected override void BlownUp()
        {
            _enemyModel.IsBlownUp = true;
            RefreshSprite();
            OnBlownUp.Invoke();
        }

        private void SetNewDestination()
        {
            int d = UnityEngine.Random.Range(0, MAX_DIRECTIONS);
            Vector2 direction = Vector2.zero;

            switch (d)
            {
                case 0:
                    direction = new Vector2(0, 1);
                    break;
                case 1:
                    direction = new Vector2(0, -1);
                    break;
                case 2:
                    direction = new Vector2(1, 0);
                    break;
                case 3:
                    direction = new Vector2(-1, 0);
                    break;
                default:
                    break;
            }
            var oldCoordinates = _enemyModel.GetCoordinates;
            if (SetNewDirection(direction))
            {
                _mapInfo.RemoveEnemy(oldCoordinates);
                _mapInfo.SetEnemy(_enemyModel.GetCoordinates);
                if (_mapInfo.IsPig(_enemyModel.GetCoordinates))
                    OnCatchPig.Invoke();
            }

            _enemyModel.IsWaiting = false;
        }



        #endregion
    }
}
