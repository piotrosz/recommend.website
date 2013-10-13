using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Spatial;

namespace Recommend.Core.Models
{
    public class Recommendation : Entity
    {
        public Recommendation() {}

        public Recommendation(int userId, string description, DateTime? when)
        {
            UserId = userId;
            Description = description;
            When = when;
        }

        public virtual User User { get; set; }

        public int UserId { get; set; }

        public int? PlaceId { get; set; }

        public virtual Place Place { get; set; }

        [DisplayName("Picture")]
        public byte[] PhotoFile { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayName("When")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime? When { get; set; }

        [DisplayName("Link")]
        [Url(ErrorMessage = "Not URL")]
        public string Link { get; set; }
    }
}
