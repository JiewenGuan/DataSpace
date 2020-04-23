using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class Participation 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ParticipateID { get; set; }
        [ForeignKey("Participant"), Required] public int PersonID { get; set; }
        [ForeignKey("Role"), Required] public int RoleID { get; set; }
        [ForeignKey("Experiment"), Required] public int ExperimentID { get; set; }
        public virtual Person Participant { get; set; }
        public virtual Role Role { get; set; }
        public virtual Experiment Experiment { get; set; }

        public Participation Strip(int layer = 0)
        {
            Participation ret = new Participation
            {
                ParticipateID = this.ParticipateID,
                PersonID = this.PersonID,
                RoleID = this.RoleID,
                ExperimentID = this.ExperimentID,
                Participant = null,
                Role = null,
                Experiment = null
            };
            if (layer > 0)
            {
                ret.Participant = (Person)this.Participant.Strip(layer - 1);
                ret.Role = (Role)this.Role.Strip(layer - 1);
                ret.Experiment = (Experiment)this.Experiment.Strip(layer - 1);
            }
            return ret;
        }
    }
}
