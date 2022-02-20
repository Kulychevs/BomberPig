namespace BomberPig
{
    public sealed class Controllers
    {
        #region Fields

        private readonly IExecute[] _executeControllers;

        #endregion


        #region Properties

        public int Length => _executeControllers.Length;
        public IExecute this[int index] => _executeControllers[index];

        #endregion


        #region ClassLyfeCycles

        public Controllers(GameSettings settings)
        {
            var mapController = new MapController(settings.GetMapData, new BombBuilder(settings.getBombPrefab));
            var playerController = new PlayerController(settings.GetPlayerData, mapController);
            var inputController = new InputController(playerController);
            var enemiesController = new EnemiesController(settings.GetEnemiesData, mapController);
            var uiController = new UIController();

            _executeControllers = new IExecute[]
            {
                playerController,
                inputController,
                enemiesController,
                Services.Instance.TimerService
            };

            var restartControllers = new IRestart[]
            {
                playerController,
                mapController,
                enemiesController,
                Services.Instance.TimerService
            };

            var restartController = new RestartController(restartControllers);

            playerController.OnBlownUp += uiController.ActivateEndGamePanel;
            playerController.OnBombTimeUpdate += uiController.ShowBombCooldownTime;
            enemiesController.OnEnemyCatchPig += uiController.ActivateEndGamePanel;
            enemiesController.OnEnemyBlownUp += uiController.ShowScoretext;
            uiController.OnRestart += restartController.MakeRestart;
        }

        #endregion
    }
}

