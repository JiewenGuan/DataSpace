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
        [JsonIgnore] public Person Participant { get; set; }
        [JsonIgnore] public ExpRole Role { get; set; }
        [JsonIgnore] public Experiment Experiment { get; set; }

        
    }
}
