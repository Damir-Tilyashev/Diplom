using System;
using System.Collections.Generic;
using System.Text;
using DiplomConsole.DataBase;
using System.Linq;
namespace ProjectsDistributionApp.Models
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string SecondName { get; private set; }
        public string FirstName { get; private set; }
        public string Patronymic { get; private set; }
        public string Position { get; private set; }
        public int MaxLoad { get; private set; }
        public List<SkillNode> Skills { get; private set; }
        public List<string> Projects { get; private set; }
        public Dictionary<string, List<string>> Roles { get; private set; }
        public EmployeeInfo(int id)
        {
            var emp = Context.GetEmployeeWithId(new[] { id }.ToList())[0];
            if (emp == null)
            {
                Id = id;
                SecondName = "Empty";
                FirstName = "Empty";
                Patronymic = "Empty";
                Skills = new List<SkillNode>();
                Skills.Add(new SkillNode(0, "Empty"));
                MaxLoad = 0;
            }
            else
            {
                Id = id;
                SecondName = emp.SecondName;
                FirstName = emp.FirstName;
                Patronymic = emp.Patronymic;
                Skills = Context
                    .GetAllEmployeeSkills()
                    .Where(a => a.Employee.EmployeeId == id)
                    .Select(a => new SkillNode(a.Skill.SkillId, a.Skill.SkillName))
                    .ToList();
                MaxLoad = emp.MaxLoad;
            }
            /*Implication of getting projects and roles*/
            /*End of implication*/
        }
    }
}
