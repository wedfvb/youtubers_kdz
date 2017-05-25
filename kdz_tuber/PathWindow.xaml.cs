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

namespace kdz_tuber
{
    /// <summary>
    /// Логика взаимодействия для PathWindow.xaml
    /// </summary>
    public partial class PathWindow : Window
    {
        public PathWindow()
        {
            InitializeComponent();
            Loaded += PathWindow_Loaded;
        }

        private void PathWindow_Loaded(object sender, RoutedEventArgs e)
        {
            PathWindowTextBox.Text = ((MainWindow)Application.Current.MainWindow).filepath;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).filepath = PathWindowTextBox.Text;
            DialogResult = true;

        }
    }
}
