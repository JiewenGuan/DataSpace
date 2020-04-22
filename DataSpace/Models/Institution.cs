using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataSpace.Models
{
    public class Institution
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] public String ABN { get; set; }
        [Required] public String Name { get; set; }
        public virtual ICollection<Experiment> Experiments { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}