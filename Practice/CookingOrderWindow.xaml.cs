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

namespace Practice
{
    /// <summary>
    /// Логика взаимодействия для CookingOrderWindow.xaml
    /// </summary>
    public partial class CookingOrderWindow : Window
    {
        public List<string> order=new List<string>();
        public CookingOrderWindow(List<string> s)
        {
            InitializeComponent();
            order = s;
            string temp = "";
            foreach (var item in s)
            {
                temp += item+"\n";
            }
            richtextboxorder.SetText(temp);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            order=richtextboxorder.GetText().Split('\n').ToList<string>();
        }
    }
    public static class Ext
    {
        public static void SetText(this System.Windows.Controls.RichTextBox richTextBox, string text)
        {
            richTextBox.Document.Blocks.Clear();
            richTextBox.Document.Blocks.Add(new Paragraph(new Run(text)));
        }

        public static string GetText(this System.Windows.Controls.RichTextBox richTextBox)
        {
            return new TextRange(richTextBox.Document.ContentStart,
                richTextBox.Document.ContentEnd).Text;
        }
    }
}
