using UnityEngine;


namespace BomberPig
{
    public abstract class AUnitController : IExecute
    {
        #region Fields

        private readonly UnitModel _unitModel;
        private readonly UnitView _unitView;
        protected readonly IMapInfo _mapInfo;

        #endregion


        #region Properties

        public GameObject GetGameObject => _unitView.gameObject;
        protected UnitModel GetUnitModel => _unitModel;

        #endregion


        #region ClassLifeCycles

        public AUnitController(UnitModel unitModel, GameObject unitPrefab, IMapInfo mapInfo, IBuildUnit builder)
        {
            _mapInfo = mapInfo;
            _unitModel = unitModel;
            _unitView = builder.BuildPlayer(unitPrefab, _unitModel.Position);
            _unitView.SetOrderInLayer(_unitModel.GetCoordinates.Row);
        }

        #endregion


        #region Methods

        public void Restart(CellCoordinatesModel cellCoordinates)
        {
            _unitModel.Reset(cellCoordinates, _mapInfo.GetCellCenter(cellCoordinates));
            _unitView.SetPosition(_unitModel.Position);
            _unitView.SetSprite(_unitModel.GetSprite);
            _unitView.SetOrderInLayer(_unitModel.GetCoordinates.Row);
        }

        protected bool SetNewDirection(Vector2 direction)
        {
            if (_unitModel.IsMoving)
                return false;

            var t = _mapInfo.CalculateDestination(_unitModel.GetCoordinates, direction);
            if (t.direction != MoveDirection.None)
            {
                _unitModel.IsMoving = true;
                _unitModel.Destination = t.destination;
                _unitModel.ChangeCoordinates(t.direction);
                RefreshSprite();
                _unitView.SetOrderInLayer(_unitModel.GetCoordinates.Row);
            }

            return _unitModel.IsMoving;
        }

        protected void RefreshSprite()
        {
            _unitView.SetSprite(_unitModel.GetSprite);
        }

        protected abstract void BlownUp();

        #endregion


        #region IExecute

        public virtual void Execute()
        {
            if (_unitModel.IsMoving)
            {
                _unitModel.IsMoving = Services.Instance.UnitMotor.Move(_unitModel, _unitView);
                if (!_unitModel.IsMoving && _mapInfo.IsBomb(_unitModel.GetCoordinates))
                {
                    BlownUp();
                }
            }

        }

        #endregion
    }
}
