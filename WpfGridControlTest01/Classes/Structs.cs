using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfGridControlTest01.Classes
{
    //public class Structs
    //{
    //}

    // [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, CharSet = CharSet.Auto, Size = 76)]
    [StructLayoutAttribute(LayoutKind.Sequential, Pack = 1, Size = 36)]
    public struct StTest01
    {
        public byte IsMine;
        public byte Chk1;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public char[] BandWide;
        public byte Chk2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public char[] Freq;
    }
}
