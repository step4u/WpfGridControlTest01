using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using WpfGridControlTest01.Models;

namespace WpfGridControlTest01.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ShowMessageCommand { get; private set; }
        IMessageBoxService MessageBoxService { get { return GetService<IMessageBoxService>(); } }

        public bool EnableBtnAdd {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool EnableBtnDel {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool EnableBtnReload {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool EnableBtnApply {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }
        public bool EnableBtnModify {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public string BtnAdd {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string BtnDel {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string BtnReload {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string BtnApply {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string BtnModify {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TimerSec {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public MainViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage);

            InitData();
            InitProperties();
            InitTimer();
        }

        public ObservableCollection<Product> Products {
            get { return GetValue<ObservableCollection<Product>>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<Product1> Products1 {
            get { return GetValue<ObservableCollection<Product1>>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<Product2> Products2 {
            get { return GetValue<ObservableCollection<Product2>>(); }
            set { SetValue(value); }
        }
        public Product2 SelectedProduct {
            get { return GetValue<Product2>(); }
            set { SetValue(value); }
        }

        void ShowMessage()
        {
            MessageBoxService.Show("This is MainView!");
        }

        void InitData()
        {
            if (IsInDesignMode)
            {
                Products = new ObservableCollection<Product>();
                Products1 = new ObservableCollection<Product1>();
                Products2 = new ObservableCollection<Product2>();
            }
            else
            {
                Products = new ObservableCollection<Product>();
                Products1 = new ObservableCollection<Product1>();
                Products2 = new ObservableCollection<Product2>();
                // SelectProductType = new Product2();

                for (int i = 1; i <= 5; i++)
                {
                    Products.Add(new Product()
                    {
                        BandWide = string.Format("{0}00", i),
                        Freq = string.Format("{0}000", i),
                        Chk1 = true,
                        Chk2 = false
                    });
                }

                for (int i = 3; i <= 7; i++)
                {
                    Products1.Add(new Product1()
                    {
                        BandWide = string.Format("{0}00", i),
                        Freq = string.Format("{0}000", i),
                        Chk1 = true,
                        Chk2 = false
                    });
                }

                List<ProductType> productTypes = new List<ProductType>()
                {
                    new ProductType() {
                        Id = 1,
                        TypeName = "Type1"
                    },
                    new ProductType() {
                        Id = 2,
                        TypeName = "Type2"
                    },
                    new ProductType() {
                        Id = 3,
                        TypeName = "Type3"
                    },
                    new ProductType() {
                        Id = 4,
                        TypeName = "Type4"
                    }
                };

                for (int i = 5; i <= 9; i++)
                {
                    Products2.Add(new Product2()
                    {
                        BandWide = string.Format("{0}00", i),
                        Freq = string.Format("{0}000", i),
                        Chk1 = true,
                        Chk2 = false,
                        ProductTypes = productTypes,
                        SelectedProdcutType = productTypes[0],
                        SelectedProdcutTypeId = 0
                    });
                }
            }
        }

        void InitProperties()
        {
            BtnAdd = "추가";
            BtnDel = "삭제";
            BtnReload = "갱신";
            BtnModify = "수정";
            BtnApply = "적용";
            EnableBtnAdd = true;
            EnableBtnDel = true;
            EnableBtnReload = true;
            EnableBtnApply = false;
            EnableBtnModify = true;
        }

        private System.Timers.Timer timer;
        private int count = 0;
        void InitTimer()
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            count++;
            TimerSec = count.ToString();
        }
    }
}