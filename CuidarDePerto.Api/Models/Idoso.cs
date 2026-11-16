using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuidarDePerto.Api.Models
{
    [Table("T_CDP_IDOSO")]
    public class Idoso
    {
        [Key]
        [Column("ID_IDOSO")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("NM_IDOSO")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Column("NR_IDADE")]
        public int Idade { get; set; }

        [StringLength(200)]
        [Column("DS_ENDERECO")]
        public string? Endereco { get; set; }

        // Propriedade de navegação para o relacionamento 1:N com Alerta
        public ICollection<Alerta> Alertas { get; set; } = new List<Alerta>();
    }
}