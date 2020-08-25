using System;

namespace nowthatscincinnati.Models
{
    public partial class Images
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Stream { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Events Event { get; set; }
    }
}
