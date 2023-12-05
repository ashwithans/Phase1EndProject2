using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseEndProj2
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassNum { get; set; }
        public string Section { get; set; }

        public Teacher(int id, string name, int classNum, string section)
        {
            ID = id;
            Name = name;
            ClassNum = classNum;
            Section = section;
        }

        public override string ToString()
        {
            return $"{ID}, {Name}, {ClassNum}, {Section}";
        }
    }
}

