using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class Participation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public String ParticipateID { get; set; }
        [ForeignKey("Participant"), Required] public String PersonID { get; set; }
        [ForeignKey("Role"), Required] public String RoleID { get; set; }
        [ForeignKey("Experiment"), Required] public String ExperimentID { get; set; }
        public virtual Person Participant { get; set; }
        public virtual Role Role { get; set; }
        public virtual Experiment Experiment { get; set; }
    }
}
