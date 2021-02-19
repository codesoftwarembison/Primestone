using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPrimeStone.Web.Models
{
    public class EstudianteModel
    {

        #region Propiedades
        [Required]
        public int IdEstudiante { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Edad { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }
        #endregion

    }
}
