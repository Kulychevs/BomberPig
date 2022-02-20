using UnityEngine;


namespace BomberPig
{
    public sealed class PlayerModel : UnitModel
    {
        public bool IsBompSet;
        private readonly CellCoordinatesModel _startCell;
        private readonly float _bombCooldownTime;

        public CellCoordinatesModel GetStartCell => _startCell;
        public float GetBombCoolDownTime => _bombCooldownTime;


        public PlayerModel(PlayerData data, Vector2 position) : base(data, data.GetStartCell, position)
        {
            _startCell = data.GetStartCell;
            _bombCooldownTime = data.GetBombCoolDownTime;
            Initialization();
        }

        private void Initialization()
        {
            IsBompSet = false;
        }

        public override void Reset(CellCoordinatesModel cellCoordinates, Vector2 position)
        {
            base.Reset(cellCoordinates, position);
            Initialization();
        }
    }
}
