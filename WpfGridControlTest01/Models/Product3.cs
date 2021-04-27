using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;
using WpfGridControlTest01.Classes;

namespace WpfGridControlTest01.Models
{
    public class Product3 : BindableBase
    {
        public Product3()
        {
        }

        bool _IsMine = false;
        public bool IsMine {
            get { return _IsMine; }
            set { SetValue(ref _IsMine, value); }
        }

        bool _Chk1;
        public bool Chk1 {
            get { return _Chk1; }
            set { SetValue(ref _Chk1, value); }
        }

        string _BandWide;
        public string BandWide {
            get { return _BandWide; }
            set { SetValue(ref _BandWide, value); }
        }

        bool _Chk2;
        public bool Chk2 {
            get { return _Chk2; }
            set { SetValue(ref _Chk2, value); }
        }

        string _Freq;
        public string Freq {
            get { return _Freq; }
            set { SetValue(ref _Freq, value); }
        }

        public T InputStruct<T>() where T : struct
        {
            T stuff = new T();
            var properties = this.GetType().GetProperties();
            foreach (var p in properties)
            {
                // var name0 = stuff.GetType().GetField("BandWide");
                // var name = stuff.GetType().GetField(p.Name).GetValue(stuff).GetType().Name;
                var name = stuff.GetType().GetField(p.Name).FieldType.Name;
                switch (name)
                {
                    case "Byte":
                        stuff.GetType().GetField(p.Name).SetValue(stuff, Convert.ToByte(p.GetValue(this)));
                        break;
                    case "Char[]":
                        var size = (stuff.GetType().GetField(p.Name).GetCustomAttributes(true)[0] as MarshalAsAttribute).SizeConst;
                        string str = p.GetValue(this).ToString();
                        char[] srcArr = str.ToCharArray();
                        char[] tmpArr = new char[size];
                        Array.Copy(srcArr, tmpArr, srcArr.Length);
                        stuff.GetType().GetField(p.Name).SetValue(stuff, tmpArr);
                        break;
                }
            }
            return stuff;
        }
    }
}
