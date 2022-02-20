using UnityEngine;
using UnityEngine.InputSystem;


namespace BomberPig
{
    public sealed class InputController : IExecute
    {
        private const float MIN_OFFSET = 0.2f;

        private readonly IPlayer _player;
        private readonly PlayerInputActions _inputActions;

        public InputController(IPlayer player)
        {
            _player = player;
            _inputActions = new PlayerInputActions();
            _inputActions.Enable();
            _inputActions.Player.SetBomb.performed += InputOnSetBomb;
        }

        private void InputOnSetBomb(InputAction.CallbackContext obj)
        {
            _player.SetBomb();
        }

        public void Execute()
        {
            var move = _inputActions.Player.Move.ReadValue<Vector2>();
            if (Mathf.Abs(move.x) > MIN_OFFSET || Mathf.Abs(move.y) > MIN_OFFSET)
            {
                _player.SetInputDirection(move);
            }
        }
    }
}
