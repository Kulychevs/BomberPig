using UnityEngine;


namespace BomberPig
{
    public class UnitModel
    {
        #region Fields

        public Vector2 Position;
        public Vector2 Destination;
        public bool IsMoving;

        protected readonly Sprite _rightSprite;
        protected readonly Sprite _leftSprite;
        protected readonly Sprite _upSprite;
        protected readonly Sprite _downSprite;
        protected MoveDirection _moveDirection;
        private readonly float _speed;
        private Sprite _currentSprite;
        private CellCoordinatesModel _coordinates;

        #endregion


        #region Properties

        public Sprite GetSprite => _currentSprite;
        public CellCoordinatesModel GetCoordinates => _coordinates;
        public float GetSpeed => _speed;

        protected virtual Sprite GetRightSprite => _rightSprite;
        protected virtual Sprite GetLeftSprite => _leftSprite;
        protected virtual Sprite GetUpSprite => _upSprite;
        protected virtual Sprite GetDownSprite => _downSprite;

        #endregion


        #region ClassLifeCycles

        public UnitModel(UnitData data, CellCoordinatesModel startCell, Vector2 position)
        {
            _rightSprite = data.GetRightSprite;
            _leftSprite = data.GetLeftSprite;
            _upSprite = data.GetUpSprite;
            _downSprite = data.GetDownSprite;
            _speed = data.GetSpeed;

            Initialization(startCell, position);
        }

        #endregion


        #region Methods

        public virtual void Reset(CellCoordinatesModel cellCoordinates, Vector2 position)
        {
            Initialization(cellCoordinates, position);
        }

        public void ChangeCoordinates(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.None:
                    break;
                case MoveDirection.Right:
                    _currentSprite = GetRightSprite;
                    _coordinates.Column += 1;
                    break;
                case MoveDirection.Left:
                    _currentSprite = GetLeftSprite;
                    _coordinates.Column -= 1;
                    break;
                case MoveDirection.Up:
                    _currentSprite = GetUpSprite;
                    _coordinates.Row -= 1;
                    break;
                case MoveDirection.Down:
                    _currentSprite = GetDownSprite;
                    _coordinates.Row += 1;
                    break;
                default:
                    break;
            }
            _moveDirection = moveDirection;
        }

        protected void UpdateSprite()
        {
            switch (_moveDirection)
            {
                case MoveDirection.None:
                    break;
                case MoveDirection.Right:
                    _currentSprite = GetRightSprite;
                    break;
                case MoveDirection.Left:
                    _currentSprite = GetLeftSprite;
                    break;
                case MoveDirection.Up:
                    _currentSprite = GetUpSprite;
                    break;
                case MoveDirection.Down:
                    _currentSprite = GetDownSprite;
                    break;
                default:
                    break;
            }
        }

        private void Initialization(CellCoordinatesModel cellCoordinates, Vector2 position)
        {
            Position = position;
            Destination = position;
            IsMoving = false;
            _currentSprite = GetRightSprite;
            _moveDirection = MoveDirection.Right;
            _coordinates = cellCoordinates;
        }

        #endregion
    }
}
