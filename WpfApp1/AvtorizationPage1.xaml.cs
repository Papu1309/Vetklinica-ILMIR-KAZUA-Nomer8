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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AvtorizationPage1.xaml
    /// </summary>
    public partial class AvtorizationPage1 : Page
    {
        public AvtorizationPage1()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loginTb.Text == "ILMIR" && passwordTb.Text == "1309" )
            {
                MenuWindow1 menuWindow1 = new MenuWindow1();
                menuWindow1.Show();
            }
            else
            {
                MessageBox.Show("Кто ты , воин?");
            }

        }
    }
}
