using DevExpress.Mvvm;
using System;

namespace WpfGridControlTest01.Models
{
    public class Product2 : BindableBase, ICloneable
    {
        public Product2()
        {

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

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool HasSameValues(Product2 other)
        {
            if (this.Chk1 != other.Chk1) return false;
            if (this.BandWide != other.BandWide) return false;
            if (this.Chk2 != other.Chk2) return false;
            if (this.Freq != other.Freq) return false;

            return true;
        }
    }
}
