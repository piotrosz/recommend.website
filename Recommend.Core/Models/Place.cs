using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Recommend.Core.Models
{
    public class Place : Entity
    {
        [Required]
        [DisplayName("Name")]
        [MinLength(5, ErrorMessage = "Name too short")]
        [MaxLength(256, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required]
        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }

        [DisplayName("Link")]
        [Url(ErrorMessage = "This is not a valid URL")]
        public string Link { get; set; }

        public int UserId { get; set; }

        public virtual User AddedBy { get; set; }

        [Required]
        [DisplayName("Location")]
        public DbGeography Location { get; set; }
    }
}
