using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DataSpace.Models
{
    public class Role
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String RoleID { get; set; }
        [Required]
        public String Title { get; set; }
        [Required]
        public String RoleDescription { get; set; }
        public virtual ICollection<Participation> Participants { get; set; }
    }
}
