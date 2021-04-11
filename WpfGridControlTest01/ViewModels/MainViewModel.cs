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

            if (IsInDesignMode)
            {
                Products = new ObservableCollection<Product>();
                // Devices = new ObservableCollection<Device>();
            }
            else
            {
                InitData();
            }

            InitProperties();
            InitTimer();
        }

        public ObservableCollection<Product> Products {
            get => GetValue<ObservableCollection<Product>>();
            set => SetValue(value);
        }

        public ObservableCollection<Device> Devices {
            get => GetValue<ObservableCollection<Device>>();
            set => SetValue(value);
        }

        void ShowMessage()
        {
            MessageBoxService.Show("This is MainView!");
        }

        void InitData()
        {
            Products = new ObservableCollection<Product>();

            Products.Add(new Product()
            {
                BandWide = "100",
                Freq = "1000",
                Chk1 = true,
                Chk2 = false
            });

            Products.Add(new Product()
            {
                BandWide = "200",
                Freq = "2000",
                Chk1 = true,
                Chk2 = true
            });

            Products.Add(new Product()
            {
                BandWide = "300",
                Freq = "3000",
                Chk1 = false,
                Chk2 = true
            });
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