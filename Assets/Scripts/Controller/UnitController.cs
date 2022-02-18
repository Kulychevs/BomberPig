using UnityEngine;


namespace BomberPig
{
    public abstract class UnitController : IExecute
    {
        #region Fields

        private readonly INavigator _navigator;
        private readonly IUnitMotor _motor;
        protected UnitModel _unitModel;
        protected UnitView _unitView;
        protected readonly IMapInfo _mapInfo;
        protected bool _isMoving;

        #endregion


        #region ClassLifeCycles

        public UnitController(PlayerData data, IBuildPlayer builder, IMapInfo mapInfo, INavigator navigator, IUnitMotor motor)
        {
            _mapInfo = mapInfo;
            _navigator = navigator;
            _motor = motor;
            if (data != null)
            {
                _unitModel = new UnitModel(data, _mapInfo.GetCellCenter(data.GetStartCell));
                _unitView = builder.BuildPlayer(data.GetPrefab, _unitModel.Position);
                _unitView.SetOrderInLayer(data.GetStartCell.Row);
            }
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

        protected abstract void BlownUp();

        #endregion


        #region IExecute

        public virtual void Execute()
        {
            if (_isMoving)
            {
                _isMoving = _motor.Move(_unitModel, _unitView);
                if (!_isMoving && _mapInfo.IsBomb(_unitModel.GetCoordinates))
                {
                    BlownUp();
                }
            }

        }

        #endregion
    }
}
