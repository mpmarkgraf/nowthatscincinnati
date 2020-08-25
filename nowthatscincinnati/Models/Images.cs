using System;
using System.Collections.Generic;

namespace nowthatscincinnati.Models
{
    public partial class Images
    {
        public Images()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Stream { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid Rowguid { get; set; }

        public virtual ICollection<Events> Events { get; set; }
    }
}
