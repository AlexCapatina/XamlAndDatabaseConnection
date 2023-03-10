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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Question02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdventureWorksEntities context = new AdventureWorksEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query =
            from product in context.Products
            where product.Color == "Red"
            orderby product.ListPrice
            select new { product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice };

            dataGrid1.ItemsSource = query.ToList();
        }
    }
}
