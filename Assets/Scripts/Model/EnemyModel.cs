using UnityEngine;

namespace BomberPig
{
    public sealed class EnemyModel : UnitModel
    {
        #region Fields

        public bool IsWaiting;

        private readonly Sprite _dirtyLeft;
        private readonly Sprite _dirtyRight;
        private readonly Sprite _dirtyUp;
        private readonly Sprite _dirtyDown;
        private readonly float _waitTime;
        private bool _isBlownUp;

        #endregion


        #region Properties

        public bool IsBlownUp
        {
            get => _isBlownUp;
            set { _isBlownUp = value; UpdateSprite(); }
        }
        public float GetWaitTime => _waitTime;
        protected override Sprite GetRightSprite => IsBlownUp ? _dirtyRight : _rightSprite;
        protected override Sprite GetLeftSprite => IsBlownUp ? _dirtyLeft : _leftSprite;
        protected override Sprite GetUpSprite => IsBlownUp ? _dirtyUp : _upSprite;
        protected override Sprite GetDownSprite => IsBlownUp ? _dirtyDown : _downSprite;

        #endregion


        #region ClassLifeCycles

        public EnemyModel(EnemyData data, CellCoordinatesModel startCell, Vector2 position) : 
            base(data, startCell, position)
        {
            _dirtyLeft = data.GetDirtyLeftSprite;
            _dirtyRight = data.GetDirtyRightSprite;
            _dirtyUp = data.GetDirtyUpSprite;
            _dirtyDown = data.GetDirtyDownSprite;
            _waitTime = data.GetWaitTime;
        }

        #endregion


        #region Methods

        private void Initialization()
        {
            IsWaiting = false;
            _isBlownUp = false;
        }

        public override void Reset(CellCoordinatesModel cellCoordinates, Vector2 position)
        {
            base.Reset(cellCoordinates, position);
            Initialization();
        }

        #endregion
    }
}
