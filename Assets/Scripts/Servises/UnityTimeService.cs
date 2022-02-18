using UnityEngine;
 

namespace BomberPig
{
    public sealed class UnityTimeService : ITimeService
    {
        #region Fields

        private int _deltaTimeResetFrame;

        #endregion


        #region Methods
        
        public float DeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.deltaTime;
        public float UnscaledDeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.unscaledDeltaTime;
        public float FixedDeltaTime() => _deltaTimeResetFrame == Time.frameCount ? 0.0f : Time.fixedDeltaTime;
        public float RealtimeSinceStartup() => Time.realtimeSinceStartup;
        public float GameTime() => Time.time;
        public void SetTimeScale(float timeScale) => Time.timeScale = timeScale;
        public void ResetDeltaTime() => _deltaTimeResetFrame = Time.frameCount;

        #endregion
    }
}
