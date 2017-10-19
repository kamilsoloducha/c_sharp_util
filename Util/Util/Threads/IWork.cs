using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Threads
{
    public interface IWork
    {

        bool Initialize();

        bool Execute();

        void OnCompleted();

        void OnFailed();

        void OnCanceled();

    }
}
