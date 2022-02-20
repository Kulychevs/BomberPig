using System;
using System.Collections.Generic;


namespace BomberPig
{
    public sealed class TimerService : IExecute, IRestart
    {
        private class TimerElement
        {
            public float Time;
            public Action Action;
            public Action<float> TimeCallback;
        }

        private readonly List<TimerElement> _timers = new List<TimerElement>();


        public void Add(float time, Action action, Action<float> timeCallback)
        {
            var timerElement = new TimerElement
            {
                Time = time,
                Action = action,
                TimeCallback = timeCallback
            };
            _timers.Add(timerElement);
        }

        public void Execute()
        {
            for (int i = 0; i < _timers.Count; i++)
            {
                _timers[i].Time -= Services.Instance.TimeService.DeltaTime();
                _timers[i].TimeCallback?.Invoke(_timers[i].Time);
                if (_timers[i].Time < 0)
                {
                    _timers[i].Action.Invoke();
                    _timers.Remove(_timers[i]);
                    i--;
                }
            }
        }

        public void Restart()
        {
            _timers.Clear();
        }
    }
}
