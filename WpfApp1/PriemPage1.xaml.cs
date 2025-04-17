using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.dbconection;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для PriemPage1.xaml
    /// </summary>
    public partial class PriemPage1 : Page
    {
        public static List<Priem> priems { get; set; }
        public PriemPage1()
        {
            InitializeComponent();

            priems = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddPriemWindow1 addPriemWindow1 = new AddPriemWindow1();
            addPriemWindow1.Show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var priem = ReadersLv.SelectedItem as Priem;
            if (priem != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить приём у врача {priem.Doctor.Lastname} {priem.Doctor.Name} ?", "Удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    priem.IsDelete = true;
                    Conection.KlinikaEntities.SaveChanges();
                    ReadersLv.ItemsSource = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.Where(i => i.IsDelete == false).ToList());

                }
            }
            else
            {
                MessageBox.Show("Вы никого не выбрали.");
            }
        }


        private void RedactivBtn_Click(object sender, RoutedEventArgs e)
        {
            var priem = ReadersLv.SelectedItem as Priem;
            if (priem != null)
            {
               Edit redactivWindow1 = new Edit(priem);
                redactivWindow1.Show();

            }
            else
            {
                MessageBox.Show("Для редактирования сначала выберите ");
            }
        }

        private void TicketSearchTb_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var clicha = SearchforClicha.Text;
            if (clicha == "")
                ReadersLv.ItemsSource = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.Where(i => i.IsDelete == false).ToList());
            else
                ReadersLv.ItemsSource = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.Where(i => i.Animals.Name == clicha && i.IsDelete == false).ToList());
        }

        private void BirthDateDp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = BirthDateDp.SelectedDate;
            ReadersLv.ItemsSource = new List<Priem>(Conection.KlinikaEntities.Priem.Where(i => i.Data == date).ToList());
        }
    }
}
