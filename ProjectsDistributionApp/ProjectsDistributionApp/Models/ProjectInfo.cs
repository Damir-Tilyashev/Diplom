using DiplomConsole.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
namespace ProjectsDistributionApp.Models
{
    public class Role
    {
        public string Name;
        public List<SkillNode> RequiredSkills;
        public EmployeeInfo Employee;
        public Role(string name, List<SkillNode> skills, EmployeeInfo employee)
        {
            Name = name;
            Employee = employee;
            RequiredSkills = skills;
        }
    }
    public class ProjectInfo
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Status { get; private set;}
        public int Priority { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public List<Role> Roles { get; private set; }
        public ProjectInfo(int id)
        {
            //var proj = Context.GetProjectWithId();
            Id = 0;
            Name = "Test";
            Description = "Test";
            Status = new Status()[3];
            Priority = 0;
            Start = DateTime.Now;
            End = DateTime.Now;
            Roles = new List<Role>();
            var skills = new List<SkillNode>();
            skills.Add(new SkillNode(0, "Empty"));
            var role = new Role("Empty", skills, new EmployeeInfo(0));
            Roles.Add(role);
        }
    }
}
