using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectsDistributionApp.Models
{
    public class SkillNode
    {
        public int Id { get; private set; }
        public string SkillName { get; private set; }
        public SkillNode(int id, string skillName)
        {
            Id = id;
            SkillName = skillName;
        }
    }
}
