using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CuidarDePerto.Api.Models
{
    [Table("T_CDP_ALERTA")]
    public class Alerta
    {
        [Key]
        [Column("ID_ALERTA")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Column("DS_TIPO_ALERTA")]
        public string TipoAlerta { get; set; } = string.Empty;

        [Required]
        [Column("DT_ALERTA")]
        public DateTime DataHora { get; set; } = DateTime.Now;

        [Column("ID_IDOSO")]
        public int IdosoId { get; set; }

        [JsonIgnore]
        public Idoso? Idoso { get; set; }
    }
}