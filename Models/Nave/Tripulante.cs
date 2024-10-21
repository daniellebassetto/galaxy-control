using GalaxyControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace GalaxyControl.Models;

public class Tripulante
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Informe o nome")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Informe o estado")]
    public EnumEstadoTripulante Estado { get; set; }

    public int NaveId { get; set; }
    public Nave? Nave { get; set; }
}