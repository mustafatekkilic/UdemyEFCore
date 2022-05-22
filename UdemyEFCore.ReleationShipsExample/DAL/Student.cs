using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.ReleationShipsExample.DAL
{
    //Many To Many
    public class Student
    {

        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Teacher> Teachers { get; set; } = new();

    }
}
