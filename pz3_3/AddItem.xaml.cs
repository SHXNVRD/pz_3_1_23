using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pz3_3
{
    public partial class AddItem : Window
    {
        private ApplicationContext db;

        internal ApplicationContext Db
        {
            get { return db; }
            set { db = value; }
        }
        public AddItem()
        {
            InitializeComponent();
        }

        private void AcceptAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox == null || PhoneTextBox == null || BirthdayTextBox == null || AddressTextBox == null || cbSex.SelectedItem == null)
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            }

            try
            {
                User user = new User();

                cbSex.ItemsSource = db.Sexes.ToList();
                cbSex.DisplayMemberPath = "Title";
                cbSex.SelectedValuePath = "Id";

                user.Name = NameTextBox.Text;
                user.Birthday = DateTime.Parse(BirthdayTextBox.Text);
                user.Phone = PhoneTextBox.Text;
                user.Address = AddressTextBox.Text;
                Binding binding = new Binding("SexId");
                binding.Source = user;  
                cbSex.SetBinding(ComboBox.SelectedValueProperty, binding);

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
