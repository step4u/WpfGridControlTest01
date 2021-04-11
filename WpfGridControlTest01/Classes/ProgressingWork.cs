using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGridControlTest01.Classes
{
    public class ProgressingWork
    {
        public delegate void AddingEventHandler(object sender, EventArgs e);
        public event AddingEventHandler OnAdding;


    }
}
