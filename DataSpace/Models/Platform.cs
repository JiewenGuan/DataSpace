using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public enum PlatformType
    {
        Space_Station,
        Space_Shuttle,
        Retrievable_Capsule,
        Sounding_Rocket,
        Parabolic_Flight,
        Drop_Tower,
        Other
    }
    public class Platform
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public String PlatformID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public PlatformType Type { get; set; }
        public String Discription { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}