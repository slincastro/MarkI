using System;
using System.Collections.Generic;

namespace MarkI.Domain
{
    public class Department
    {        
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

        public string Number { get; internal set; }
        public int Floor { get; internal set; }
        public string Owner { get; internal set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Number) && !string.IsNullOrEmpty(Owner);
        }
    }
}