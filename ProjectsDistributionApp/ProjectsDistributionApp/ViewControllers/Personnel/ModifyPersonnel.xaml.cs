using DiplomConsole.DataBase;
using ProjectsDistributionApp.Models;
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
    /// Interaction logic for ModifyPersonnel.xaml
    /// </summary>
    public partial class ModifyPersonnel : Window
    {
        private ObservableCollection<Skill> skills = Context.GetAllSkill().Count > 0 ?
            new ObservableCollection<Skill>(Context.GetAllSkill()) :
            new ObservableCollection<Skill>(new Skill[] { new Skill { SkillId = 0, SkillName = "Empty" } });
        public EmployeeInfo Info;
        public ModifyPersonnel(EmployeeInfo info)
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
        private void Submit(object sender, RoutedEventArgs e)
        {
            var emp = new Employee();
            emp.SecondName = SecondName.Text;
            emp.FirstName = FirstName.Text;
            emp.Patronymic = Patronymic.Text;
            emp.MaxLoad = int.Parse(MaxLoad.Text);
            if (emp.MaxLoad > 100 || emp.MaxLoad < 0)
                throw new ArgumentException();
            /*var skillList = new Dictionary<Skill, int>();
            foreach (var it in SkillsList.Items)
            {
                var skill = skills
                    .Where(a => a.SkillName == ((it as WrapPanel).Children[0] as ComboBox).SelectedItem as string)
                    .FirstOrDefault();
                var value = int.Parse(((it as WrapPanel).Children[1] as TextBox).Text);
                if (value > 100 || value < 0)
                    throw new ArgumentException();
                skillList.Add(skill, value);
            }*/
            //Context.AddEmployeeSkill
            Context.RewriteEmployee(Info.Id, emp);
            this.Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
