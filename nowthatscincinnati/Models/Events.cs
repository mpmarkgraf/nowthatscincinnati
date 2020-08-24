using System;
using System.Collections.Generic;

namespace nowthatscincinnati.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ImageId { get; set; }
        public DateTime? Date { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public string VenueLink { get; set; }
        public string FacebookLink { get; set; }
        public int UserId { get; set; }

        public virtual Images Image { get; set; }
        public virtual Users User { get; set; }
    }
}
