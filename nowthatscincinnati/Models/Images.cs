using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace nowthatscincinnati.Models
{
    public partial class Images
    {
        public Images()
        {
            Events = new HashSet<Events>();
        }

        public int Id { get; set; }
        public string FileName { get; set; }
        public byte[] Stream { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [NotMapped]

        public string Url
        {
            get
            {
                return "data:image;base64," + Convert.ToBase64String(Stream);
            }
        }

        public virtual ICollection<Events> Events { get; set; }
    }
}
