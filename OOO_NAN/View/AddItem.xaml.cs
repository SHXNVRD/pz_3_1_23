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
using OOO_NAN.Model;

namespace OOO_NAN
{
    /// <summary>
    /// Логика взаимодействия для AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        private OooNanContext db;

        public OooNanContext Db
        {
            get { return db; }
            set { db = value; }
        }

        public AddItem()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product();

                product.Title = TitleTextBox.Text;
                product.Price = Convert.ToDecimal(PriceTextBox.Text);
                product.Description = DescriptionTextBox.Text;

                Db.Products.Add(product);
                Db.SaveChanges();

                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
