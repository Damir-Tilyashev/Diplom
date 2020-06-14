using ProjectsDistributionApp.Models;
using ProjectsDistributionApp.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for ProjectManagement.xaml
    /// </summary>
    public partial class ProjectManagement : Window
    {
        private ObservableCollection<ProjectListNode> list =
            new ObservableCollection<ProjectListNode>
            (ControllerOperations.ProjectList.Count > 0 ?
            ControllerOperations.ProjectList :
            new ProjectListNode[]
            { new ProjectListNode(0, "empty", 3, 0, DateTime.Now, DateTime.Now) }
            .ToList());
        public ProjectManagement()
        {
            InitializeComponent();
            projectList.ItemsSource = list;
            projectList.SelectedItem = projectList.Items[0];
        }
        private void ViewProject(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var window = new ViewProject((item as ProjectListNode).Id);
            window.Show();
        }
        private void AddProject(object sender, RoutedEventArgs e)
        {
            var window = new CreateProject();
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
