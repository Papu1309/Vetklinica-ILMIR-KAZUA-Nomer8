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
using WpfApp1.dbconection;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для DoctorPage1.xaml
    /// </summary>
    public partial class DoctorPage1 : Page
    {
        public static List<Doctor> doctors { get; set; }
        public DoctorPage1()
        {
            InitializeComponent();
            doctors = new List<Doctor>(dbconection.Conection.KlinikaEntities.Doctor.ToList());
            this.DataContext = this;
        }
    }
}
