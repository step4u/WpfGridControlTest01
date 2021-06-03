using DevExpress.Xpf.Core;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGridControlTest01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.PreviewMouseLeftButtonDown += MainWindow_PreviewMouseLeftButtonDown;

            //this.Closing += MainWindow_Closing;
        }

        private void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point relatedPosition = e.MouseDevice.GetPosition(this);
            Point point = PointFromScreen(relatedPosition);
        }

        //private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{

        //}
    }
}
