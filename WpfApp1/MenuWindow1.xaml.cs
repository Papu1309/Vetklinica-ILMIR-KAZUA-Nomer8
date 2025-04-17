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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow1.xaml
    /// </summary>
    public partial class MenuWindow1 : Window
    {
        public MenuWindow1()
        {
            InitializeComponent();
        }

        private void doctorBtn_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new DoctorPage1());
        }

        private void priemBtn_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new PriemPage1());
        }

        private void animalBtn_Click(object sender, RoutedEventArgs e)
        {
            menuFr.NavigationService.Navigate(new AnimalsPage1());
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuFr_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
