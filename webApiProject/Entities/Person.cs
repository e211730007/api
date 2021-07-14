using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Person
    {
        public Person()
        {
            PersonProperty = new HashSet<PersonProperty>();
        }

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string BirthDate { get; set; }
        public int Gender { get; set; }
        public int RoleId { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<PersonProperty> PersonProperty { get; set; }
    }
}
