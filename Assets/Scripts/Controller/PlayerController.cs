using System;
using UnityEngine;


namespace BomberPig
{
    public sealed class PlayerController : UnitController, IPlayer, IRestart
    {
        public event Action OnBlownUp = delegate { };

        private PlayerData _data;
        private bool _isBombSet;

        public PlayerController(PlayerData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor) :
            base(data, builder, mapInfo, navigator, motor)
        {
            _data = data;
            _isBombSet = false;
            _mapInfo.SetPig(_unitModel.GetCoordinates);
        }

        public void SetBomb()
        {
            if (!_isBombSet)
            {
                _mapInfo.SetBomb(_unitModel.GetCoordinates);
                Services.Instance.TimerService.Add(3, ResetBombSet);
                _isBombSet = true;
            }
        }

        protected override void BlownUp()
        {
            OnBlownUp.Invoke();
        }

        private void ResetBombSet()
        {
            _isBombSet = false;
        }


        #region IPlayer

        public void SetInputDirection(Vector2 direction)
        {
            if (SetNewDirection(direction))
            {
                _mapInfo.SetPig(_unitModel.GetCoordinates);
                if (_mapInfo.IsEnemy(_unitModel.GetCoordinates))
                    BlownUp();
            }
        }

        #endregion


        #region IRestart

        public void Restart()
        {
            _isMoving = false;
            _unitModel = new UnitModel(_data, _mapInfo.GetCellCenter(_data.GetStartCell));
            _unitView.SetPosition(_mapInfo.GetCellCenter(_unitModel.GetCoordinates));
        }

        #endregion
    }
}
