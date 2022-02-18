using UnityEngine.InputSystem;


namespace BomberPig
{
    public sealed class InputController : IExecute
    {
        private const float MIN_OFFSET = 0.2f;

        private readonly IPlayer _player;

        public InputController(IPlayer player)
        {
            _player = player;
        }

        public void Execute()
        {
            var gamepad = Gamepad.current;
            if (gamepad == null)
                return;

            var move = gamepad.leftStick.ReadValue();
            if (System.Math.Abs(move.x) > MIN_OFFSET || System.Math.Abs(move.y) > MIN_OFFSET)
                _player.SetInputDirection(move);
        }
    }
}
