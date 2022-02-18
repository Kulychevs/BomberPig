﻿namespace BomberPig
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
            var mapController = new MapController(settings.GetMapData);
            var playerController = new PlayerController(settings.GetPlayerData, new PlayerBuilder(), 
                                                        mapController, new Navigator(mapController), new UnitMotor());
            var inputController = new InputController(playerController);


            _executeControllers = new IExecute[]
            {
                playerController,
                inputController
            };
        }

        #endregion
    }
}

