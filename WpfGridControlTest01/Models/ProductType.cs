using DevExpress.Mvvm;

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
    }
}
