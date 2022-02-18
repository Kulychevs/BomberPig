using System;
using System.Collections.Generic;


namespace BomberPig
{
    public sealed class TimerService : IExecute
    {
        private class TimerElement
        {
            public float Time;
            public Action Action;
        }

        private readonly List<TimerElement> _timers = new List<TimerElement>();


        public void Add(float time, Action action)
        {
            var timerElement = new TimerElement
            {
                Time = time,
                Action = action
            };
            _timers.Add(timerElement);
        }

        public void Execute()
        {
            foreach (var timer in _timers)
            {
                timer.Time -= Services.Instance.TimeService.DeltaTime();
                if (timer.Time < 0)
                {
                    timer.Action.Invoke();
                    _timers.Remove(timer);
                    break;
                }
            }
        }
    }
}
