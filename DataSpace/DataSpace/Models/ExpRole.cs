using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataSpace.Models
{
    public class ExpRole
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int RoleID { get; set; }
        [Required] public String Title { get; set; }
        [Required] public String RoleDescription { get; set; }
        [JsonIgnore] public virtual ICollection<Participation> Participants { get; set; }

        [Required] public DateTime DateOfSubmission { get; set; }
        [Required] public EvaluationStatus EvaluationStatus { get; set; }
        
    }
}
