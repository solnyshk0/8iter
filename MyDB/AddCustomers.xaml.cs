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
    /// Логика взаимодействия для AddCustomers.xaml
    /// </summary>
    public partial class AddCustomers : Window
    {
        private CustomersDto customersDto;

        private void LoadCustomers()
        {
            if(customersDto == null)
            {
                return;
            }

            tbContactPerson.Text = customersDto.ContactPerson;
            tbPhone.Text = customersDto.Phone.ToString();
            tbAddress.Text = customersDto.Address;
        }

        public AddCustomers(CustomersDto customers = null)
        {
            customersDto = customers;
            InitializeComponent();
            LoadCustomers();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbContactPerson.Text))
            {
                MessageBox.Show("Контактное лицо должно быть указано", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbPhone.Text))
            {
                MessageBox.Show("Телефон должен быть указан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(tbAddress.Text))
            {
                MessageBox.Show("Адрес должен быть указан", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (customersDto == null)
            {
                customersDto = new CustomersDto();
                customersDto.ContactPerson = tbContactPerson.Text;
                customersDto.Phone.ToString() = tbPhone.Text;
                customersDto.Address = tbAddress.Text;

                ICustomersProcess customersProcess = ProcessFactory.GetCustomersProcess();
                customersProcess.Add(customersDto);
            }
            else
            {
                customersDto.ContactPerson = tbContactPerson.Text;
                customersDto.Phone = int.Parse(tbPhone.Text);
                customersDto.Address = tbAddress.Text;

                ICustomersProcess customersProcess = ProcessFactory.GetCustomersProcess();
                customersProcess.Update(customersDto);
            }
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
