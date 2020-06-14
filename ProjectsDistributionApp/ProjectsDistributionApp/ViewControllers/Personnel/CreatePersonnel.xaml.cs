using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Linq;
using DiplomConsole.DataBase;

namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for CreatePersonnel.xaml
    /// </summary>
    public partial class CreatePersonnel : Window
    {
        private ObservableCollection<Skill> skills = Context.GetAllSkill().Count > 0 ?
            new ObservableCollection<Skill>(Context.GetAllSkill()) :
            new ObservableCollection<Skill>(new Skill[] { new Skill { SkillId = 0, SkillName = "Empty" } });
        public CreatePersonnel()
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
            emp.Position = Position.Text;
            emp.MaxLoad = int.Parse(MaxLoad.Text);
            if (emp.MaxLoad > 100 || emp.MaxLoad < 0)
                throw new ArgumentException();
            var skillList = new Dictionary<Skill, int>();
            foreach (var it in SkillsList.Items)
            {
                var skill = skills
                    .Where(a => a.SkillName == ((it as WrapPanel).Children[0] as ComboBox).SelectedItem as string)
                    .FirstOrDefault();
                var value = int.Parse(((it as WrapPanel).Children[1] as TextBox).Text);
                if (value > 100 || value < 0)
                    throw new ArgumentException();
                skillList.Add(skill, value);
            }
            Context.AddEmployee(emp, skillList);
            this.Close();
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
