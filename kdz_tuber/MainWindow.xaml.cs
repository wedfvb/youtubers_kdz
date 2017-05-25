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
using System.IO;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Data;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace kdz_tuber
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string filepath = "data.txt";
        

        [Serializable]
        public class Tuber
        {
            public string Name { get; set; }
            public int Subscribers { get; set; }
            public int Views { get; set; }
            public string Genre { get; set; }
        }

        
        IList<Tuber> AnotherList = new List<Tuber>();

        





        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            
        }

        //event загрузки окна
        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxPathDisplay.Text = filepath;

            AnotherList.Add(new Tuber()
                {
                    Name = "AngelSix",
                    Subscribers = 2386,
                    Views = 212463,
                    Genre = "Software"
                });
            AnotherList.Add(new Tuber()
                {
                    Name = "theneedledrop",
                    Subscribers = 1000003,
                    Views = 221712420,
                    Genre = "Music"
                });
            AnotherList.Add(new Tuber()
                {
                    Name = "Timecop1983",
                    Subscribers = 9667,
                    Views = 1468983,
                    Genre = "Music"
                });
            AnotherList.Add(new Tuber()
            {
                Name = "Vsauce",
                Subscribers = 12037975,
                Views = 1203805324,
                Genre = "Science"
            });

            TheGrid.ItemsSource = AnotherList;
            

        }

      

        //кнопка смены пути к файлу с данными
        private void ButtonChangePath_Click(object sender, RoutedEventArgs e)
        {
            PathWindow pathWindow = new PathWindow();
            pathWindow.ShowDialog();
            TextBoxPathDisplay.Text = filepath;
         }



        //кнопка сериализации в filepath
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamSer = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(streamSer, AnotherList);
            streamSer.Close();
            
            MessageBoxResult result = MessageBox.Show("Your data is saved.");
        }



        //кнопка десериализации из filepath
        private void ButtonLoad_Click(object sender, RoutedEventArgs e)
        {

            IFormatter formatter = new BinaryFormatter();
            Stream streamSer = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Tuber> AnotherList = (List<Tuber>)formatter.Deserialize(streamSer);
            TheGrid.ItemsSource = AnotherList;
            streamSer.Close();


            MessageBoxResult result = MessageBox.Show("Data is successfully loaded");

        }



        //кнопка поиска
        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < TheGrid.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)TheGrid.ItemContainerGenerator.ContainerFromIndex(i);
                TextBlock cellContent = TheGrid.Columns[1].GetCellContent(row) as TextBlock;
                if (cellContent != null && cellContent.Text.Equals(SearchBox.Text))
                {
                    object item = TheGrid.Items[i];
                    TheGrid.SelectedItem = item;
                    TheGrid.ScrollIntoView(item);
                    row.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                    break;
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
