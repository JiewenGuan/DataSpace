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
        [JsonIgnore] public ICollection<Experiment> Experiments { get; set; }
        [JsonIgnore] public ICollection<Person> People { get; set; }

        
    }
}