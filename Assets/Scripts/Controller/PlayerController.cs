using System;


namespace BomberPig
{
    public sealed class PlayerController : UnitController, IPlayer
    {
        public event Action OnBlownUp = delegate { };

        private bool _isBombSet;

        public PlayerController(PlayerData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor) :
            base(data, builder, mapInfo, navigator, motor)
        {
            _isBombSet = false;
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
    }
}
