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
    /// Логика взаимодействия для AddAnimalWindow1.xaml
    /// </summary>
    public partial class AddAnimalWindow1 : Window
    {
        public static List<Animals> animals { get; set; }
        public static List<TypeAnimal> typeAnimals { get; set; }
        public static List<Gender> genders { get; set; }
        public AddAnimalWindow1()
        {
            InitializeComponent();
            animals = new List<Animals>(dbconection.Conection.KlinikaEntities.Animals.ToList());
            typeAnimals = new List<TypeAnimal>(dbconection.Conection.KlinikaEntities.TypeAnimal.ToList());
            genders = new List<Gender>(dbconection.Conection.KlinikaEntities.Gender.ToList());
            this.DataContext = this;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            Animals animals = new Animals();
            Gender gender = new Gender();
            TypeAnimal typeAnimal = new TypeAnimal();
            animals.Name = NameTb.Text.Trim();

            animals.IdType = (typeCm.SelectedItem as TypeAnimal).Id;
            animals.IdGender = (gCm.SelectedItem as Gender).Id;

            //gender.Name = PolTb.Text.Trim();
            //typeAnimal.Name = TypeTb.Text.Trim();
            animals.Poct = Convert.ToInt32(PostTb.Text.Trim());
            animals.Vec = Convert.ToInt32(VecTb.Text.Trim());
            Conection.KlinikaEntities.Animals.Add(animals);
            Conection.KlinikaEntities.Gender.Add(gender);
            Conection.KlinikaEntities.TypeAnimal.Add(typeAnimal);
            Conection.KlinikaEntities.SaveChanges();
            MessageBox.Show(" успешно добавлен");
            Close();
        }
    }
}
