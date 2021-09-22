using System;
using System.Collections.Generic;
//using System.Data.SQLite;
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

namespace ToDo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;

        

        Dictionary<string, string> taskList = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();

            //db.DB_connect = new SQLiteConnection("Data Source=db.db");
            //db.DB_connect.Open();

            create.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Hidden;
            todoContentAll.Visibility = Visibility.Collapsed;



            taskList.Add("To buy", "to buy.txt");
            // taskList.Add("To do", "to do.txt");
            // taskList.Add("To read", "to read.txt");
            // taskList.Add("Else", "else.txt");


            foreach (object item in taskList.Keys)
            {
                listboxTask.Items.Add((string)item);
            }


         
    

    }

        private void add_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void new_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Collapsed;
            create.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
        }

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Visible;
            create.Visibility = Visibility.Collapsed;

            taskList.Add(newTask.Text, newTask.Text + ".txt");


            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + newTask.Text + ".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes("Write something to do later");
                fs.Write(info, 0, info.Length);
            }


            listboxTask.Items.Clear();
            foreach (object item in taskList.Keys)
            {
                listboxTask.Items.Add((string)item);
            }


            Todo_table todo_table = new Todo_table(newTask.Text, "Write something to do late", 0);

            db.Todo_table.Add(todo_table);
            db.SaveChanges();


        }

        private void listboxTask_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            newTask.Text = "";
            todoContentAll.Visibility = Visibility.Visible;
            backButton.Visibility = Visibility.Visible;
            listboxTask.Visibility = Visibility.Collapsed;
            Create_new_list.Visibility = Visibility.Hidden;
            string choose = listboxTask.SelectedItem.ToString();
            

            

            using (StreamReader sr = new StreamReader(choose + ".txt"))
            {
                todoContent.Text = sr.ReadToEnd();
            }
        }


        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            start.Visibility = Visibility.Visible;
            create.Visibility = Visibility.Collapsed;
            backButton.Visibility = Visibility.Hidden;


            todoContentAll.Visibility = Visibility.Collapsed;
            listboxTask.Visibility = Visibility.Visible;
            Create_new_list.Visibility = Visibility.Visible;




        }

        private void save_Click(object sender, RoutedEventArgs e)
        {


            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + listboxTask.SelectedItem.ToString() + ".txt"))
            {
                byte[] info = new UTF8Encoding(true).GetBytes(todoContent.Text);
                fs.Write(info, 0, info.Length);
            }



        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
          
            taskList.Remove(listboxTask.SelectedItem.ToString());

            listboxTask.Items.Clear();

            foreach (object item in taskList.Keys)
            {
                listboxTask.Items.Add((string)item);
            }
        }
    }
}
