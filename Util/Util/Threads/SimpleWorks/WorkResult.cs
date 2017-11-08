using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Threads
{
    public class WorkResult
    {

        public object Result { get; set; }
        public bool Success { get; set; }

        public WorkResult()
        {
            Success = false;
            Result = null;
        }

    }
}
