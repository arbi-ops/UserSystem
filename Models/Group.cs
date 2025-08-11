using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserSystem.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Privilege> Privileges { get; set; }
    }

}
