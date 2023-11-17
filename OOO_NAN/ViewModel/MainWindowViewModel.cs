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
        OooNanContext db = new OooNanContext();
        private ObservableCollection<string> tableList;
        private Page currentPage;
        private string selectedTable;
        private Uri selectedViewModel;
        private RelayCommand? selectedTableCommand;

        public MainWindowViewModel()
        {
            FillTables();
            currentPage = new Page();
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

        public Page CurrentPage
        {
            get { return currentPage; }
            set
            {
                currentPage = value;
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

        public Uri SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }

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
                                SelectedViewModel = new Uri("ProductPage.xaml", UriKind.Relative);
                            }
                        }
                    }));
            }
        }

        // Загрузка списка таблиц БД
        private void FillTables()
        {
            TableList = new ObservableCollection<string>(db.Model.GetEntityTypes()
                .Select(n => n.ClrType.Name).ToList());
        }

        public void OnSelectedTableChanged()
        {
            switch (SelectedTable)
            {
                case "Product":
                    currentPage = new ProductPage();
                    
                    break;
                default:
                    break;
            }
        }
    }
}
