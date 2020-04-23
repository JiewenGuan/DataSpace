using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Threading.Tasks;

namespace DataSpace.Models
{
    public class Person 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int PersonID { get; set; }
        [Required] public String FirstName { get; set; }
        [Required] public String FamilyName { get; set; }
        [Required] public String Affiliation { get; set; }
        [Required] public String City { get; set; }
        [Required] public String State { get; set; }
        [Required] public String Country { get; set; }
        [Required] public String Email { get; set; }
        [ForeignKey("Institution")] public String InstitutionID { get; set; }
        public virtual ICollection<Participation> Participates { get; set; }
        public virtual Institution Institution { get; set; }

        public Person  Strip(int layer = 0)
        {
            Person ret = new Person
            {
                PersonID = this.PersonID,
                FirstName = this.FirstName,
                FamilyName = this.FamilyName,
                Affiliation = this.Affiliation,
                City = this.City,
                State = this.State,
                Country = this.Country,
                Email = this.Email,
                InstitutionID = this.InstitutionID,
                Participates = null,
                Institution = null
            };
            if (layer > 0)
            {
                ret.Institution = (Institution)this.Institution.Strip(layer - 1);
                ret.Participates = new List<Participation>();
                foreach (Participation m in this.Participates)
                {
                    ret.Participates.Add((Participation)m.Strip(layer - 1));
                }
            }
            return ret;
        }
    }
}
