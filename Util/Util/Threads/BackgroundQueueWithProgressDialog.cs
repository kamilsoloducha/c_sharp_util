using System.ComponentModel;
using System.Windows;
using Util.Threads;

namespace Util.Threads
{
    public class BackgroundQueueWithProgressDialog : BackgroundWorkQueue
    {
        public IProgressDialog Dialog { get; set; }

        public BackgroundQueueWithProgressDialog() : base()
        {
        }

        public override void Execute()
        {
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
            base.Abort();
            Dialog.Close();
        }

    }
}
