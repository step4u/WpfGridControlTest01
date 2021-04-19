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

        ProductType _SelectedProdcutType;
        public ProductType SelectedProdcutType {
            get { return _SelectedProdcutType; }
            set {
                SetValue(ref _SelectedProdcutType, value);
                System.Diagnostics.Debug.WriteLine(string.Format("set SelectedProdcutType: Id={0} TypeName={1}", value.Id, value.TypeName));
            }
        }

        int _SelectedProdcutId = 3;
        public int SelectedProdcutId {
            get { return _SelectedProdcutId; }
            set {
                SetValue(ref _SelectedProdcutId, value);
                System.Diagnostics.Debug.WriteLine(string.Format("set SelectedProdcutId: Id={0}", value));
            }
        }

        string _SelectedMode = "다라마";
        public string SelectedMode {
            get { return _SelectedMode; }
            set {
                SetValue(ref _SelectedMode, value);
                System.Diagnostics.Debug.WriteLine(string.Format("set SelectedMode: {0}", value));
            }
        }

        int _SelectedModeIdx = 2;
        public int SelectedModeIdx {
            get { return _SelectedModeIdx; }
            set {
                SetValue(ref _SelectedModeIdx, value);
                System.Diagnostics.Debug.WriteLine(string.Format("set SelectedModeIdx: {0}", value));
            }
        }

        int _SelectedCate = 0;
        public int SelectedCate {
            get { return _SelectedCate; }
            set {
                SetValue(ref _SelectedCate, value);
                System.Diagnostics.Debug.WriteLine("set SelectedCate");
            }
        }

        string _SelectedCate2 = "123";
        public string SelectedCate2 {
            get { return _SelectedCate2; }
            set {
                SetValue(ref _SelectedCate2, value);
                System.Diagnostics.Debug.WriteLine("set SelectedCate2");
            }
        }

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
                System.Diagnostics.Debug.Write(string.Format("\t{0} : {1}", property.Name, itm));
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
