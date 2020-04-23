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

        public Institution Strip(int layer = 0)
        {
            Institution ret = new Institution
            {
                ABN = this.ABN,
                Name = this.Name,
                Experiments = null,
                People = null
            };
            if (layer > 0)
            {
                ret.Experiments = new List<Experiment>();
                ret.People = new List<Person>();
                foreach (Experiment p in this.Experiments)
                {
                    ret.Experiments.Add((Experiment)p.Strip(layer - 1));
                }
                foreach (Person p in this.People)
                {
                    ret.People.Add((Person)p.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}