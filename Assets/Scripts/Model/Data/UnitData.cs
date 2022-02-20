using UnityEngine;


namespace BomberPig
{
    public class UnitData : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Sprite _left;
        [SerializeField] private Sprite _right;
        [SerializeField] private Sprite _up;
        [SerializeField] private Sprite _down;
        [SerializeField] private float _speed;


        public GameObject GetPrefab => _prefab;
        public Sprite GetLeftSprite => _left;
        public Sprite GetRightSprite => _right;
        public Sprite GetUpSprite => _up;
        public Sprite GetDownSprite => _down;
        public float GetSpeed => _speed;
    }
}
