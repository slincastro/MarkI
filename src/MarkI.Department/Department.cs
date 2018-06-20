using System.Collections.Generic;

namespace MarkI.Department
{
    public class Department
    {        
        public Department(string numberDepartment, int floor, string owner)
        {
            Number= numberDepartment;
            Floor = floor;
            Owner = owner;
        }

        public string Number { get; set; }
        public int Floor { get; set; }
        public string Owner { get; set; }
    }
}