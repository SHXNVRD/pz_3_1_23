using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace pz4_1
{
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        public ObservableCollection<User> users;
        private User selectedUser;
        private User newUser;
        public MainWindow(ApplicationContext db)
        {
            this.db = db;
            InitializeComponent();
            users = new ObservableCollection<User>(db.Users);
            dgUsers.ItemsSource = users;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                newUser = new User()
                {
                    Id = uint.Parse(tbId.Text),
                    Name = tbName.Text,
                    Birthday = DateTime.Parse(tbBirthday.Text),
                    Phone = tbPhone.Text,
                    Address = tbAddress.Text
                };
                
                db.Users.Add(newUser);
                users.Add(newUser);
                db.SaveChangesAsync();
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.Update(selectedUser);
                selectedUser = new User();
                db.SaveChangesAsync();
            }
            catch (Exception)
            { 
                MessageBox.Show("Ошибка");
            }
            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {   
            try
            {
                selectedUser = new User();
                selectedUser = (sender as FrameworkElement).DataContext as User;
                dgUpdate.DataContext = selectedUser;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
            }
         
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = dgUsers.SelectedItem as User;

            if (selectedUser != null)
            {
                users.Remove(selectedUser);
                db.Users.Remove(selectedUser);
                db.SaveChanges();
            }
        }

        private void QuerryButton_Click(object sender, RoutedEventArgs e)
        {
            var querryUsers = (from user in db.Users
                               where user.Id == 1
                               select user).ToList();
            dgUsers.ItemsSource = querryUsers;
        }
    }
}
