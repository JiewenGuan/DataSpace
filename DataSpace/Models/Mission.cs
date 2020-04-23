using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class Mission
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int MissionID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public DateTime Commancement { get; set; }
        [Required] public DateTime Conclusion { get; set; }
        [ForeignKey("Platform"), Required] public int PlatformID { get; set; }
        public virtual ICollection<Experiment> Experiments { get; set; }
        public virtual Platform Platform { get; set; }

        public Mission Strip(int layer = 0)
        {
            Mission ret = new Mission
            {
                MissionID = this.MissionID,
                Name = this.Name,
                Commancement = this.Commancement,
                Conclusion = this.Conclusion,
                PlatformID = this.PlatformID,
                Experiments = null,
                Platform = null,
            };
            if (layer > 0)
            {
                ret.Platform = (Platform)this.Platform.Strip(layer - 1);
                ret.Experiments = new List<Experiment>();
                foreach (Experiment p in this.Experiments)
                {
                    ret.Experiments.Add((Experiment)p.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}