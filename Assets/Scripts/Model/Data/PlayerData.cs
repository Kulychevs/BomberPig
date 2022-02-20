using UnityEngine;


namespace BomberPig
{
    [CreateAssetMenu(fileName = nameof(PlayerData), menuName = "Data/" + nameof(PlayerData), order = 3)]
    public sealed class PlayerData : UnitData
    {
        [SerializeField] private CellCoordinatesModel _startCell;
        [SerializeField] private float _bombCooldownTime;

        public CellCoordinatesModel GetStartCell => _startCell;
        public float GetBombCoolDownTime => _bombCooldownTime;
    }
}
