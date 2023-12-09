using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OOO_NAN.Model;
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
using System.Windows.Shapes;

namespace OOO_NAN.View
{
    /// <summary>
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        //private Product product;

        //private int Index;

        //public EditProductWindow(Product product, int index)
        //{
        //    Index = index;
        //    this.product = product;
        //    InitializeComponent();
        //    this.DataContext = product;

        //    tbTitle.Text = this.product.Title;
        //    tbPrice.Text = Convert.ToString(this.product.Price);
        //    tbDescription.Text = this.product.Description;
        //}

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    product.Title = tbTitle.Text;
        //    product.Price = decimal.Parse(tbPrice.Text);
        //    product.Description = tbDescription.Text;

        //    // Сохранение изменений в базу данных
        //    using (var db = new OooNanContext())
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        db.SaveChanges();
        //    }

        //    ViewModel.ProductPageViewModel.products[Index] = product;

        //    // Закрытие окна после сохранения изменений
        //    this.Close();
        //}

        //private void bCancel_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //}
    }
}
