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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public Edit(Product _product)
        {
            InitializeComponent();
            Console.WriteLine(_product);

            ProductNameElem.Text = _product.ProductName;
            ProductDescriptionElem.Text = _product.ProductDescription;
            ProductCostElem.Text = _product.ProductCost.ToString();
            ProductManufacturerElem.Text = _product.ProductManufacturer;
            ProductDiscountAmountElem.Text = _product.ProductDiscountAmount.ToString();
            ProductQuantityInStockElem.Text = _product.ProductQuantityInStock.ToString();
            ProductCategoryElem.SelectedItem = _product.ProductCategory;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string productarticlenumber = ProductArticleNumberElem.Text;
            string productname = ProductNameElem.Text;
            string productdescription = ProductDescriptionElem.Text;
            int productcost = int.Parse(ProductCostElem.Text);
            string productmanufacturer = ProductManufacturerElem.Text;
            int productdiscountamount = int.Parse(ProductDiscountAmountElem.Text);
            int productquantityinstock = int.Parse(ProductQuantityInStockElem.Text);
            ComboBoxItem item = (ComboBoxItem)ProductCategoryElem.SelectedItem;

            Product editProduct = Helpers.connection.Product.FirstOrDefault(x => x.ProductArticleNumber == productarticlenumber);

            editProduct.ProductName = productname;
            editProduct.ProductDescription = productdescription;
            editProduct.ProductCost = productcost;
            editProduct.ProductManufacturer = productmanufacturer;
            editProduct.ProductCategory = item.Content.ToString();
            editProduct.ProductDiscountAmount = productdiscountamount;
            editProduct.ProductQuantityInStock = productquantityinstock;

            Helpers.connection.SaveChanges();
            MessageBox.Show("Товар отредактирован!");
            new MainWindow().Show();
            Close();
        }

        private void ProductCategoryElem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
} 