using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class Properties
    {
        public Properties()
        {
            PersonProperty = new HashSet<PersonProperty>();
        }

        public int PropertiesId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PersonProperty> PersonProperty { get; set; }
    }
}
