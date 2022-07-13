using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OnOpen();
        }
        private void OnOpen()
        {
            try
            {
                using (var str = new FileStream("meals.xml", FileMode.Open))
                {
                    var ser = new XmlSerializer(typeof(ObservableCollection<Meal>));
                    MealListView.ItemsSource = (ObservableCollection<Meal>)ser.Deserialize(str);
                }
            }
            catch (FileNotFoundException) { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            using (var str = new FileStream("meals.xml", FileMode.Create))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ObservableCollection<Meal>));
                ser.Serialize(str, MealListView.ItemsSource);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (MealListView.ItemsSource as ObservableCollection<Meal>).Remove(MealListView.SelectedItem as Meal);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddMealWindow amw = new AddMealWindow();
            amw.ShowDialog();
            (MealListView.ItemsSource as ObservableCollection<Meal>).Add(amw.meal);
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog sfd = new System.Windows.Forms.OpenFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                (MealListView.SelectedItem as Meal).ImageSource = sfd.FileName;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (MealListView.SelectedIndex==-1)
                return;
            IngredientsList win = new IngredientsList(ref (MealListView.SelectedItem as Meal)._Ingredients);
            win.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (MealListView.SelectedIndex == -1)
                return;
            CookingOrderWindow win = new CookingOrderWindow((MealListView.SelectedItem as Meal).CookingOrder);
            win.ShowDialog();
            (MealListView.SelectedItem as Meal).CookingOrder = win.order;
        }
    }

    [Serializable()]
    public class Ingredient
    {
        private string _NameOfIngredient = "";
        public string NameOfIngredient { get { return _NameOfIngredient; } set { _NameOfIngredient = value; } }
        private string _Unit = "";
        public string Unit { get { return _Unit; } set { _Unit = value; } }

        private UInt32 _Count = 0;
        public UInt32 Count { get { return _Count; } set { _Count = value; } }
    }

    [Serializable()]
    public class Meal
    {
        private string _ImageSource = "";
        public string ImageSource { get { return _ImageSource; } set { _ImageSource = value; } }

        private string _NameOfMeal = "";
        public string NameOfMeal { get { return _NameOfMeal; } set { _NameOfMeal = value; } }

        private decimal _Duration = default(decimal);
        public decimal Duration { get { return _Duration; } set { _Duration = value; } }

        private UInt32 _Count = 0;
        public UInt32 Count { get { return _Count; } set { _Count = value; } }

        public ObservableCollection<Ingredient> _Ingredients;
        private List<string> _CookingOrder ;
        public List<string> CookingOrder { get { return _CookingOrder; } set { _CookingOrder = value; } }
        public Meal()
        {
            _Ingredients = new ObservableCollection<Ingredient>();
            _CookingOrder= new List<string>();
        }        
        public void AddIngredient(Ingredient i)
        {
            _Ingredients.Add(i);
        }
    }

    public class MealList
    {
        ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        public ObservableCollection<Meal> Get()
        {
            return meals;
        }
    }
}
