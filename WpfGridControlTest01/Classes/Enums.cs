﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfGridControlTest01.Classes
{
    public enum DbCrud
    {
        CREATE = 0,
        UPDATE = 1,
        READ = 3,
        DELETE = 4
    }

    public enum ProgressingJob
    {
        IDLE = 0,
        READ = 1,
        ADD = 2,
        UPDATE = 3,
        DELETE = 4
    }
}
