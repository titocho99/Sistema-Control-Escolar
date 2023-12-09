using System;
using System.Collections.Generic;

namespace Escuela1.Models;

public partial class Alumno
{
    public int IdAlumno { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Correo { get; set; }

    public string? Telefono { get; set; }

    public string? Nua { get; set; }

    public virtual ICollection<AlumnosDetalle> AlumnosDetalles { get; set; } = new List<AlumnosDetalle>();
}
