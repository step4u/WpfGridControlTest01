using System;
using System.ComponentModel;
using WpfGridControlTest01.Classes;

namespace WpfGridControlTest01.Models
{
    public class Product : INotifyPropertyChanged, ICloneable
    {
        private DbCrud _dbcrud;
        private bool _chk1;
        private string _bandwide;
        private bool _chk2;
        private string _freq;

        public Product()
        {
            DBCrud = DbCrud.READ;
            Chk1 = false;
            BandWide = string.Empty;
            Chk2 = false;
            Freq = string.Empty;
        }

        public DbCrud DBCrud {
            get {
                return _dbcrud;
            }
            set {
                _dbcrud = value;
            }
        }

        public bool Chk1 {
            get { return _chk1; }
            set
            {
                _chk1 = value;
                OnPropertyChanged("Chk1");
                System.Diagnostics.Debug.WriteLine("set Chk1: " + value);
            }
        }

        public string BandWide {
            get { return _bandwide; }
            set
            {
                _bandwide = value;
                OnPropertyChanged("BandWide");
                System.Diagnostics.Debug.WriteLine("set BandWide: " + value);
            }
        }

        public bool Chk2 {
            get { return _chk2; }
            set
            {
                _chk2 = value;
                OnPropertyChanged("Chk2");
                System.Diagnostics.Debug.WriteLine("set Chk2: " + value);
            }
        }

        public string Freq {
            get { return _freq; }
            set
            {
                _freq = value;
                OnPropertyChanged("Freq");
                System.Diagnostics.Debug.WriteLine("set Freq: " + value);
            }
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public bool HasSameValues(Product other)
        {
            if (this.Chk1 != other.Chk1) return false;
            if (this.BandWide != other.BandWide) return false;
            if (this.Chk2 != other.Chk2) return false;
            if (this.Freq != other.Freq) return false;

            return true;
        }
    }
}
