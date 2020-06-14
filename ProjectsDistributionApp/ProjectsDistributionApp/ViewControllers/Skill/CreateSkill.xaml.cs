using DiplomConsole.DataBase;
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
    /// Interaction logic for CreateSkill.xaml
    /// </summary>
    public partial class CreateSkill : Window
    {
        public CreateSkill()
        {
            InitializeComponent();
        }
        private void Submit(object sender, RoutedEventArgs e)
        {
            var skills = new List<string>();
            skills.Add(SkillName.Text);
            Context.AddSkill(skills);
            this.Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
