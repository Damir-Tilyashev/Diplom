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
    /// Interaction logic for ViewPersonnel.xaml
    /// </summary>
    public partial class ViewPersonnel : Window
    {
        private EmployeeInfo current;
        public ViewPersonnel(int id)
        {
            InitializeComponent();
            current = new EmployeeInfo(id);
            SecondName.Text = current.SecondName;
            FirstName.Text = current.FirstName;
            Patronymic.Text = current.Patronymic;
            Position.Text = current.Position;
            MaxLoad.Text = current.MaxLoad.ToString();
            Skills.ItemsSource = current
                .Skills
                .Select
                (a=> new 
                { 
                    Skill = a.SkillName, 
                    Value = Context
                    .GetAllEmployeeSkills()
                    .Where(b => b.Employee.EmployeeId == id)
                    .Select(b => b.SkillPoint)
                });
        }
        private void ChangeThisEmployee(object sender, RoutedEventArgs e)
        {
            var window = new ModifyPersonnel(current);
            window.Show();
        }
        private void DeleteThisEmployee(object sender, RoutedEventArgs e)
        {
            /*RemoveEmployee*/
        }
        private void ViewRole(object sender, RoutedEventArgs e)
        {
            var window = new ViewAssignments(current.Id);
            window.Show();
        }
    }
}
