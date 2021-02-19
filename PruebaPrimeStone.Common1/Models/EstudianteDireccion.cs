using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaPrimeStone.Common1.Models
{
    public partial class EstudianteDireccion
    {
        public int IdEstudianteDireccion { get; set; }
        public int? Estudiante { get; set; }
        public int? Direccion { get; set; }

        public virtual Direccione DireccionNavigation { get; set; }
        public virtual Estudiante EstudianteNavigation { get; set; }
    }
}
