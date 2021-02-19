using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaPrimeStone.Common1.Models
{
    public partial class Direccione
    {
        public Direccione()
        {
            EstudianteDireccions = new HashSet<EstudianteDireccion>();
        }

        public int IdDireccion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<EstudianteDireccion> EstudianteDireccions { get; set; }
    }
}
