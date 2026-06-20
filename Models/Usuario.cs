using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models;

[Table("usuarios")]
public class Usuario
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("usuario")]
    public string UsuarioNombre { get; set; }

    [Column("password")]
    public string Password { get; set; }
}