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
using System.Windows.Shapes;


namespace WpfGridControlTest01
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : ThemedWindow
    {
        public DXWindow1()
        {
            InitializeComponent();

            this.PreviewKeyDown += DXWindow1_PreviewKeyDown;
            // this.gridctrl0.PreviewKeyDown += Gridctrl0_PreviewKeyDown;
        }

        private void Gridctrl0_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                string jsonStr = string.Empty;
                // jsonStr = Clipboard.GetText(TextDataFormat.UnicodeText);
                bool ret = Clipboard.ContainsData("custom_format");
                var data = Clipboard.GetData("custom_format");
                // e.Handled = true;
            }
            else { }
        }

        private void DXWindow1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                string jsonStr = string.Empty;
                // jsonStr = Clipboard.GetText(TextDataFormat.UnicodeText);
                bool ret = Clipboard.ContainsData("custom_format");
                var data = Clipboard.GetData("custom_format");
                e.Handled = true;
            }
            else { }
        }

        private void gridctrl0_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                string jsonStr = string.Empty;
                // jsonStr = Clipboard.GetText(TextDataFormat.UnicodeText);
                bool ret = Clipboard.ContainsData("custom_format");
                var data = Clipboard.GetData("custom_format");
                // e.Handled = true;
            }
            else { }
        }

        private void tableview0_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.V && Keyboard.Modifiers == ModifierKeys.Control)
            {
                string jsonStr = string.Empty;
                // jsonStr = Clipboard.GetText(TextDataFormat.UnicodeText);
                bool ret = Clipboard.ContainsData("custom_format");
                var data = Clipboard.GetData("custom_format");
                // e.Handled = true;
            }
            else { }
        }

        private void gridctrl0_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {

        }
    }
}
