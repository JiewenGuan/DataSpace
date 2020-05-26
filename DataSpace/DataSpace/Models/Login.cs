using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleHashing;

namespace DataSpace.Models
{
    public class Login
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None),StringLength(50, MinimumLength = 20)]
        public string LoginID { get; set; }

        [Required, StringLength(64)] public string PasswordHash { get; set; }
        [Required] public DateTime ModifyDate { get; set; }
        [JsonIgnore] public virtual Person Person { get; set; }
        [Required, ForeignKey("Person")] public int PersonID { get; set; }

        public int BadAttempt { get; set; }
        public DateTime LastBadLogin { get; set; }
        public void NewPassword(string comment)
        {
            PasswordHash = PBKDF2.Hash(comment);
            ModifyDate = DateTime.Now;
        }

        public bool Verify(string password)
        {
            if ((DateTime.Now - LastBadLogin).TotalMinutes < 5 && BadAttempt > 2)
                return false;

            if (PBKDF2.Verify(PasswordHash, password))
            {
                BadAttempt = 0;
                return true;
            }
            else
            {
                BadAttempt += 1;
                LastBadLogin = DateTime.Now;
                return false;
            }
        }
        public void Lock()
        {
            BadAttempt = 3;
            LastBadLogin = DateTime.Now;
        }
        public void Unlock()
        {
            BadAttempt = 0;
        }
    }
}
