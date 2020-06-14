using ProjectsDistributionApp.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ProjectsDistributionApp.ViewControllers
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class ViewRole : Window
    {
        private Role roleInfo;
        public ViewRole(Role role)
        {
            InitializeComponent();
            roleInfo = role;
            RoleName.Text = role.Name;
            Skills.ItemsSource = new ObservableCollection<string>
                (role
                .RequiredSkills
                .Select(a => a.SkillName));
            EmployeeName.Text = 
                role.Employee.SecondName + " " + 
                role.Employee.FirstName + " " + 
                role.Employee.Patronymic;
        }
    }
}
