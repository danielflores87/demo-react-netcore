using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace demo.back.Domain.Entities
{

    [Table("FAU_FAVORITOS_USUARIO")]
    public class Favorite
    {
        [Key]
        [Column("FAU_CODIGO")]
        public int Id { get; set; }

        [Column("FAU_CODUSR_USUARIO")]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column("FAU_TITULO")]
        [MaxLength(500)]
        public string Titule { get; set; } = string.Empty;

        [Column("FAU_CODE_COMIC")]
        public int CodeComic { get; set; }

        [Column("FAU_FECHA")]
        public DateTime Date { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
