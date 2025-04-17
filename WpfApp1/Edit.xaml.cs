using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
using WpfApp1.dbconection;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        public static Priem priem1 = new Priem();
        public static List<Priem> priems { get; set; }
        public static List<Doctor> doctors { get; set; }
        public static List<Animals> animals { get; set; }
        public Edit(Priem priem)
        {
            InitializeComponent();
            animals = new List<Animals>(dbconection.Conection.KlinikaEntities.Animals.ToList());
            doctors = new List<Doctor>(dbconection.Conection.KlinikaEntities.Doctor.ToList());
            priems = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.ToList());
            priem1 = priem;
            BirthDateDp.SelectedDate = priem1.Data;
            VecTb.Text = priem1.Coment;
            aCm.Text = Convert.ToString(priem1.Idanimal);
            fCm.Text = Convert.ToString(priem1.Iddoctor);
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите изменить  ?", "Удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
               

                priem1.Data = BirthDateDp.SelectedDate;
                priem1.Coment = VecTb.Text.Trim();
                priem1.Idanimal = (aCm.SelectedItem as Animals).Id;
                priem1.Iddoctor = (fCm.SelectedItem as Doctor).Id;
                PriemPage1 priemPage1 = new PriemPage1();
                priemPage1.ReadersLv.ItemsSource = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.Where(i => i.IsDelete == false).ToList());
                Conection.KlinikaEntities.SaveChanges();
            }
            MessageBox.Show(" успешно изменен.");
            Close();
        }
    }
}
