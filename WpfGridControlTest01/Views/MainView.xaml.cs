using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using WpfGridControlTest01.Classes;
using WpfGridControlTest01.Models;
using WpfGridControlTest01.ViewModels;

namespace WpfGridControlTest01.Views
{
    /// <summary>
    /// Interaction logic for View1.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        ObservableCollection<Product> Products;
        List<Product> originProducts;
        List<Product> addProducts;
        List<Product> deleteProducts;
        Product deleteProduct;
        DoJobs dojobs;
        ProgressingJob progressingJob = ProgressingJob.IDLE;

        public MainView()
        {
            InitializeComponent();

            this.Loaded += MainView_Loaded;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            Products = viewmodel.Products;
            Products.CollectionChanged += Products_CollectionChanged;
            tableview0.Loaded += Tableview0_Loaded;
            tableview0.CellValueChanged += Tableview0_CellValueChanged;
        }

        private void Products_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Products_CollectionChanged Action: " + e.Action);
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                if (addProducts == null)
                    addProducts = new List<Product>();

                try
                {
                    addProducts.Add(e.NewItems.Cast<Product>().ToList().First());
                }
                catch (InvalidOperationException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        private void Tableview0_Loaded(object sender, RoutedEventArgs e)
        {
            originProducts = Products.Clone().ToList();
        }

        private void Tableview0_CellValueChanged(object sender, DevExpress.Xpf.Grid.CellValueChangedEventArgs e)
        {

        }

        private int number = 4;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Products.Add(new Product()
            {
                BandWide = String.Format("{0}00", number),
                Freq = String.Format("{0}000", number),
                Chk1 = false,
                Chk2 = false
            });
            number++;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (progressingJob == ProgressingJob.DELETE)
            {
                progressingJob = ProgressingJob.IDLE;
                gridctrl0.SelectionMode = DevExpress.Xpf.Grid.MultiSelectMode.Row;
                tableview0.ShowCheckBoxSelectorColumn = false;

                viewmodel.BtnAdd = true;
                viewmodel.BtnDel = true;
                viewmodel.BtnReload = true;
                viewmodel.BtnApply = true;
                viewmodel.TxtBtnDel = "삭제";
            }
            else
            {
                progressingJob = ProgressingJob.DELETE;
                gridctrl0.SelectionMode = DevExpress.Xpf.Grid.MultiSelectMode.MultipleRow;
                tableview0.ShowCheckBoxSelectorColumn = true;

                viewmodel.BtnAdd = false;
                viewmodel.BtnDel = true;
                viewmodel.BtnReload = false;
                viewmodel.BtnApply = true;
                viewmodel.TxtBtnDel = "삭제취소";
            }

            //deleteProducts = gridctrl0.SelectedItems.Cast<Product>().ToList();
            //deleteProduct = deleteProducts.First();

            //byte[] packet = Serialize(deleteProduct);

            //dojobs = new DoJobs(packet);
            //dojobs.OnJobFinished += Dojobs_OnJobFinished;
            //dojobs.Send();
        }

        private void Dojobs_OnJobFinished(object sender, EventArgs e)
        {


            //deleteProducts.Remove(deleteProduct);
            //Products.Remove(deleteProduct);

            //try
            //{
            //    deleteProduct = deleteProducts.First();
            //}
            //catch (InvalidOperationException ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //    return;
            //}

            //dojobs.Send(Serialize(deleteProduct));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Reload button pressed.", "Debug");
            Products = new ObservableCollection<Product>(originProducts);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Apply button pressed.", "Debug");
        }



        public byte[] Serialize(Object obj)
        {
            if (obj == null)
            {
                return null;
            }

            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();

                binaryFormatter.Serialize(memoryStream, obj);

                var compressed = Compress(memoryStream.ToArray());
                return compressed;
            }
        }

        public Object DeSerialize(byte[] arrBytes)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                var decompressed = Decompress(arrBytes);

                memoryStream.Write(decompressed, 0, decompressed.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                return binaryFormatter.Deserialize(memoryStream);
            }
        }

        private byte[] Compress(byte[] input)
        {
            byte[] compressesData;

            using (var outputStream = new MemoryStream())
            {
                using (var zip = new GZipStream(outputStream, CompressionMode.Compress))
                {
                    zip.Write(input, 0, input.Length);
                }

                compressesData = outputStream.ToArray();
            }

            return compressesData;
        }

        private byte[] Decompress(byte[] input)
        {
            byte[] decompressedData;

            using (var outputStream = new MemoryStream())
            {
                using (var inputStream = new MemoryStream(input))
                {
                    using (var zip = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zip.CopyTo(outputStream);
                    }
                }

                decompressedData = outputStream.ToArray();
            }

            return decompressedData;
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            tableview0.AllowEditing = !tableview0.AllowEditing;
        }
    }
}
