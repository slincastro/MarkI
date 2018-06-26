using System.Collections.Generic;

namespace MarkI.Domain
{
    public class Department
    {        
        public Department(string numberDepartment, int floor, string owner)
        {
            Number= numberDepartment;
            Floor = floor;
            Owner = owner;
        }

        public string Number { get; internal set; }
        public int Floor { get; internal set; }
        public string Owner { get; internal set; }
    }
}