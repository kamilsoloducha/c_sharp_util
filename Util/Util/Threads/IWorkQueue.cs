using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Threads
{
    public interface IWorkQueue
    {

        void Execute();

        void Abort();

        void AddWork(IWork work);

    }
}
