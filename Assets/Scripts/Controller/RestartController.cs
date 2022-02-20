namespace BomberPig
{
    public sealed class RestartController
    {
        private readonly IRestart[] _restartControllers;
        public RestartController(IRestart [] restartControllesr)
        {
            _restartControllers = restartControllesr;
        }

        public void MakeRestart()
        {
            foreach (var controller in _restartControllers)
            {
                controller.Restart();
            }
        }
    }
}
