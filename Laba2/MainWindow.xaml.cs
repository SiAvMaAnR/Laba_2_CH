using GalaSoft.MvvmLight.Command;
using Laba2.Models;
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

namespace Laba2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainModel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainModel;
            Closing += MainModel.OnWindowClosing;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MainViewModel.XmlToList();
            MainViewModel.ListToCollections();
        }
    }
}
