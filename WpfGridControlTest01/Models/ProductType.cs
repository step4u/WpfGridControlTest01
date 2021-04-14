using DevExpress.Mvvm;
using System;
using WpfGridControlTest01.ViewModels;

namespace WpfGridControlTest01.Models
{
    public class ProductType : BindableBase
    {

        public int Id {
            get { return GetValue<int>(); }
            set { SetValue(value); }
        }
        public string TypeName {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ProductType()
        {
        }

        public static implicit operator ProductType(MainViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
