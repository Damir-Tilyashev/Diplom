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

        public static void AddEmployee(Employee employee, Dictionary<Skill, int> employeeskill) //Добавление нового сотрудника. На вход даётся объект сотрудник и словарь объектов Навык и значение в какой степени сотрудник им владеет
        {
            if (context.Employees.Where(x => x.FirstName == employee.FirstName && x.SecondName == employee.SecondName && x.Patronymic == employee.Patronymic).FirstOrDefault() == null)//.Where(x=>x.FirstName==employee.FirstName && x.SecondName==employee.SecondName))
            {
                context.Employees.Add(employee);
                context.SaveChanges();
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

        public static void AddProject(Project newproject, Dictionary<Requirement, List<RequirementSkill>> requirements) //Добавление нового проекта. На вход подаётся объект Проект, и словарь, где ключ - Объект требование, а значение это лист объектов ТребованиеНавык
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

            foreach (var requirement in requirements)
            {
                requirement.Key.Project = context.Projects.Where(x => x.ProjectId == context.Projects.Count()).FirstOrDefault();
                context.Requirements.Add(requirement.Key);
                context.SaveChanges();
                foreach (var requirementskill in requirement.Value)
                {
                    requirementskill.Requirement = context.Requirements.Where(x => x.RequirementId == context.Requirements.Count()).FirstOrDefault();
                    context.RequirementSkill.Add(requirementskill);
                    context.SaveChanges();
                }
            }
        }

        public static void AddSkill(List<string> names) //Добавление навыка. На вход идёт Лист навыков
        {
            Skill skill = new Skill();
            foreach (var name in names)
            {
                skill.SkillName = name;
                context.Skills.Add(skill);
                context.SaveChanges();
            }
        }

        public static void AddRequirement(Dictionary<Requirement, List<RequirementSkill>> requirements) //Добавить отдельно требование. Т.е. если во время добавления проекта что-то забыл добавить, то это можно сделать отдельно
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
        public static void AddEmployeeRequirement(List<EmployeeRequirement> employeeRequirements) //Добавить СотрудникТребование. Если коротко, то это нужно, чтобы вручную назначать сотрудника на роль
        {
            context.EmployeeRequirements.AddRange(employeeRequirements);
            context.SaveChanges();
        }
        public static void RewriteEmployee(int employeeId, Employee newemployee) //Изменение информации о сотруднике. На вход подаётся ID сотрудника и новая информация
        {
            var employee = context.Employees.Where(u => u.EmployeeId == employeeId).FirstOrDefault();
            employee.FirstName = newemployee.FirstName;
            employee.SecondName = newemployee.SecondName;
            employee.Patronymic = newemployee.Patronymic;
            employee.MaxLoad = newemployee.MaxLoad;
            context.SaveChanges();
        }
        public static void RewriteProject(int ProjectId, Project newproject) //Изменение проекта. На вход ID проекта и новая информация
        {
            var project = context.Projects.Where(u => u.ProjectId == ProjectId).FirstOrDefault();
            project.ProjectName = newproject.ProjectName;
            project.ProjectDescription = newproject.ProjectDescription;
            project.Status = newproject.Status;
            project.Priority = newproject.Priority;
            context.SaveChanges();
        }
        public static void RewriteSkill(int skillId, Skill newskill) //Изменение навыков
        {
            var skill = context.Skills.Where(u => u.SkillId == skillId).FirstOrDefault();
            skill.SkillName = newskill.SkillName;
            context.SaveChanges();
        }
        public static void RewriteRequirement(int requirementId, Requirement newrequirement) // Изменить требование
        {
            var requirement = context.Requirements.Where(u => u.RequirementId == requirementId).FirstOrDefault();
            requirement.RequirementDescription = newrequirement.RequirementDescription;
            requirement.Start = newrequirement.Start;
            requirement.End = newrequirement.End;
            requirement.EmployeeLoad = newrequirement.EmployeeLoad;
            context.SaveChanges();
        }
        public static List<EmployeeSkill> GetAllEmployeeSkills() //Получить все навыки всех сотрудников
        {
            var employeeskills = context.EmployeeSkills.Include(x=>x.Skill).ToList();
            return employeeskills;
        }

        public static List<Project> GetProjectsByStatus(int Status) //Получить список все проектов с определённым статусом
        {
            var project = context.Projects.Where(u => u.Status == Status).ToList();
            return project;
        }

        public static List<Employee> GetAllEmployee() // Получить список всех сотрудников
        {
            var employee = context.Employees.ToList();
            return employee;
        }

        public static List<Skill> GetAllSkill() // Получить список всех навыков
        {
            var skill = context.Skills.ToList();
            return skill;
        }

        public static List<Requirement> GetRequirementWithProject(Project project) //Получить список всех требований определённого проекта
        {
            var requerements = context.Requirements.Where(x => x.Project.ProjectId == project.ProjectId).ToList();
            return requerements;
        }
        public static List<RequirementSkill> GetRequirementSkill(Requirement requirement) //Получить список навыков определённого требования
        {
            var reqskill = context.RequirementSkill.Where(x => x.Requirement.RequirementId == requirement.RequirementId).Include(x=>x.MainSkill).ToList();
            return reqskill;
        }

        public static List<Requirement> GetThisEmployeeReq(Employee employee) //Получить список всех требований, где задействован определённый сотрудник
        {
            var requrements = context.Requirements.Where(x => x.EmployeeRequirement.Employees.EmployeeId == employee.EmployeeId).ToList();
            return requrements;
        }

        public static List<Employee> GetEmployeeWithId(List<int> ids) //Получить список сотрудников по их ID
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
