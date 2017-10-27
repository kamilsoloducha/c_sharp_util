using System;
using System.ComponentModel;
using System.Windows;
using Util.Threads;

namespace Wordki.Helpers
{
    public class BackgroundQueueWithProgressDialog : BackgroundWorkQueue
    {
        private bool _isRunning;
        public IProgressDialog Dialog { get; set; }

        public BackgroundQueueWithProgressDialog() : base()
        {
        }

        public override void Execute()
        {
            Dialog.OnClose = Abort;
            _isRunning = true;
            base.Execute();
            Dialog.Show();
        }

        protected override void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            base.worker_DoWork(sender, e);
            Application.Current.Dispatcher.Invoke(() => Dialog.Close());
        }

        public override void Abort()
        {
            Console.WriteLine("Before abort");
            if (_isRunning)
            {
                _isRunning = false;
                base.Abort();
                Console.WriteLine("Abort");
                Dialog.Close();
            }
        }

    }
}
