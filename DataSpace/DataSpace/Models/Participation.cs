using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataSpace.Models
{
    public class Participation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int ParticipateID { get; set; }
        [ForeignKey("Participant"), Required] public int PersonID { get; set; }
        [ForeignKey("Role"), Required] public int RoleID { get; set; }
        [ForeignKey("Experiment"), Required] public int ExperimentID { get; set; }
        [JsonIgnore] virtual public Person Participant { get; set; }
        [JsonIgnore] virtual public ExpRole Role { get; set; }
        [JsonIgnore] virtual public Experiment Experiment { get; set; }

    }
}
