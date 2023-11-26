using Azure;
using OOO_NAN.Common;
using OOO_NAN.Model;
using OOO_NAN.View;
using OOO_NAN.ViewModel;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace OOO_NAN.ModelView
{
    public class MainWindowViewModel : Common.ViewModelBase
    {
        private ObservableCollection<string> tableList;
        private string selectedTable;
        private Uri selectedView;
        private RelayCommand? selectedTableCommand;

        public MainWindowViewModel()
        {
            FillTables();
        }

        public ObservableCollection<string> TableList
        {
            get { return tableList; }
            set
            {
                tableList = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTable
        {
            get { return selectedTable; }
            set
            {
                selectedTable = value;
                OnPropertyChanged();
            }
        }

        public Uri SelectedView
        {
            get { return selectedView; }
            set
            {
                selectedView = value;
                OnPropertyChanged();
            }
        }

        // Команда создания страницы ProductPage
        public RelayCommand SelectedTableCommand
        {
            get
            {
                return selectedTableCommand ??
                    (selectedTableCommand = new RelayCommand((parameter) =>
                    {
                        if (parameter is string selectedTable)
                        {
                            if (selectedTable.Equals("Product", StringComparison.OrdinalIgnoreCase))
                            {
                                SelectedView = new Uri("ProductPage.xaml", UriKind.Relative);
                            }
                        }
                    }));
            }
        }

        // Загрузка списка таблиц из БД
        private void FillTables()
        {
            using(OooNanContext db = new OooNanContext())
            {
                TableList = new ObservableCollection<string>(db.Model.GetEntityTypes()
                .Select(n => n.ClrType.Name).ToList());
            }
        }
    }
}
