using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Security;
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
        internal static List<Sex> sexes;

        internal ApplicationContext Db
        {
            get { return db; }
            set { db = value; }
        }

        public AddItem()
        {
            InitializeComponent();
            SetComboBox();
        }

        private void SetComboBox()
        {
            cbSex.ItemsSource = sexes;
            cbSex.DisplayMemberPath = "Title";
            cbSex.SelectedValuePath = "Id";
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
                User user = new User
                {
                    Name = NameTextBox.Text,
                    Birthday = DateTime.Parse(BirthdayTextBox.Text),
                    Phone = PhoneTextBox.Text,
                    Address = AddressTextBox.Text,
                    SexId = Convert.ToUInt32(cbSex.SelectedValue)
                };

                Db.Users.Add(user);

                Db.SaveChangesAsync();

                MessageBox.Show("Данные успешно добавлены");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
