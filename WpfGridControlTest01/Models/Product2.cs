using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

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

        //List<ProductType> _ProductTypes;
        //public List<ProductType> ProductTypes {
        //    get { return _ProductTypes; }
        //    set { SetValue(ref _ProductTypes, value); }
        //}

        ProductType _SelectedProdcutType;
        public ProductType SelectedProdcutType {
            get { return _SelectedProdcutType; }
            set { SetValue(ref _SelectedProdcutType, value); }
        }

        //int _SelectedProdcutTypeId;
        //public int SelectedProdcutTypeId {
        //    get { return _SelectedProdcutTypeId; }
        //    set { SetValue(ref _SelectedProdcutTypeId, value); }
        //}

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            var properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var itm = this.GetType().GetProperty(property.Name).GetValue(this);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} : {1}", property.Name, itm));
            }

            return base.ToString();
        }

        public void SetValues(string propertyName, object value)
        {
            this.GetType().GetProperty(propertyName).SetValue(this, value);
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
