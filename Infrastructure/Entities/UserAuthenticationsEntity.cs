using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities
{
    public class UserAuthenticationsEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "varchar(320)")]
        public string? Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string? Password { get; set; }

        [ForeignKey("UserId")]
        public virtual UsersEntity User { get; set; } = null!;

    }

}
