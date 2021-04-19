using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using WpfGridControlTest01.Classes;
using WpfGridControlTest01.Models;

namespace WpfGridControlTest01.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string MyId = "ATW";
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

        public ObservableCollection<ProductType> ProductTypes {
            get { return GetValue<ObservableCollection<ProductType>>(); }
            set { SetValue(value); }
        }

        string[] _Modes = new string[] { "가나다", "라마바", "사아자", "차카타", "파하" };
        public string[] Modes {
            get { return _Modes; }
            set {
                SetValue(ref _Modes, value);
                System.Diagnostics.Debug.WriteLine("set Mode");
            }
        }

        Dictionary<int, string> _Cates = new Dictionary<int, string>() { { 0,"ABCD" }, { 1,"EFGH"}, {2,"IJKL"}, { 3, "MNOP" }, { 4, "QRST" }, {5, "UVWX" }, { 6, "YZAB" } };
        public Dictionary<int, string> Cates {
            get { return _Cates; }
            set { SetValue(ref _Cates, value); }
        }

        List<string> _Cates2 = new List<string>() { "123", "234", "345", "456", "789", "890" };
        public List<string> Cates2 {
            get { return _Cates2; }
            set { SetValue(ref _Cates2, value); }
        }

        void ShowMessage()
        {
            MessageBoxService.Show("This is MainView!");
            
        }

        void InitData()
        {
            if (IsInDesignMode)
            {
                //Products = new ObservableCollection<Product>();
                //Products1 = new ObservableCollection<Product1>();
                Products2 = new ObservableCollection<Product2>();
            }
            else
            {
                //Products = new ObservableCollection<Product>();
                //Products1 = new ObservableCollection<Product1>();
                Products2 = new ObservableCollection<Product2>();
                // SelectProductType = new Product2();

                //for (int i = 1; i <= 5; i++)
                //{
                //    Products.Add(new Product()
                //    {
                //        BandWide = string.Format("{0}00", i),
                //        Freq = string.Format("{0}000", i),
                //        Chk1 = true,
                //        Chk2 = false
                //    });
                //}

                //for (int i = 3; i <= 7; i++)
                //{
                //    Products1.Add(new Product1()
                //    {
                //        BandWide = string.Format("{0}00", i),
                //        Freq = string.Format("{0}000", i),
                //        Chk1 = true,
                //        Chk2 = false
                //    });
                //}

                //List<ProductType> productTypes = new List<ProductType>()
                //{
                //    new ProductType() {
                //        Id = 1,
                //        TypeName = "Type1"
                //    },
                //    new ProductType() {
                //        Id = 2,
                //        TypeName = "Type2"
                //    },
                //    new ProductType() {
                //        Id = 3,
                //        TypeName = "Type3"
                //    },
                //    new ProductType() {
                //        Id = 4,
                //        TypeName = "Type4"
                //    }
                //};



                var PTypes = Extensions.strTypes.ToDictionary();

                //ProductTypes = new ObservableCollection<ProductType>();
                //for (int i = 0; i < 7; i++)
                //{
                //    ProductTypes.Add(new ProductType()
                //    {
                //        Id = i + 1,
                //        TypeName = string.Format("PType{0}", i + 1),
                //    });
                //}

                for (int i = 5; i < 11; i++)
                {
                    bool isMine = false;
                    bool chk1 = false;
                    bool chk2 = false;

                    if ((i % 2) == 0)
                    {
                        isMine = true;
                        chk1 = true;
                        chk2 = true;
                    }

                    Products2.Add(new Product2()
                    {
                        IsMine = isMine,
                        BandWide = string.Format("{0}00", i),
                        Freq = string.Format("{0}000", i),
                        Chk1 = chk1,
                        Chk2 = chk2,
                        SelectedProdcutId = i-5
                    });
                }


                //testProduct2 = new Product2() {
                //    Chk1 = false,
                //    BandWide = "345",
                //    Chk2 = true,
                //    Freq = "20000",
                //    SelectedProdcutType = ProductTypes[0]
                //};

                //testProducts2.Add(testProduct2);
                //testProducts22.Add(testProduct2);
            }
        }

        public Product2 testProduct2;
        public List<Product2> testProducts2 = new List<Product2>();
        public List<Product2> testProducts22 = new List<Product2>();

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
            EnableBtnApply = true;
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