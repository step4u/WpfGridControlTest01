﻿using System;
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
        List<Product> modifyProducts;
        List<Product> deleteProducts;
        Product deleteProduct;

        ObservableCollection<Product1> Products1;
        List<Product1> originProducts1;
        List<Product1> addProducts1;
        List<Product1> modifyProducts1;
        List<Product1> deleteProducts1;
        Product1 deleteProduct1;


        ObservableCollection<Product2> Products2;
        List<Product2> originProducts2;
        List<Product2> addProducts2;
        List<Product2> modifyProducts2;
        List<Product2> deleteProducts2;
        Product2 deleteProduct2;

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
            Products1 = viewmodel.Products1;
            Products2 = viewmodel.Products2;
            // Products.CollectionChanged += Products_CollectionChanged;
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

            modifyProducts2 = Products2.Where(x => originProducts2.Any(y => y.HasSameValues(x)) == false).ToList();

            this.ChangeUIStatus(ProgressingJob.IDLE);
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (progressingJob == ProgressingJob.IDLE)
            {
                originProducts = Products.Clone().ToList();
                originProducts1 = Products1.Clone().ToList();
                originProducts2 = Products2.Clone().ToList();
                this.ChangeUIStatus(ProgressingJob.MODIFY);
            }
            else if (progressingJob == ProgressingJob.MODIFY)
            {
                //Products.Clear();
                //foreach (Product product in originProducts)
                //{
                //    Products.Add(product);
                //}

                Products = new ObservableCollection<Product>(originProducts.Clone().ToList());
                Products1 = new ObservableCollection<Product1>(originProducts1.Clone().ToList());
                // Products2 = new ObservableCollection<Product2>(originProducts2.Clone().ToList());

                Products2.Clear();
                foreach (Product2 product in originProducts2)
                {
                    Products2.Add(product);
                }

                this.ChangeUIStatus(ProgressingJob.IDLE);
            }
        }

        private void ChangeUIStatus(ProgressingJob status)
        {
            this.progressingJob = status;

            switch (status)
            {
                case ProgressingJob.RELOAD:
                    break;
                case ProgressingJob.IDLE:
                    tableview0.AllowEditing = false;

                    viewmodel.BtnAdd = true;
                    viewmodel.BtnModify = true;
                    viewmodel.BtnDel = true;
                    viewmodel.BtnApply = true;

                    viewmodel.TxtBtnReload = "화면갱신";
                    viewmodel.TxtBtnAdd = "추가";
                    viewmodel.TxtBtnModify = "수정";
                    viewmodel.TxtBtnDel = "삭제";
                    viewmodel.TxtBtnApply = "적용";
                    break;
                case ProgressingJob.ADD:
                    break;
                case ProgressingJob.MODIFY:
                    // gridctrl0.SelectionMode = DevExpress.Xpf.Grid.MultiSelectMode.None;
                    tableview0.AllowEditing = true;
                    viewmodel.BtnAdd = false;
                    viewmodel.BtnDel = false;
                    viewmodel.BtnApply = true;

                    viewmodel.TxtBtnModify = "수정취소";
                    break;
                case ProgressingJob.DELETE:
                    break;
            }
        }
    }
}
