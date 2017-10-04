using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Util.Tasks
{
    public class TaskQueue<T> where T : ITask
    {

        public LinkedList<T> Queue { get; private set; }

        public Action<bool> OnCompleted { get; set; }

        private volatile bool _isRunning;

        public TaskQueue()
        {
            Queue = new LinkedList<T>();
        }

        public Task Execute()
        {
            _isRunning = true;
            return Task.Run(() =>
            {
                while (Queue.Count >= 0)
                {
                    T task = Queue.First.Value;
                    bool result = task.Execute();
                    if (result && _isRunning)
                    {
                        Queue.RemoveFirst();
                        continue;
                    }
                    Abort(false);
                    return;
                }
                Abort(true);
            });
        }

        public void Cancel()
        {
            _isRunning = true;
        }

        private void Abort(bool success)
        {
            if (OnCompleted != null)
            {
                OnCompleted(false);
                
            }
            _isRunning = false;
        }
        
    }
}
