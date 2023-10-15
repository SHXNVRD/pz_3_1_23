using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace pz_3_1_23
{
    public partial class MainWindow : Window
    {
        OooNanContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new OooNanContext();
            db.Products.Load();
            productsGrid.ItemsSource = db.Products.Local.ToBindingList();
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.DisposeAsync();
        }
        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChangesAsync();
        }
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem item = new AddItem();
            item.Owner = this;
            item.Db = db;
            item.Show();
        }
        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (productsGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < productsGrid.SelectedItems.Count; i++)
                {
                    Product product = productsGrid.SelectedItems[i] as Product;

                    if (product != null)
                        db.Products.Remove(product);
                }
            }
            db.SaveChangesAsync();
        }
    }
}
