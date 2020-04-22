using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class ResultDataset
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public String DatasetID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String RepoUrl { get; set; }
        [Required, ForeignKey("Experiment")] public String ExperimentID { get; set; }
        public virtual Experiment Experiment { get; set; }
    }
}
