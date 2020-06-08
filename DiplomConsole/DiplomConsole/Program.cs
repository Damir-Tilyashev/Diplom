using DiplomConsole.DataBase;
using System;
using System.Data.Entity;
using DiplomConsole.DataBase;
using System.Collections.Generic;
using System.Linq;

namespace DiplomConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Skill, int> emplskill = new Dictionary<Skill, int>();
            Employee employees = new Employee
            {
                FirstName = "Computer",
                SecondName = "Authomatic",
                Patronymic = "System"
            };
            Context.AddEmployee(employees, emplskill);
            Algoritm.Distribution();
            //TestDataSet();
            //List<string> skillname = new List<string>();
            //skillname.Add("Разработчик C#");
            //skillname.Add("Общительность");
            //Context.AddSkill(skillname);
            //Skill skill = new Skill();
            //skill.SkillName = "Разработчик Java";
            //Context.RewriteSkill(1, skill);
            //foreach(var index in Context.GetAllSkill())
            //{
            //    Console.WriteLine(index.SkillId +"   "+ index.SkillName);
            //}
        }
        static void TestDataSet()
        {
            var rand = new Random();
            Employee employees = new Employee();
            Project project = new Project();
            Requirement requirement = new Requirement();
            List<RequirementSkill> requirementSkill = new List<RequirementSkill>();
            List<string> skills = new List<string>();
            Dictionary<Skill, int> emplskill = new Dictionary<Skill, int>();
            Dictionary<Requirement, List<RequirementSkill>> requerskill = new Dictionary<Requirement, List<RequirementSkill>>();
            skills.Add("Программист C#");
            skills.Add("Программист JAVA");
            skills.Add("Общительность");
            skills.Add("Дружелюбие");
            skills.Add("Тайм-Менеджмент");
            skills.Add("Работа в команде");
            skills.Add("Убедительность");
            skills.Add("Стрессоустойчивость");
            skills.Add("3D моделирование");
            skills.Add("Управление проектами");
            skills.Add("JavaScript");
            Context.AddSkill(skills);
            var allskills = Context.GetAllSkill();
            for (int i=1; i<150; i++)
            {
                emplskill.Clear();
                employees = new Employee();
                employees.FirstName = "Иван " + i;
                employees.SecondName = "Иванов " + i;
                employees.Patronymic = "Иванович " + i;
                employees.Position = "Сотрудник";
                employees.MaxLoad = rand.Next(60, 100);
                for(int j=1; j<rand.Next(5, 10); j++)
                {
                    int ran = rand.Next(1, 100);
                    int randomskill = rand.Next(1, 11);
                    if (emplskill.ContainsKey(allskills.Where(x => x.SkillId == randomskill).FirstOrDefault()) == false)
                    {
                        emplskill.Add(allskills.Where(x => x.SkillId == randomskill).FirstOrDefault(), ran);
                    }
                }
                Context.AddEmployee(employees, emplskill);
            }
            for(int i=1; i<=13 ;i++)//Создаём проект
            {
                Console.WriteLine("i = " + i);
                project = new Project();
                DateTime start = DateTime.Now.AddDays(rand.Next(0, 40));
                DateTime end = DateTime.Now.AddMonths(rand.Next(1, 3)).AddDays(start.Subtract(DateTime.Now).Days);
                DateTime requirstart;
                //DateTime requiredurat;
                project.ProjectName = "Проект " + i;
                project.ProjectDescription = "Описание проекта номер " + i;
                project.Status = 0;
                project.Start = start;
                project.End = end;
                requirementSkill.Clear();
                requerskill.Clear();
                for (int j = 1; j<=rand.Next(9,11);j++) //Создаём требование к проекту
                {
                    requirement = new Requirement();
                    requirement.EmployeeLoad = rand.Next(40, 100);
                    requirement.RequirementDescription = "Описание";
                    requirstart = start.AddDays(rand.Next(0, end.Subtract(start).Days-1));
                    requirement.Start = requirstart;
                    requirement.End = requirstart.AddDays(rand.Next(1, end.Subtract(requirstart).Days));
                    requirementSkill.Clear();
                    requirementSkill = new List<RequirementSkill>();
                    for (int z = 1; z<=rand.Next(4,8); z++) //Создаём необходимые скилы
                    {
                        int randomskill = rand.Next(1, 11);
                        if (requirementSkill.Where(x=>x.MainSkill == allskills.Where(x => x.SkillId == randomskill).FirstOrDefault()).FirstOrDefault() == null)
                        //if (emplskill.ContainsKey(allskills.Where(x => x.SkillId == randomskill).FirstOrDefault()) == false)
                        {
                            requirementSkill.Add(new RequirementSkill() { MainSkill = allskills.Where(x => x.SkillId == randomskill).FirstOrDefault(), MainSkillPoint = rand.Next(1, 100) });
                        }
                    }
                    requerskill.Add(requirement, new List<RequirementSkill>(requirementSkill));
                }
                Context.AddProject(project, requerskill);
            }
           
        }


    }
         
}