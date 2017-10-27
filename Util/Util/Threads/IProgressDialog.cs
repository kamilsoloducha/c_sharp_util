using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util.Threads
{
    public interface IProgressDialog
    {

        void Show();
        Action OnShow { get; set; }

        void Close();
        Action OnClose { get; set; }

    }
}
