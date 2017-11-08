using System;

namespace Util.Threads
{
    public class SimpleWork : IWork
    {
        public Func<WorkResult> WorkFunc { get; set; }
        public Func<bool> InitializeFunc { get; set; }
        public Action OnCanceledFunc { get; set; }
        public Action OnCompletedFunc { get; set; }
        public Action OnFailedFunc { get; set; }

        public WorkResult Result { get; set; }


        public bool Execute()
        {
            if(WorkFunc == null)
            {
                return false;
            }
            Result = WorkFunc.Invoke();
            return Result != null && Result.Success;
        }

        public bool Initialize()
        {
            if (InitializeFunc == null)
            {
                return true;
            }
            return InitializeFunc.Invoke();
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
