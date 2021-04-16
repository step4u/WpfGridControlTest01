using DevExpress.Mvvm;
using System;
using WpfGridControlTest01.ViewModels;

namespace WpfGridControlTest01.Models
{
    public class ProductType : BindableBase
    {

        public int Id {
            get { return GetValue<int>(); }
            set {
                SetValue(value);
                System.Diagnostics.Debug.WriteLine("set ProductType.Id: " + value);
            }
        }
        public string TypeName {
            get { return GetValue<string>(); }
            set {
                SetValue(value);
                System.Diagnostics.Debug.WriteLine("set ProductType.TypeName: " + value);
            }
        }

        public ProductType()
        {
        }
    }
}
