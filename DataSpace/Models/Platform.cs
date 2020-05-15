using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int PlatformID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public PlatformType Type { get; set; }
        public String Discription { get; set; }
        [JsonIgnore] public ICollection<Mission> Missions { get; set; }

        
    }
}