using UnityEngine;

namespace BomberPig
{
    public sealed class EnemyModel : UnitModel
    {
        [SerializeField] private Sprite _dirtyLeft;
        [SerializeField] private Sprite _dirtyRight;
        [SerializeField] private Sprite _dirtyUp;
        [SerializeField] private Sprite _dirtyDown;
        [SerializeField] private float _waitTime;

        public EnemyModel(EnemyData data, Vector2 position) : base(data, position)
        {
            _dirtyLeft = data.GetDirtyLeftSprite;
            _dirtyRight = data.GetDirtyRightSprite;
            _dirtyUp = data.GetDirtyUpSprite;
            _dirtyDown = data.GetDirtyDownSprite;
        }

        public float GetWaitTime => _waitTime;

        public void SetDirtySprite()
        {
            _leftSprite = _dirtyLeft;
            _rightSprite = _dirtyRight;
            _upSprite = _dirtyUp;
            _downSprite = _dirtyDown;

            ChangeDirection(_moveDirection);
        }
    }
}
