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
    /// Interaction logic for SkillsManagement.xaml
    /// </summary>
    public partial class SkillsManagement : Window
    {
        private ObservableCollection<SkillNode> list =
            new ObservableCollection<SkillNode>
            (ControllerOperations.SkillList.Count > 0 ?
            ControllerOperations.SkillList :
            new SkillNode[]
            { new SkillNode(0, "Empty") }
            .ToList());
        public SkillsManagement()
        {
            InitializeComponent();
            skillList.ItemsSource = list;
            skillList.SelectedItem = skillList.Items[0];
        }
        private void AddSkill(object sender, RoutedEventArgs e)
        {
            var window = new CreateSkill();
            window.Show();
        }
        private void ModifySkill(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            var window = new ModifySkill((item as SkillNode));
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
