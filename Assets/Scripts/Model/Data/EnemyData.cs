using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(EnemyData), menuName = "Data/" + nameof(EnemyData), order = 4)]
    public sealed class EnemyData : PlayerData
    {
        [SerializeField] private Sprite _dirtyLeft;
        [SerializeField] private Sprite _dirtyRight;
        [SerializeField] private Sprite _dirtyUp;
        [SerializeField] private Sprite _dirtyDown;
        [SerializeField] private float _waitTime;


        public Sprite GetDirtyLeftSprite => _dirtyLeft;
        public Sprite GetDirtyRightSprite => _dirtyRight;
        public Sprite GetDirtyUpSprite => _dirtyUp;
        public Sprite GetDirtyDownSprite => _dirtyDown;
        public float GetWaitTime => _waitTime;
    }
}
