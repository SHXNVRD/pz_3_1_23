using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows;

namespace pz3_3
{ 
    public partial class MainWindow : Window
    {
        private ApplicationContext db;
        
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            db.Sexes.Load();
            db.Users.Load();
            dgUsers.ItemsSource = db.Users.Local.ToList();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChangesAsync();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem.sexes = db.Sexes.Local.ToList();
            AddItem addItem = new AddItem();
            addItem.Owner = this;
            addItem.Db = db;
            addItem.Show();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgUsers.SelectedItems.Count > 0)
            {
                for (int i = 0; i < dgUsers.SelectedItems.Count; i++)
                {
                    User user = dgUsers.SelectedItems[i] as User;

                    if (user != null)
                        db.Users.Remove(user);
                }
            }
            db.SaveChangesAsync();
        }
    }
}
