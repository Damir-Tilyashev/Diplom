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
using ProjectsDistributionApp.Models;
namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for ViewProject.xaml
    /// </summary>
    public partial class ViewProject : Window
    {
        private ProjectInfo projectInfo;
        public ViewProject(int id)
        {
            InitializeComponent();
            projectInfo = new ProjectInfo(id);
            Name.Text = projectInfo.Name;
            Description.Text = projectInfo.Description;
            StatusInfo.Text = projectInfo.Status;
            Priority.Text = projectInfo.Priority.ToString();
            Begin.Text = projectInfo.Start.ToString();
            End.Text = projectInfo.End.ToString();
            Roles.ItemsSource = new ObservableCollection<string>(projectInfo
                    .Roles
                    .Select(a => a.Name)
                    .ToList());
            Roles.SelectedItem = Roles.Items[0];
        }
        private void ViewRole(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var window = new ViewRole(projectInfo
                .Roles
                .Where(a => a.Name == (item as string))
                .FirstOrDefault());
            window.Show();
        }
    }
}
