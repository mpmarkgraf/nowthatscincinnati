using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nowthatscincinnati.Models
{
    public partial class Events
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int ImageId { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime? Date { get; set; }
        public string Venue { get; set; }
        public string Description { get; set; }
        public string VenueLink { get; set; }
        public string FacebookLink { get; set; }
        public int UserId { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }

        public virtual Images Image { get; set; }
        public virtual Users User { get; set; }
    }
}
