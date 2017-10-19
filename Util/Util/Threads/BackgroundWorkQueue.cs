using System;
using System.Collections.Generic;
using System.Windows;

namespace Util.Threads
{
    public class BackgroundWorkQueue : IWorkQueue
    {

        protected AbortableBackgroundWorker Worker { get; set; }
        protected LinkedList<IWork> MainList { get; set; }

        public Action OnCompleted { get; set; }
        public Action OnCanceled { get; set; }
        public Action OnFailed { get; set; }


        public BackgroundWorkQueue()
        {
            MainList = new LinkedList<IWork>();
            Worker = new AbortableBackgroundWorker();
            Worker.DoWork += worker_DoWork;
        }

        protected void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while(MainList.Count > 0)
            {
                IWork work = MainList.First.Value;
                if (!work.Initialize())
                {
                    work.OnFailed();
                    RunOnFailed();
                    return;
                }
                if (!work.Execute())
                {
                    work.OnFailed();
                    RunOnFailed();
                    return;
                }
                work.OnCompleted();
                MainList.RemoveFirst();
            }
            if(MainList.Count == 0)
            {
                RunOnCompleted();
            }
        }

        public void Abort()
        {
            Worker.Abort();
            RunOnCanceled();
        }

        public void Execute()
        {
            Worker.RunWorkerAsync();
        }

        public void AddWork(IWork work)
        {
            MainList.AddLast(work);
        }

        private void RunOnFailed()
        {
            if (OnFailed != null)
            {
                OnFailed.Invoke();
            }
        }

        private void RunOnCompleted()
        {
            if (OnCompleted != null)
            {
                OnCompleted.Invoke();
            }
        }

        private void RunOnCanceled()
        {
            if (OnCanceled != null)
            {
                OnCanceled.Invoke();
            }
        }
    }
}
