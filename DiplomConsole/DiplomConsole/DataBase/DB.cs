using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Text;

namespace DiplomConsole.DataBase
{

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int MaxLoad { get; set; }
        public string Position { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }
        public ICollection<EmployeeRequirement> EmployeeRequirements { get; set; }
        public ICollection<EmployeeRequirement> Appointment { get; set; }
        public Employee()
        {
            EmployeeSkills = new List<EmployeeSkill>();
            EmployeeRequirements = new List<EmployeeRequirement>();
            Appointment = new List<EmployeeRequirement>();
        }
    }

    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public List<EmployeeSkill> EmployeeSkills { get; set; }

        public ICollection<RequirementSkill> MainSkill { get; set; }
        public Skill()
        {
            MainSkill = new List<RequirementSkill>();
        }
    }

    public class EmployeeSkill
    {
        public int EmployeeSkillId { get; set; }

        public int SkillPoint { get; set; }
        public Employee Employee { get; set; }
        public Skill Skill { get; set; }
    }

    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public List<Requirement> Requirements { get; set; }
    }

    public class Requirement
    {
        public int RequirementId { get; set; }
        public string RequirementDescription { get; set; }

        public int EmployeeLoad { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Project Project { get; set; }
        public EmployeeRequirement EmployeeRequirement { get; set; }
        public List<RequirementSkill> RequirementSkills { get; set; }
    }

    public class RequirementSkill
    {
        public int RequirementSkillId { get; set; }

        public Skill MainSkill { get; set; }
        public int MainSkillPoint { get; set; }
        public Requirement Requirement { get; set; }
    }
    public class EmployeeRequirement
    {
        [Key]
        [ForeignKey("Requirement")]
        public int EmployeeRequirementId { get; set; }
        public int Status { get; set; }
        public Employee Employees { get; set; }
        public Requirement Requirement { get; set; }
        public Employee Appointment { get; set; }
        public DateTime EndDate { get; set; }
    }
}
