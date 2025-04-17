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
    /// Логика взаимодействия для AnimalsPage1.xaml
    /// </summary>
    public partial class AnimalsPage1 : Page
    {
        public static List<Animals> animals {  get; set; }
        public static List<Gender> genders { get; set; }
        public static List<TypeAnimal> typeAnimals { get; set; }
        public AnimalsPage1()
        {
            InitializeComponent();
            animals = new List<Animals>(Conection.KlinikaEntities.Animals.ToList());
            genders = new List<Gender>(Conection.KlinikaEntities.Gender.ToList());
            typeAnimals = new List<TypeAnimal>(Conection.KlinikaEntities.TypeAnimal.ToList());
            this.DataContext = this;
        }

        private void Addanimals_Click(object sender, RoutedEventArgs e)
        {
            AddAnimalWindow1 addAnimalWindow1 = new AddAnimalWindow1();
            addAnimalWindow1.Show();
        }
    }
}
