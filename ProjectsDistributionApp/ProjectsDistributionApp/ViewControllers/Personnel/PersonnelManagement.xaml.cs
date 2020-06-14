using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjectsDistributionApp.Models;
using ProjectsDistributionApp.Utils;
using System.Collections.ObjectModel;
namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for PersonnelManagement.xaml
    /// </summary>
    public partial class PersonnelManagement : Window
    {
        private ObservableCollection<EmployeeListNode> list =
            new ObservableCollection<EmployeeListNode>
            (ControllerOperations.EmployeeList.Count > 0 ?
            ControllerOperations.EmployeeList :
            new EmployeeListNode[]
            { new EmployeeListNode(0, "Empty", string.Empty, string.Empty, "Empty", 0) }
            .ToList());
        public PersonnelManagement()
        {
            InitializeComponent();
            personnelList.ItemsSource = list;
            personnelList.SelectedItem = personnelList.Items[0];
        }
        private void ViewPerson(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var window = new ViewPersonnel((item as EmployeeListNode).Id);
            window.Show();
        }
        private void AddPerson(object sender, RoutedEventArgs e)
        {
            var window = new CreatePersonnel();
            window.Show();
        }
        private void Back(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            Close();
        }
    }
}
