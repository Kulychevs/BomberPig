using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(PlayerData), menuName = "Data/" + nameof(PlayerData), order = 3)]
    public class PlayerData : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Sprite _left;
        [SerializeField] private Sprite _right;
        [SerializeField] private Sprite _up;
        [SerializeField] private Sprite _down;
        [SerializeField] private float _speed;
        [SerializeField] private CellCoordinatesModel _startCell;


        public GameObject GetPrefab => _prefab;
        public Sprite GetLeftSprite => _left;
        public Sprite GetRightSprite => _right;
        public Sprite GetUpSprite => _up;
        public Sprite GetDownSprite => _down;
        public float GetSpeed => _speed;
        public CellCoordinatesModel GetStartCell => _startCell;
    }
}
