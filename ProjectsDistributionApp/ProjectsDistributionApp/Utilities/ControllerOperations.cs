using System.Collections.Generic;
using System.Linq;
using ProjectsDistributionApp.Models;
using DiplomConsole.DataBase;
using System.Windows;

namespace ProjectsDistributionApp.Utils
{
    public static class ControllerOperations
    {
        public static List<EmployeeListNode> EmployeeList
        {
            get
            {
                return Context.GetAllEmployee()
                    .Select(a => new 
                    EmployeeListNode(
                        a.EmployeeId, 
                        a.SecondName, 
                        a.FirstName,
                        a.Patronymic,
                        a.Position,
                        a.MaxLoad))
                    .ToList();
            }
        }
        public static List<SkillNode> SkillList
        {
            get
            {
                return Context.GetAllSkill()
                    .Select(a => new SkillNode(
                        a.SkillId,
                        a.SkillName))
                    .ToList();
            }
        }
        public static List<ProjectListNode> ProjectList
        {
            get
            {
                return new List<ProjectListNode>();
                //return Context.GetAllProject();
            }
        }
    }
}
