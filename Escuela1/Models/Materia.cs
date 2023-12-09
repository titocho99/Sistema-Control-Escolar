using System;
using System.Collections.Generic;

namespace Escuela1.Models;

public partial class Materia
{
    public int IdMateria { get; set; }

    public string? Nombre { get; set; }

    public int? IdProfesor { get; set; }

    public virtual ICollection<AlumnosDetalle> AlumnosDetalles { get; set; } = new List<AlumnosDetalle>();

    public virtual Maestro? IdProfesorNavigation { get; set; }
}
