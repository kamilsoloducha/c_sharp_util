using System.ComponentModel;
using System.Threading;

namespace Util.Threads
{
    public class AbortableBackgroundWorker : BackgroundWorker
    {

        private Thread _workerThread;

        protected override void OnDoWork(DoWorkEventArgs e)
        {
            _workerThread = Thread.CurrentThread;
            try
            {
                base.OnDoWork(e);
            }
            catch (ThreadAbortException)
            {
                e.Cancel = true;
                Thread.ResetAbort();
            }
        }

        public void Abort()
        {
            if (_workerThread != null)
            {
                System.Console.WriteLine("Abort thread");
                _workerThread.Abort();
                _workerThread = null;
            }
        }
    }
}
