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
using MyDB.Dto;
using MyDB.BuisenessLayer;

namespace MyDB
{
    /// <summary>
    /// Логика взаимодействия для ProductsWindow.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        public ProductsWindow()
        {
            InitializeComponent();
        }

        private void UpdateWindow()
        {
            dgProducts.ItemsSource = ProcessFactory.GetProductsProcess().GetList();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProducts wnd = new AddProducts();
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            ProductsDto item = dgProducts.SelectedItem as ProductsDto;

            if (item == null)
            {
                MessageBox.Show("Выбирите товар для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить товар " + item.Name + "?", "Удаление товара", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result != MessageBoxResult.Yes)
            {
                return;
            }
            IProductProcess productsProcess = ProcessFactory.GetProductsProcess();
            productsProcess.Delete(item.ProductID);
            UpdateWindow();
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
            ProductsDto item = dgProducts.SelectedItem as ProductsDto;

            if (item == null)
            {
                MessageBox.Show("Выбирите товар для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddProducts wnd = new AddProducts(item);
            wnd.ShowDialog();
            UpdateWindow();
        }
    }
}
