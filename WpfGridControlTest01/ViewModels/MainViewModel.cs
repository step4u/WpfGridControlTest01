using DevExpress.Mvvm;
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

        public string TxtBtnAdd {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TxtBtnDel {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TxtBtnReload {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TxtBtnApply {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
        public string TxtBtnModify {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public bool BtnAdd {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool BtnDel {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool BtnReload {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool BtnApply {
            get { return GetValue<bool>(); }
            set { SetValue(value); }
        }

        public bool BtnModify {
            get { return GetValue<bool>(); }
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

        ObservableCollection<Product2> _Products2;
        public ObservableCollection<Product2> Products2 {
            get { return _Products2; }
            set { SetValue(ref _Products2, value, "Products2"); }
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

                for (int i = 5; i <= 9; i++)
                {
                    Products2.Add(new Product2()
                    {
                        BandWide = string.Format("{0}00", i),
                        Freq = string.Format("{0}000", i),
                        Chk1 = true,
                        Chk2 = false
                    });
                }
            }
        }

        void InitProperties()
        {
            TxtBtnAdd = "추가";
            TxtBtnDel = "삭제";
            TxtBtnReload = "갱신";
            TxtBtnModify = "수정";
            TxtBtnApply = "적용";
            BtnAdd = true;
            BtnDel = true;
            BtnReload = true;
            BtnApply = false;
            BtnModify = true;
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