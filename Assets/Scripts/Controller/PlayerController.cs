namespace BomberPig
{
    public sealed class PlayerController : IExecute, IPlayer
    {
        #region Fields

        private readonly IMapInfo _mapInfo;
        private readonly INavigator _navigator;
        private readonly IUnitMotor _motor;
        private readonly UnitModel _unitModel;
        private readonly UnitView _unitView;
        private bool _isMoving;

        #endregion


        #region ClassLifeCycles

        public PlayerController(PlayerData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor)
        {
            _mapInfo = mapInfo;
            _navigator = navigator;
            _motor = motor;
            _unitModel = new UnitModel(data, _mapInfo.GetCellCenter(data.GetStartCell));
            _unitView = builder.BuildPlayer(data.GetPrefab, _unitModel.Position);
            _unitView.SetOrderInLayer(data.GetStartCell.Row);
            _isMoving = false;
        }

        #endregion


        #region Methods
        public void SetInputDirection(UnityEngine.Vector2 direction)
        {
            if (_isMoving)
                return;

            var t = _navigator.CalculateDestination(_unitModel.GetCoordinates, direction);
            if (t.direction != MoveDirection.None)
            {
                _isMoving = true;

                _unitModel.Destination = t.destination;
                _unitModel.ChangeDirection(t.direction);

                _unitView.SetSprite(_unitModel.GetSprite);
                _unitView.SetOrderInLayer(_unitModel.GetCoordinates.Row);
            }
        }

        #endregion


        #region IExecute

        public void Execute()
        {
            if (_isMoving)
            {
                _isMoving = _motor.Move(_unitModel, _unitView);
            }
        }

        #endregion
    }
}
