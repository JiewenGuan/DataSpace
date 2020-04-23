using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int PlatformID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public PlatformType Type { get; set; }
        public String Discription { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }

        public Platform Strip(int layer = 0)
        {
            Platform ret = new Platform
            {
                PlatformID = this.PlatformID,
                Name = this.Name,
                Type = this.Type,
                Discription = this.Discription,
                Missions = null
            };
            if (layer > 0)
            {
                ret.Missions = new List<Mission>();
                foreach (Mission m in this.Missions)
                {
                    ret.Missions.Add((Mission)m.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}