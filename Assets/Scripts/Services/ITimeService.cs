namespace BomberPig
{
    public interface ITimeService
    {
        float DeltaTime();
        float UnscaledDeltaTime();
        float FixedDeltaTime();
        float RealtimeSinceStartup();
        float GameTime();
        void SetTimeScale(float timeScale);
        void ResetDeltaTime();
    }
}
