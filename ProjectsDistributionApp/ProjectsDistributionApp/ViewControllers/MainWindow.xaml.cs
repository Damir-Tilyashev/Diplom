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

namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void RedirectToPersonnelManagement(object sender, RoutedEventArgs e)
        {
            var newWindow = new PersonnelManagement();
            newWindow.Show();
            Close();
        }
        private void RedirectToProjectManagement(object sender, RoutedEventArgs e)
        {
            var newWindow = new ProjectManagement();
            newWindow.Show();
            Close();
        }
        private void RedirectToSkillsManagement(object sender, RoutedEventArgs e)
        {
            var newWindow = new SkillsManagement();
            newWindow.Show();
            Close();
        }
        private void Redistribute(object sender, RoutedEventArgs e)
        {
            /*Redistr*/
        }
    }
}
