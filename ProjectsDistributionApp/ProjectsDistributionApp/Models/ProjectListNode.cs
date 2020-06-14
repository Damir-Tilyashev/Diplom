using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectsDistributionApp.Models
{
    public class Status
    {
        private Tuple<string, int>[] cd;
        private Dictionary<string, int> codes;
        private Dictionary<int, string> codesReverse;
        public Status()
        {
            cd = new Tuple<string, int>[]
            {
                new Tuple<string, int>("Открыт", 0),
                new Tuple<string, int>("Закрыт", 1),
                new Tuple<string, int>("Окончен", 2),
                new Tuple<string, int>("Не определено", 3)
            };
            codes = new Dictionary<string, int>();
            codesReverse = new Dictionary<int, string>();
            foreach(var item in cd)
            {
                codes.Add(item.Item1, item.Item2);
                codesReverse.Add(item.Item2, item.Item1);
            }
        }
        public string this[int i]
        {
            get
            {
                if (i >= 0 && i <= 2)
                    return codesReverse[i];
                else
                    return codesReverse[3];
            }
        }
        public int this[string i]
        {
            get
            {
                return codes[i];
            }
        }
    }
    public class ProjectListNode
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Status { get; private set; }
        public int Priority { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public ProjectListNode(int id, string name, int status, int priority, DateTime startTime, DateTime endTime)
        {
            Id = id;
            Name = name;
            Status = new Status()[status];
            Priority = priority;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
