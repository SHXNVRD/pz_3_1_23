using OOO_NAN.Model;
using System.Collections.ObjectModel;

namespace OOO_NAN.ViewModel
{
    public class ProductPageViewModel : Common.PageViewModelBase
    {
				private static OooNanContext db;

				public static Product selectedProduct;

				public static ObservableCollection<Product> products;

				private RelayCommand? loadDataCommand;

				private RelayCommand? editProductCommand;

				public ProductPageViewModel()
				{ }

				public Product SelectedProduct
				{
						get { return selectedProduct; }
						set
						{
								selectedProduct = value;
								OnPropertyChanged();
						}
				}


				public ObservableCollection<Product> Products
				{
						get { return products; }
						set
						{
								products = value;
								OnPropertyChanged();
						}
				}

        public RelayCommand LoadDataCommand
				{
            get
            {
                return loadDataCommand ??
                    (loadDataCommand = new RelayCommand(obj =>
                    {
                        db = new OooNanContext();
                        Products = new ObservableCollection<Product>(db.Products);
                    }));
            }
        }
		}
}
