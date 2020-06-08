using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DiplomConsole.DataBase
{
    class Context : DbContext
    {
        public static Context context = new Context();
        public Context() : base("DefaultConnection")
        {
            // Указывает EF, что если модель изменилась,
            // нужно воссоздать базу данных с новой структурой
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }
        public DbSet<RequirementSkill> RequirementSkill { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeRequirement> EmployeeRequirements { get; set; }

        public static void AddEmployee(Employee employee, Dictionary<Skill, int> employeeskill)
        {
            if (context.Employees.Where(x => x.FirstName == employee.FirstName && x.SecondName == employee.SecondName && x.Patronymic == employee.Patronymic).FirstOrDefault() == null)//.Where(x=>x.FirstName==employee.FirstName && x.SecondName==employee.SecondName))
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                //Employee employee1 = context.Employees.Where(x => x.EmployeeId == context.Employees.Count()).FirstOrDefault();
                EmployeeSkill employeeSkill = new EmployeeSkill();
                foreach (var skill in employeeskill)
                {
                    employeeSkill.Employee = context.Employees.Where(x => x.EmployeeId == context.Employees.Count()).FirstOrDefault();
                    employeeSkill.Skill = skill.Key;
                    employeeSkill.SkillPoint = skill.Value;
                    context.EmployeeSkills.Add(employeeSkill);
                    context.SaveChanges();
                }
            }
            return;
        }

        public static void RewriteEmployee(int employeeId, Employee newemployee)
        {
            var employee = context.Employees.Where(u => u.EmployeeId == employeeId).FirstOrDefault();
            employee.FirstName = newemployee.FirstName;
            employee.SecondName = newemployee.SecondName;
            employee.Patronymic = newemployee.Patronymic;
            employee.MaxLoad = newemployee.MaxLoad;
            context.SaveChanges();
        }
        public static void AddProject(Project newproject, Dictionary<Requirement, List<RequirementSkill>> requirements)
        {
            Project project = new Project
            {
                ProjectName = newproject.ProjectName,
                ProjectDescription = newproject.ProjectDescription,
                Status = newproject.Status,
                Priority = newproject.Priority,
                Start = newproject.Start,
                End = newproject.End
            };
            context.Projects.Add(project);
            context.SaveChanges();
            //project = new Project();
            //project = context.Projects.Last();
            //project = context.Projects.Where(x => x.ProjectId == context.Projects.Count()).FirstOrDefault();
            foreach(var requirement in requirements)
            {
                requirement.Key.Project = context.Projects.Where(x => x.ProjectId == context.Projects.Count()).FirstOrDefault();
                context.Requirements.Add(requirement.Key);
                context.SaveChanges();
                foreach(var requirementskill in requirement.Value)
                {
                    //requirementskill.Requirement = context.Requirements.Last();
                    requirementskill.Requirement = context.Requirements.Where(x=>x.RequirementId == context.Requirements.Count()).FirstOrDefault();
                    context.RequirementSkill.Add(requirementskill);
                    context.SaveChanges();
                }
            }
        }

        public static void RewriteProject(int ProjectId, Project newproject)
        {
            var project = context.Projects.Where(u => u.ProjectId == ProjectId).FirstOrDefault();
            project.ProjectName = newproject.ProjectName;
            project.ProjectDescription = newproject.ProjectDescription;
            project.Status = newproject.Status;
            project.Priority = newproject.Priority;
            context.SaveChanges();
        }

        public static void AddSkill(List<string> names)
        {
            Skill skill = new Skill();
            foreach (var name in names)
            {
                skill.SkillName = name;
                context.Skills.Add(skill);
                context.SaveChanges();
            }
        }

        public static void RewriteSkill(int skillId, Skill newskill)
        {
            var skill = context.Skills.Where(u => u.SkillId == skillId).FirstOrDefault();
            skill.SkillName = newskill.SkillName;
            context.SaveChanges();
        }

        public static void AddRequirement(Dictionary<Requirement, List<RequirementSkill>> requirements)
        {
            foreach (var requirement in requirements)
            {
                context.Requirements.Add(requirement.Key);
                context.SaveChanges();
                foreach (var requirementskill in requirement.Value)
                {
                    requirementskill.Requirement = context.Requirements.Last();
                    context.RequirementSkill.Add(requirementskill);
                    context.SaveChanges();
                }
            }
        }

        public static void RewriteRequirement(int requirementId, Requirement newrequirement)
        {
            var requirement = context.Requirements.Where(u => u.RequirementId == requirementId).FirstOrDefault();
            requirement.RequirementDescription = newrequirement.RequirementDescription;
            requirement.Start = newrequirement.Start;
            requirement.End = newrequirement.End;
            requirement.EmployeeLoad = newrequirement.EmployeeLoad;
            context.SaveChanges();
        }

        public static void AddEmployeeRequirement(List<EmployeeRequirement> employeeRequirements)
        {
            context.EmployeeRequirements.AddRange(employeeRequirements);
            context.SaveChanges();
        }
        public static List<EmployeeSkill> GetAllEmployeeSkills()
        {
            var employeeskills = context.EmployeeSkills.Include(x=>x.Skill).ToList();
            return employeeskills;
        }

        public static void DeleteProject(int ProjectId)
        {

        }

        public static List<Project> GetProjectsByStatus(int Status)
        {
            var project = context.Projects.Where(u => u.Status == Status).ToList();
            return project;
        }

        public static List<Employee> GetAllEmployee()
        {
            var employee = context.Employees.ToList();
            return employee;
        }

        public static List<Skill> GetAllSkill()
        {
            var skill = context.Skills.ToList();
            return skill;
        }

        public static List<Requirement> GetRequirementWithProject(Project project)
        {
            var requerements = context.Requirements.Where(x => x.Project.ProjectId == project.ProjectId).ToList();
            return requerements;
        }
        public static List<RequirementSkill> GetRequirementSkill(Requirement requirement)
        {
            var reqskill = context.RequirementSkill.Where(x => x.Requirement.RequirementId == requirement.RequirementId).Include(x=>x.MainSkill).ToList();
            return reqskill;
        }

        public static List<Requirement> GetThisEmployeeReq(Employee employee)
        {
            var requrements = context.Requirements.Where(x => x.EmployeeRequirement.Employees.EmployeeId == employee.EmployeeId).ToList();
            return requrements;
        }
        public static void GetRequirement(List<int> ID)
        {

        }

        public static List<Employee> GetEmployeeWithId(List<int> ids)
        {
            var employee = context.Employees.ToList();
            List<Employee> emp = new List<Employee>();
            foreach (int id in ids)
            {
                emp.Add(employee.Where(x => x.EmployeeId == id).FirstOrDefault());
            }
            return emp;
        }
        public static Employee GiveComputer()
        {
            var computer = context.Employees.Where(x => x.FirstName == "Computer").FirstOrDefault();
            return computer;
        }
    }
}
