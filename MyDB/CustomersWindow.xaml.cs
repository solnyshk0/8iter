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
using MyDB.BuisenessLayer;
using MyDB.Dto;

namespace MyDB
{
    /// <summary>
    /// Логика взаимодействия для Customers.xaml
    /// </summary>
    public partial class CustomersWindow : Window
    {
        public CustomersWindow()
        {
            InitializeComponent();
            UpdateWindow();
        }

        private void UpdateWindow()
        {
            dgCustomers.ItemsSource = ProcessFactory.GetCustomersProcess().GetList();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCustomers wnd = new AddCustomers();
            wnd.ShowDialog();
            UpdateWindow();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
           /* CustomersDto item = dgCustomers.SelectedItem as CustomersDto;

            if (item == null)
            {
                MessageBox.Show("Выбирите покупателя для удаления", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить покупателя " + item.ContactPerson + "?", "Удаление покупателя", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result!= MessageBoxResult.Yes)
            {
                return;
            }
            ICustomersProcess customersProcess = ProccessFactory.GetCustomersProcess();
            customersProcess.Delete(item.CustomerID);
            UpdateWindow();*/
        }

        private void btUpdate_Click(object sender, RoutedEventArgs e)
        {
           /* CustomersDto item = dgCustomers.SelectedItem as CustomersDto;

            if (item == null)
            {
                MessageBox.Show("Выбирите покупателя для изменения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            AddCustomers wnd = new AddCustomers(item);
            wnd.ShowDialog();
            UpdateWindow();*/
        }
    }
}
