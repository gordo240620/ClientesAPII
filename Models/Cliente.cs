using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models
{
    [Table("clientes")]
    public class Cliente
    {
        [Key]
        [Column("clave")]
        public string Clave { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("edad")]
        public int Edad { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
