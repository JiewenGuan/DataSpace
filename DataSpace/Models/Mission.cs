using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataSpace.Models
{
    public class Mission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int MissionID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public DateTime Commancement { get; set; }
        [Required] public DateTime Conclusion { get; set; }
        [ForeignKey("Platform"), Required] public int PlatformID { get; set; }
        [JsonIgnore] public ICollection<Experiment> Experiments { get; set; }
        [JsonIgnore] public Platform Platform { get; set; }

        
    }
}