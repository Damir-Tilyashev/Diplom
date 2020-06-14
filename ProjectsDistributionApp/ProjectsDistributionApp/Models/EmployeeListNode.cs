using System.Windows;
using System.Text;
using System.Windows.Controls;
using ProjectsDistributionApp.Utils;
using ProjectsDistributionApp.ViewControllers;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Documents;

namespace ProjectsDistributionApp.Models
{
    public class EmployeeListNode
    {
        public int Id {get;private set;}
        public string FullName { get; private set; }
        public string Position { get; private set; }
        public int MaxLoad { get; private set; }
        public EmployeeListNode
            (int id, 
            string secondName, 
            string firstName, 
            string patronymic,
            string position,
            int maxLoad)
        {
            Id = id;
            var full = new StringBuilder();
            full.Append(secondName + " ");
            full.Append(firstName + " ");
            full.Append(patronymic);
            FullName = full.ToString();
            Position = position;
            MaxLoad = maxLoad;
        }

    }
}
