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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int RoleID { get; set; }
        [Required] public String Title { get; set; }
        [Required] public String RoleDescription { get; set; }
        public virtual ICollection<Participation> Participants { get; set; }

        public Role  Strip(int layer = 0)
        {
            Role ret = new Role
            {
                RoleID = this.RoleID,
                Title = this.Title,
                RoleDescription = this.RoleDescription,
                Participants = null
            };
            if (layer > 0)
            {
                ret.Participants = new List<Participation>();
                foreach(Participation p in this.Participants)
                {
                    ret.Participants.Add((Participation)p.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}
