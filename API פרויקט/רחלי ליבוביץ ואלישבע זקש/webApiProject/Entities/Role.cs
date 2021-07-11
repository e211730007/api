using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Role
    {
        public Role()
        {
            Person = new HashSet<Person>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Person> Person { get; set; }
    }
}
