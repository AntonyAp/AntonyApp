using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
    }
}