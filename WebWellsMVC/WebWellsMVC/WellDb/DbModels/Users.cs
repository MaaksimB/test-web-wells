using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebWellsMVC.WellDb.DbModels
{
    [Table("Users")]
    public class Users
    {
         [Key]
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; }
        public string Role { get; set; }
    }
}