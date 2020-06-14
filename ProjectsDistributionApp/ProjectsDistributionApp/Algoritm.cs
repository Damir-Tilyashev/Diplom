using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DiplomConsole.DataBase;

namespace DiplomConsole
{
    class Algoritm
    {
        public static void Distribution()
        {
            Employee computer = Context.GiveComputer();
            List<EmployeeSkill> allemployessskill = Context.GetAllEmployeeSkills();
            List<RequirementSkill> requirementcoord = new List<RequirementSkill>();
            List<RequirementSkill> actuallrequirement = new List<RequirementSkill>();
            double mindistance = 100000;
            double actualldistance = 0;
            Employee minEmployee = new Employee();
            List<EmployeeRequirement> employeerequirement = new List<EmployeeRequirement>();
            var projects = Context.GetProjectsByStatus(0);
            var employees = Context.GetAllEmployee();
            foreach(var project in  projects)
            {
                foreach(var requirement in Context.GetRequirementWithProject(project)) //project.Requirements)
                {
                        var ye = Context.GetRequirementSkill(requirement).Select(x=>x.MainSkill.SkillId);
                        var actuall = employees.Join(allemployessskill,
                            emp => emp,
                            sk => sk.Employee,
                            (emp, sk) =>(emp,sk))
                            .GroupBy(q=>q.emp.EmployeeId)
                            .Where(z => ye
                                .All(w => z
                                    .Select(e => e.sk.Skill.SkillId)
                            .Contains(w)))
                            .Select(x=>x.Key).ToList();
                    var actuallemployees = Context.GetEmployeeWithId(actuall);
                    foreach(var emp in actuallemployees)//Проходимся по всем сотрудникам, чтобы вычислить расстояние до них
                    {
                        var thisempload = emp.MaxLoad - GiveEmployeeLoad(emp, requirement.Start, requirement.End);
                        if (thisempload >= requirement.EmployeeLoad) //Если сотрудник достаточно свободен, чтобы участвовать в проекте
                        {
                            actualldistance = Math.Pow(requirement.EmployeeLoad - thisempload, 2);
                            foreach (var skills in requirement.RequirementSkills)//Рассчитываем расстояние до сотрудника по навыкам
                            {
                                actualldistance = actualldistance + Math.Pow(skills.MainSkillPoint - emp.EmployeeSkills.Where(u => u.Skill == skills.MainSkill).FirstOrDefault().SkillPoint, 2);
                            }
                            actualldistance = Math.Sqrt(actualldistance);
                            if(actualldistance<mindistance)
                            {
                                mindistance = actualldistance;
                                minEmployee = emp;
                            }
                        }
                    }
                    if (mindistance != 100000)
                    {
                        employeerequirement.Clear();
                        employeerequirement.Add(new EmployeeRequirement() { Employees = minEmployee, Requirement = requirement, Status = 0, Appointment = computer, EndDate = DateTime.Now});
                        Context.AddEmployeeRequirement(employeerequirement);
                    }
                    actualldistance = 0;
                    mindistance = 100000;
                    minEmployee = new Employee();
                }
            }
        }

        public static double GiveEmployeeLoad(Employee employee, DateTime start, DateTime end)//Вычисляем степень загруженности сотрудника во время проекта
        {
            double actuallload = 0;
            foreach(var employeereq in Context.GetThisEmployeeReq(employee))
            {
                if(start<= employeereq.Start && end>= employeereq.End) //Если другой проект полностью внутри нужного нам
                {
                    actuallload += employeereq.EmployeeLoad * employeereq.End.Subtract(employeereq.Start).TotalDays;
                }
                else if(start > employeereq.Start && end >= employeereq.End) //Если началось раньше, а закончилось пока идёт нужный нам проект
                {
                    actuallload += employeereq.EmployeeLoad * employeereq.End.Subtract(start).TotalDays;
                }
                else if(start <= employeereq.Start && end < employeereq.End)//Если началось пока идёт нужный нам проект, а закончилось позже
                {
                    actuallload += employeereq.EmployeeLoad * end.Subtract(employeereq.Start).TotalDays;
                }
                else if (start > employeereq.Start && end < employeereq.End)//Если наш проект полностью внутри данного  
                {
                    actuallload += employeereq.EmployeeLoad * end.Subtract(start).TotalDays;
                }
            }
            return actuallload / end.Subtract(start).TotalDays;
        }
    }
}
