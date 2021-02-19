using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaPrimeStone.Common1.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            EstudianteCursos = new HashSet<EstudianteCurso>();
            EstudianteDireccions = new HashSet<EstudianteDireccion>();
        }

        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<EstudianteCurso> EstudianteCursos { get; set; }
        public virtual ICollection<EstudianteDireccion> EstudianteDireccions { get; set; }
    }
}
