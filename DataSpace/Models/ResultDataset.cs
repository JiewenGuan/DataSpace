using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class ResultDataset 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int DatasetID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String RepoUrl { get; set; }
        [Required, ForeignKey("Experiment")] public int ExperimentID { get; set; }
        public virtual Experiment Experiment { get; set; }

        public ResultDataset  Strip(int layer = 0)
        {
            ResultDataset ret = new ResultDataset
            {
                DatasetID = this.DatasetID,
                Name = this.Name,
                RepoUrl = this.RepoUrl,
                ExperimentID = this.ExperimentID,
                Experiment = null
            };
            if (layer > 0)
            {
                ret.Experiment = (Experiment)this.Experiment.Strip(layer-1);
            }
            return ret;
        }
    }
}
