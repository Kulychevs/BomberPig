using System;
using UnityEngine;


namespace BomberPig
{
    public sealed class PlayerController : AUnitController, IPlayer, IRestart
    {
        #region Fields

        public event Action OnBlownUp = delegate { };
        public event Action<float> OnBombTimeUpdate = delegate { };

        private readonly PlayerModel _playerModel;

        #endregion


        #region ClasssLifeCycles

        public PlayerController(PlayerData data, IMapInfo mapInfo) :
            base(new PlayerModel(data, mapInfo.GetCellCenter(data.GetStartCell)),
                data.GetPrefab, mapInfo)
        {
            _playerModel = GetUnitModel as PlayerModel;
            Initialization();
        }

        #endregion


        #region Methods

        protected override void BlownUp()
        {
            OnBlownUp.Invoke();
        }

        private void ResetBombSet()
        {
            _playerModel.IsBompSet = false;
        }

        private void Initialization()
        {
            _mapInfo.SetPig(_playerModel.GetCoordinates);
            ChangeBombCooldownTime(0);
        }

        #endregion


        #region IPlayer

        public void SetBomb()
        {
            if (!_playerModel.IsBompSet && !_playerModel.IsMoving)
            {
                _mapInfo.SetBomb(_playerModel.GetCoordinates);
                Services.Instance.TimerService.Add(_playerModel.GetBombCoolDownTime, ResetBombSet, ChangeBombCooldownTime);
                _playerModel.IsBompSet = true;
            }
        }

        public void SetInputDirection(Vector2 direction)
        {
            if (SetNewDirection(direction))
            {
                _mapInfo.SetPig(_playerModel.GetCoordinates);
                if (_mapInfo.IsEnemy(_playerModel.GetCoordinates))
                    BlownUp();
            }
        }

        private void ChangeBombCooldownTime(float time)
        {
            var normalizedTime = (_playerModel.GetBombCoolDownTime - time) / _playerModel.GetBombCoolDownTime;
            OnBombTimeUpdate(normalizedTime);
        }

        #endregion


        #region IRestart

        public void Restart()
        {
            Restart(_playerModel.GetStartCell);
            Initialization();
        }

        #endregion
    }
}
