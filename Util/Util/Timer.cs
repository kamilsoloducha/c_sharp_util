using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Util
{
    [Serializable]
    public class Timer
    {

        [NonSerialized]
        private List<ITimerListener> _timerListener;
        public List<ITimerListener> TimerListeners
        {
            get { return _timerListener; }
        }

        public bool IsRunning { get; private set; }
        public int Ticks { get; private set; }

        [NonSerialized]
        private System.Timers.Timer _timer;

        public Timer()
        {
            _timerListener = new List<ITimerListener>();
            _timer = new System.Timers.Timer();
            Ticks = 0;
        }

        [OnDeserialized]
        internal void OnDeserializedMethod(StreamingContext context)
        {
            _timerListener = new List<ITimerListener>();
            _timer = new System.Timers.Timer();
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            Ticks++;
            UpdateListeners(Ticks);
        }

        public void StartTimer()
        {
            _timer.Elapsed += OnTimeEvent;
            _timer.Interval = 1000;
            _timer.Enabled = true;
            _timer.Start();
            IsRunning = true;
        }

        public int StopTimer()
        {
            _timer.Stop();
            IsRunning = false;
            return GetTime();
        }

        public void Pause()
        {
            _timer.Stop();
            IsRunning = false;
        }

        public void Resume()
        {
            _timer.Start();
            IsRunning = true;
        }

        public int GetTime()
        {
            return Ticks;
        }

        private void UpdateListeners(int lTicks)
        {
            foreach (ITimerListener lTimerListener in _timerListener)
            {
                lTimerListener.OnTimerTick(lTicks);
            }
        }

        public static long GetMilis()
        {
            return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        }

        public interface ITimerListener
        {
            void OnTimerTick(int lTicks);
        }
    }
}
