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

namespace MyDB
{
    /// <summary>
    /// Логика взаимодействия для AddProducts.xaml
    /// </summary>
    public partial class AddProducts : Window
    {
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public AddProducts(ProductsDto product = null)
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
