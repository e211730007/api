using System;
using System.Collections.Generic;

namespace Entities
{
    public partial class PersonProperty
    {
        public int PersonPropId { get; set; }
        public int PersonId { get; set; }
        public int PropertyId { get; set; }

        public virtual Person Person { get; set; }
        public virtual Properties Property { get; set; }
    }
}
