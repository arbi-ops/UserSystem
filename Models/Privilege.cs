using System.ComponentModel.DataAnnotations;

namespace UserSystem.Models
{
    public class Privilege
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int GroupId { get; set; }

        public virtual Group Group { get; set; }
    }
}
