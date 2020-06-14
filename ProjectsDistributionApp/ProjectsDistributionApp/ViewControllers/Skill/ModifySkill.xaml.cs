using ProjectsDistributionApp.Models;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ModifySkill.xaml
    /// </summary>
    public partial class ModifySkill : Window
    {
        private SkillNode Node;
        public ModifySkill(SkillNode node)
        {
            Node = node;
            InitializeComponent();
            SkillName.Text = Node.SkillName;
        }
        private void Change(object sender, RoutedEventArgs e)
        {

        }
        private void Delete(object sender, RoutedEventArgs e)
        {

        }
        private void Cancel(object sender, RoutedEventArgs e)
        {

        }
    }
}
