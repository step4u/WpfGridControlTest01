using DevExpress.Xpf.Core;
using System;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfGridControlTest01.Models;
using WpfGridControlTest01.Views;

namespace WpfGridControlTest01
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp : ThemedWindow
    {
        public Object parent;

        public PopUp()
        {
            InitializeComponent();

            this.Deactivated += PopUp_Deactivated;
            this.Loaded += PopUp_Loaded;
        }

        private void PopUp_Loaded(object sender, RoutedEventArgs e)
        {
            StartTimer();
        }

        DispatcherTimer timer;
        private void PopUp_Deactivated(object sender, EventArgs e)
        {
            // StartTimer();
            System.Diagnostics.Debug.WriteLine("PopUp->PopUp_Deactivated...");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            StopTimer();
            System.Diagnostics.Debug.WriteLine($"PopUp->Timer_Tick: {this.Topmost.ToString()}");
        }

        void StartTimer()
        {
            this.Topmost = true;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(2000);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        void StopTimer()
        {
            timer.Stop();
            this.Topmost = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (parent.GetType() == typeof(MainView))
            {
                MainView _parent = (MainView)parent;
                Product2 row = (Product2)_parent.gridctrl0.SelectedItem;
                if (row != null)
                    row.Freq = this.txtBox.Text.Trim();

                _parent.gridctrl0.Focus();
                // _parent.tableview0.MoveNextCell();
            }
            this.Close();
        }
    }
}
