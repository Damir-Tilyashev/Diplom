using DiplomConsole.DataBase;
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
    /// Interaction logic for AddRole.xaml
    /// </summary>
    public partial class AddRole : Window
    {
        private ObservableCollection<Skill> skills = Context.GetAllSkill().Count > 0 ?
            new ObservableCollection<Skill>(Context.GetAllSkill()) :
            new ObservableCollection<Skill>(new Skill[] { new Skill { SkillId = 0, SkillName = "Empty" } });
        public AddRole()
        {
            InitializeComponent();
        }
        private void AddSkill(object sender, RoutedEventArgs e)
        {
            var skillComboBox = new ComboBox();
            skillComboBox.ItemsSource = skills.Select(a => a.SkillName);
            var value = new TextBox();
            value.Width = 30;
            value.Height = 30;
            var panel = new WrapPanel();
            panel.Orientation = Orientation.Horizontal;
            panel.Children.Add(skillComboBox);
            panel.Children.Add(value);
            SkillsList.Items.Add(panel);
        }
    }
}
