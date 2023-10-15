using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SqlClient;
namespace pz_3_1_23
{
    public partial class App : Application
    {
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    base.OnStartup(e);

        //    // Получение строки подключения из appsettings.json
        //    var builder = new ConfigurationBuilder()
        //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //        .AddJsonFile("appsettings.json");
        //    var configuration = builder.Build();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");

        //    // Создание и открытие подключения к базе данных
        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"При попытке подлкючения возникла ошибка \n{ex}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning); 
        //        }
        //    }
        //}
    }
}
