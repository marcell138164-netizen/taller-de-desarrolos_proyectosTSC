using System.ComponentModel.DataAnnotations;

namespace prueba2_Martinantinao.Models;

public class PrestamoEquipo
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El solicitante es obligatorio.")]
    [StringLength(60, MinimumLength = 3,
        ErrorMessage = "El solicitante debe tener entre 3 y 60 caracteres.")]
    public string Solicitante { get; set; } = "";

    [Required(ErrorMessage = "El equipo es obligatorio.")]
    [StringLength(80,
        ErrorMessage = "El equipo no puede superar 80 caracteres.")]
    public string Equipo { get; set; } = "";

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime FechaPrestamo { get; set; }

    [Range(1, 30, ErrorMessage = "Los días deben estar entre 1 y 30.")]
    public int Dias { get; set; }

    public bool Devuelto { get; set; }
}