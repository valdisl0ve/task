using System;
using System.Collections.Generic;
using System.IO;
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

namespace tusks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Dictionary<string, string> list_of_tusk = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            //List<string> test = new List<string>() { "To buy", "To do", " To read", "Else" };

            
            list_of_tusk.Add("To buy", "to buy.txt");
            list_of_tusk.Add("To do", "to do.txt");
            list_of_tusk.Add("To read", "to read.txt");
            list_of_tusk.Add("Else", "else.txt");


            /*
           foreach (object item in test)
           {
               tusklist.Items.Add((string)item);
           }
            */

            foreach (object item in list_of_tusk.Keys)
            {
                tusklist.Items.Add((string)item);
            }
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            list_of_tusk.Add(new_tusk.Text, new_tusk + ".txt");


            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + new_tusk.Text + ".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Write something to do later");
                fs.Write(info, 0, info.Length);
            }


            tusklist.Items.Clear();
            foreach (object item in list_of_tusk.Keys)
            {
                tusklist.Items.Add((string)item);
            }
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            string choose = tusklist.SelectedItem.ToString();

            //tusks.Content = 

            using (StreamReader sr = new StreamReader(choose + ".txt"))
            {
                tusks.Text = sr.ReadToEnd();
            }
        }

        private void write_Click(object sender, RoutedEventArgs e)
        {
            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + tusklist.SelectedItem.ToString() + ".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(tusks.Text);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
