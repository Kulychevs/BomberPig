using UnityEngine;


namespace BomberPig
{
    public interface IUnitMotor
    {
        public bool Move(UnitModel model, UnitView view);
    }
}
