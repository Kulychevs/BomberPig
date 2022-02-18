using System;


namespace BomberPig
{
    public sealed class Services
    {
        #region Fields

        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        #endregion


        #region ClassLifeCycles

        public Services()
        {
            Initialize();
        }

        #endregion


        #region Properties

        public static Services Instance => _instance.Value;
        public ITimeService TimeService { get; private set; }
        public TimerService TimerService { get; private set; }

        #endregion


        #region Methods

        private void Initialize()
        {
            TimeService = new UnityTimeService();
            TimerService = new TimerService();
        }

        #endregion
    }
}
