using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataSpace.Models
{
    public class ResultDataset
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int DatasetID { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String RepoUrl { get; set; }
        [Required, ForeignKey("Experiment")] public int ExperimentID { get; set; }
        [JsonIgnore] public virtual Experiment Experiment { get; set; }

        [Required] public DateTime DateOfSubmission { get; set; }
        [Required] public EvaluationStatus EvaluationStatus { get; set; }
        
    }
}
