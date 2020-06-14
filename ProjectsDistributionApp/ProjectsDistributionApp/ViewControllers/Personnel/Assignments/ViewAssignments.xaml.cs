using DiplomConsole.DataBase;
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

namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for ViewAssignments.xaml
    /// </summary>
    public partial class ViewAssignments : Window
    {
        private List<Requirement> Appointments;
        public ViewAssignments(int empId)
        {
            InitializeComponent();
            Appointments = Context
                .GetThisEmployeeReq(Context
                .GetEmployeeWithId((new[] { empId }).ToList()).First());
            Assignments.ItemsSource =
                Appointments
                .Select(a => new { Project = a.Project.ProjectName, Role = a.RequirementDescription});
        }
    }
}
