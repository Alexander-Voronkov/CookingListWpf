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
using System.Collections.ObjectModel;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для IngredientsList.xaml
    /// </summary>
    public partial class IngredientsList : Window
    {
        public IngredientsList(ref ObservableCollection<Ingredient> l)
        {
            InitializeComponent();
            ingredientlist.ItemsSource = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (ingredientlist.ItemsSource as ObservableCollection<Ingredient>).Remove(ingredientlist.SelectedItem as Ingredient);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddIngredient win = new AddIngredient();
            win.ShowDialog();
            (ingredientlist.ItemsSource as ObservableCollection<Ingredient>).Add(win.i);
        }
    }
}
