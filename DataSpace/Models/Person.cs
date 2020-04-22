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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public String PersonID { get; set; }
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
    }
}
