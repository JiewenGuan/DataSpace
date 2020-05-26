using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DataSpace.Models
{
    public class Institution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] public String ABN { get; set; }
        [Required] public String Name { get; set; }
        [JsonIgnore] virtual public ICollection<Experiment> Experiments { get; set; }
        [JsonIgnore] virtual public ICollection<Person> People { get; set; }

        [Required] public DateTime DateOfSubmission { get; set; }
        [Required] public EvaluationStatus EvaluationStatus { get; set; }
        
    }
}