using OOO_NAN.Model;
using System.Windows;
using System.Windows.Controls;
using OOO_NAN.View;
using OOO_NAN.ViewModel;

namespace OOO_NAN.View
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        //private int Index;

        //public ProductPage()
        //{
        //    InitializeComponent();
        //    DataContext = new ViewModel.ProductPageViewModel();
        //}

        public ProductPage()
        {

        }

        //private void bEditProduct_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ViewModel.ProductPageViewModel.selectedProduct != null)
        //    {
        //        Index = ViewModel.ProductPageViewModel.products.IndexOf(ViewModel.ProductPageViewModel.selectedProduct);
        //        EditProductWindow editProductWindow = new EditProductWindow(ProductPageViewModel.selectedProduct, Index);
        //        editProductWindow.ShowDialog();
        //    }
        //    else
        //        MessageBox.Show("Элемент не должен быть пустым!");
        //}
    }
}
