using System;
using System.Threading.Tasks;

namespace Util.Threads
{
    public class SimpleAsyncWork : IWork
    {

        public Func<Task<bool>> WorkFunc { get; set; }
        public Func<Task<bool>> InitializeFunc { get; set; }
        public Func<Task> OnCanceledFunc { get; set; }
        public Func<Task> OnCompletedFunc { get; set; }
        public Func<Task> OnFailedFunc { get; set; }

        public bool Execute()
        {
            if(WorkFunc == null)
            {
                return false;
            }
            return WorkFunc.Invoke().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public bool Initialize()
        {
            if (InitializeFunc == null)
            {
                return true;
            }
            return InitializeFunc.Invoke().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public void OnCanceled()
        {
            if(OnCanceledFunc == null)
            {
                return;
            }
            OnCanceledFunc.Invoke();
        }

        public void OnCompleted()
        {
            if (OnCompletedFunc == null)
            {
                return;
            }
            OnCompletedFunc.Invoke();
        }

        public void OnFailed()
        {
            if (OnFailedFunc == null)
            {
                return;
            }
            OnFailedFunc.Invoke();
        }
    }
}
