using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPrimeStone.Web.Models
{
    public class CursoModel
    {

        #region Propiedades
        [Required]
        public int IdCurso { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Tiempo { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Fin")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha Inicio")]
        public DateTime FechaFin { get; set; }
        #endregion

    }
}
