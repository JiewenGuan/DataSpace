using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class Mission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public String MissionID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public DateTime Commancement { get; set; }
        [Required] public DateTime Conclusion { get; set; }
        [ForeignKey("Platform"), Required] public String PlatformID { get; set; }
        public virtual ICollection<Experiment> Experiments { get; set; }
        public virtual Platform Platform { get; set; }
    }
}