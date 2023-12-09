using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public partial class Autorization : Window
    {
        //OooNanContext db;
        public Autorization()
        {
            InitializeComponent();
            DataContext = new ViewModel.AutorizationViewModel();
            
        }
        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    db = new OooNanContext();

        //    try
        //    {
        //        var user = db.Clients.Where(x => (x.Email == LoginBox.Text && x.Client_Password == PasswordBox.Password)).FirstOrDefault();
        //        if (user != null)
        //        {
        //            MainWindow mainWindow = new MainWindow();
        //            mainWindow.Show();
        //            db.DisposeAsync();
        //            this.Close();
        //        }
        //        else
        //            MessageBox.Show("Неправильно введён логин или пароль!");
        //    }
        //    catch (Exception)
        //    {

        //        MessageBox.Show("Неправильно введён логин или пароль!");
        //    }
        //}

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void bMinimize_Click(object sender, RoutedEventArgs e) =>
            WindowState = WindowState.Minimized;
    }
}
