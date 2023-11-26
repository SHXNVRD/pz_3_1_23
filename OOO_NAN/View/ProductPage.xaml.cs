using OOO_NAN.Model;
using System.Windows;
using System.Windows.Controls;

namespace OOO_NAN.View
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        private int Index;

        public ProductPage()
        {
            InitializeComponent();
            DataContext = new ViewModel.ProductPageViewModel();
        }

        private void bEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.ProductPageViewModel.selectedProduct != null)
            {
                Index = ViewModel.ProductPageViewModel.products.IndexOf(ViewModel.ProductPageViewModel.selectedProduct);
                View.EditProductWindow editProductWindow = new View.EditProductWindow(ViewModel.ProductPageViewModel.selectedProduct, Index);
                editProductWindow.ShowDialog();
            }
            else
                MessageBox.Show("Элемент не должен быть пустым!");
        }
    }
}
