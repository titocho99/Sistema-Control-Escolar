using System;
using System.Collections.Generic;

namespace Escuela1.Models;

public partial class Maestro
{
    public int IdProfesor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Nup { get; set; }

    public virtual ICollection<Materia> Materia { get; set; } = new List<Materia>();
}
