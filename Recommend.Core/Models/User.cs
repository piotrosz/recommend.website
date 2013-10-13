using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recommend.Core.Models
{
    [Table("User")]
    public class User : Entity
    {
        public User() {}

        public User(string userName, string email)
        {
            this.UserName = userName;
            this.Email = email;
        }

        [MinLength(3)]
        [MaxLength(50)]
        public string UserName { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public virtual List<Recommendation> Recommendations { get; set; } 
    }
}
