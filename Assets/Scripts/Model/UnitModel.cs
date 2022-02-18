using UnityEngine;


namespace BomberPig
{
    public sealed class UnitModel
    {
        #region Fields

        public Vector2 Position;
        public Vector2 Destination;

        private readonly Sprite _rightSprite;
        private readonly Sprite _leftSprite;
        private readonly Sprite _upSprite;
        private readonly Sprite _downSprite;
        private readonly float _speed;
        private Sprite _currentSprite;
        private CellCoordinatesModel _coordinates;

        #endregion


        #region Properties

        public Sprite GetSprite => _currentSprite;
        public CellCoordinatesModel GetCoordinates => _coordinates;
        public float GetSpeed => _speed;

        #endregion


        #region ClassLifeCycles

        public UnitModel(PlayerData data, Vector2 position)
        {
            _currentSprite = data.GetRightSprite;
            _currentSprite = data.GetRightSprite;
            _rightSprite = data.GetRightSprite;
            _leftSprite = data.GetLeftSprite;
            _upSprite = data.GetUpSprite;
            _downSprite = data.GetDownSprite;
            Position = position;
            Destination = position;
            _coordinates = data.GetStartCell;
            _speed = data.GetSpeed;
        }

        #endregion


        #region Methods

        public void ChangeDirection(MoveDirection moveDirection)
        {
            switch (moveDirection)
            {
                case MoveDirection.None:
                    break;
                case MoveDirection.Right:
                    _currentSprite = _rightSprite;
                    _coordinates.Column += 1;
                    break;
                case MoveDirection.Left:
                    _currentSprite = _leftSprite;
                    _coordinates.Column -= 1;
                    break;
                case MoveDirection.Up:
                    _currentSprite = _upSprite;
                    _coordinates.Row -= 1;
                    break;
                case MoveDirection.Down:
                    _currentSprite = _downSprite;
                    _coordinates.Row += 1;
                    break;
                default:
                    break;
            }
        }

        #endregion
    }
}
