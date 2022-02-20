namespace BomberPig
{
    public sealed class UnitMotorService : IUnitMotor
    {
        private const float MAX_RANGE = 0.15f;


        public bool Move(UnitModel model, UnitView view)
        {
            var speedVector = (model.Destination - model.Position).normalized * model.GetSpeed;
            model.Position += speedVector * UnityEngine.Time.deltaTime;

            if ((model.Destination - model.Position).sqrMagnitude > MAX_RANGE * MAX_RANGE)
            {
                view.SetPosition(model.Position);
                return true;
            }

            return false;
        }
    }
}
