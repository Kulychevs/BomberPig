﻿using UnityEngine;
using System;

namespace BomberPig
{
    public sealed class EnemyController : UnitController
    {
        private const int MAX_DIRECTIONS = 4;

        private readonly float _waitTime;
        private event Action _onBlownUp = delegate { };
        private float _time;

        public EnemyController(EnemyData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor) :
            base(null, builder, mapInfo, navigator, motor)
        {
            _waitTime = data.GetWaitTime;
            _unitModel = new EnemyModel(data, _mapInfo.GetCellCenter(data.GetStartCell));
            _unitView = builder.BuildPlayer(data.GetPrefab, _unitModel.Position);
            _unitView.SetOrderInLayer(data.GetStartCell.Row);
            _onBlownUp += ((EnemyModel)_unitModel).SetDirtySprite;
            _time = 0;
        }

        public override void Execute()
        {
            base.Execute();

            if (!_isMoving)
            {
                _time += Services.Instance.TimeService.DeltaTime();
                if (_time > _waitTime)
                {
                    SetNewDestination();
                    _time = 0;
                }
            }
        }

        protected override void BlownUp()
        {
            _onBlownUp.Invoke();
            _unitView.SetSprite(_unitModel.GetSprite);
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

            SetInputDirection(direction);
        }
    }
}
