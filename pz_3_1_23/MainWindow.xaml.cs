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
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace pz_3_1_23
{
    public partial class MainWindow : Window
    {
        OooNanContext db;
        private ObservableCollection<Product> filteredProducts;
        public List<Product> products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            db = new OooNanContext();
            db.Products.Load();
            filteredProducts = new ObservableCollection<Product>(db.Products);
            productsGrid.ItemsSource = filteredProducts;
            cbFilter.ItemsSource = db.Products.Local.Select(p => p.Price).Distinct().OrderBy(price => price);
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
            AddItem addItem = new AddItem();
            addItem.Owner = this;
            addItem.Db = db;
            addItem.Show();
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

        private void cbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(productsGrid.ItemsSource).Filter = null;

            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "Все")
            {
                productsGrid.ItemsSource = filteredProducts;
            }
            else
            {
                string selectedFilter = cbFilter.SelectedItem.ToString();

                decimal filterValue;
                if (decimal.TryParse(selectedFilter, out filterValue))
                {
                    ICollectionView view = CollectionViewSource.GetDefaultView(productsGrid.ItemsSource);
                    view.Filter = item =>
                    {
                        Product product = item as Product;
                        return product != null && product.Price == filterValue;
                    };

                    productsGrid.Items.Refresh();
                }
            }
        }

        private void print_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                this.IsEnabled = false;
                PrintDialog pD = new PrintDialog();
                if (pD.ShowDialog() == true)
                {
                    pD.PrintVisual(productsGrid, "OOO NAN");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("При попытке печати возникла ошибка!");
            }   
            finally
            {
                this.IsEnabled = true;
            }

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            productsGrid.ItemsSource = db.Products.Local.Where(x => x.Title.Contains(searchTextBox.Text)).ToList();
        }
    } 
}
