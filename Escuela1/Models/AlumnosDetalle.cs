using System;
using System.Collections.Generic;

namespace Escuela1.Models;

public partial class AlumnosDetalle
{
    public int Id { get; set; }

    public int IdAlumno { get; set; }

    public int IdMateria { get; set; }

    public string? Calificacion { get; set; }

    public virtual Alumno IdAlumnoNavigation { get; set; } = null!;

    public virtual Materia IdMateriaNavigation { get; set; } = null!;
}
