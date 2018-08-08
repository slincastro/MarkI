using System;

namespace MarkI.Domain {
    public class Person : Entity {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentId { get; set; }
        public string Email { get; set; }

        public bool IsValid () {
            if (string.IsNullOrEmpty (Name) || string.IsNullOrEmpty (LastName) ||
                string.IsNullOrEmpty (DocumentId) || string.IsNullOrEmpty (Email))
                return false;

            return true;
        }
    }
}