using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGridControlTest01.Classes
{
    public class JobFinishedEventArgs : EventArgs
    {
        public string ErrCode { get; set; }
        public string Message { get; set; }
    }
}
