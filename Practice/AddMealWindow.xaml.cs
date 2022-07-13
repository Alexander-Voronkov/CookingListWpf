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
using System.Windows.Forms;
using System.IO;

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для AddMealWindow.xaml
    /// </summary>
    public partial class AddMealWindow : Window
    {
        public Meal meal = new Meal();
        public AddMealWindow()
        {
            InitializeComponent();
            this.DataContext = meal;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameofmealtextbox.Text) || string.IsNullOrEmpty(counttextbox.Text) || string.IsNullOrEmpty(durationtextbox.Text))
                return;
            else
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                meal.ImageSource=sfd.FileName;
            }
        }
    }
}
