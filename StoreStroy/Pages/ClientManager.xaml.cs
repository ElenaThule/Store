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
using System.Windows.Shapes;

namespace StoreStroy
{
    /// <summary>
    /// Логика взаимодействия для ClientManager.xaml
    /// </summary>
    public partial class ClientManager : Window
    {
        private User user = Store.user;
        Connection connection = new Connection();
        public ClientManager()
        {
            InitializeComponent();
            fioElement.Content = $"{user.UserSurname} {user.UserName} {user.UserPatronymic}";
            productListElem.ItemsSource = connection.Product.ToList();
        }

        private void findElem_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Product> products = connection.Product.Where(x => x.ProductName.Contains(findElem.Text)).ToList();
            productListElem.ItemsSource = products;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Store.user = null;
            new MainWindow().Show();
            Close();

        }

        private void filterElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem manufacturer = (ComboBoxItem)filterElem.SelectedItem;
            string selected = manufacturer.Content.ToString();
            string productManufacturer = filterElem.SelectedItem.ToString();
            //List<Product> productManufacturer = new List<Product>();
            //productManufacturer.Add("Все производители");
            //productManufacturer.AddRange(Helpers.connection.Product.Select(x => x.ProductManufacturer).Distinct().ToList));
            //productManufacturerElem.ItemSourse = productManufacturer;

            //List<string> productManufacturer = newList<string>;

            if (productManufacturer == "Все производители")
            {
                filterElem.SelectedItem = Helpers.connection.Product.ToList();
                productListElem.ItemsSource = productManufacturer;
            }
            else
            {
               filterElem.SelectedItem = Helpers.connection.Product.Where(x => x.ProductManufacturer == productManufacturer).ToList();
            }
            productListElem.ItemsSource = productManufacturer;

        }
    }
}
