using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo.back.Domain.Entities
{

    [Table("USR_USUARIOS")]
    public class User
    {
        [Key]
        [Column("USR_CODIGO")]
        public int Id { get; set; }

        [Column("USR_NUMERO_DOCUMENTO")]
        [MaxLength(15)]
        public string NumberDocument { get; set; } = string.Empty;

        [Column("USR_NOMBRE")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Column("USR_CORREO")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Column("USR_CLAVE_ACCESO")]
        [MaxLength(200)]
        public string Password { get; set; } = string.Empty;

    }
}
