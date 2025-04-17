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
using WpfApp1.dbconection;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddPriemWindow1.xaml
    /// </summary>
    public partial class AddPriemWindow1 : Window
    {
        public static List<Priem> priems { get; set; }
        public static List<Doctor> doctors { get; set; }
        public static List<Animals> animals { get; set; }
        public AddPriemWindow1()
        {
            InitializeComponent();
            animals = new List<Animals>(dbconection.Conection.KlinikaEntities.Animals.ToList());
            doctors = new List<Doctor>(dbconection.Conection.KlinikaEntities.Doctor.ToList());
            priems = new List<Priem>(dbconection.Conection.KlinikaEntities.Priem.ToList());
            this.DataContext = this;
        }


        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            Priem priem = new Priem();
            Doctor doctor = new Doctor();
            priem.Data = BirthDateDp.SelectedDate;
            priem.Coment = CommentTb.Text.Trim();
            priem.Idanimal = (aCm.SelectedItem as Animals).Id;
            priem.Iddoctor = (fCm.SelectedItem as Doctor).Id;
            priem.IsDelete = false;
            Conection.KlinikaEntities.Animals.Add(animals);
            Conection.KlinikaEntities.Doctor.Add(doctor);
            Conection.KlinikaEntities.Priem.Add(priem);
            Conection.KlinikaEntities.SaveChanges();
            MessageBox.Show(" Успешно добавлен");
            Close();
        }

    }
}
