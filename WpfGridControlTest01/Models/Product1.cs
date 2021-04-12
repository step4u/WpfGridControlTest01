using DevExpress.Mvvm;
using System;

namespace WpfGridControlTest01.Models
{
    public class Product1 : ViewModelBase, ICloneable
    {
        public Product1()
        {

        }
        public bool Chk1 {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public string BandWide {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public bool Chk2 {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public string Freq {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool HasSameValues(Product1 other)
        {
            if (this.Chk1 != other.Chk1) return false;
            if (this.BandWide != other.BandWide) return false;
            if (this.Chk2 != other.Chk2) return false;
            if (this.Freq != other.Freq) return false;

            return true;
        }
    }
}
