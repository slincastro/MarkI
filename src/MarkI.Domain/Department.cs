using System;
using System.Collections.Generic;

namespace MarkI.Domain
{
    public class Department
    {        
        public Department(){}
        public Department(string numberDepartment, int floor, string owner)
        {
            Number = numberDepartment ?? ThrowArgumentException("Number Department");
            Floor = floor;
            Owner = owner ?? ThrowArgumentException("Owner");
        }

        private static string ThrowArgumentException(string field)
        {
            throw new ArgumentException($"the field {field} is invalid");
        }

        public string Number { get;  set; }
        public int Floor { get;  set; }
        public string Owner { get;  set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Number) && !string.IsNullOrEmpty(Owner);
        }
    }
}