using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPrimeStone.Web.Models
{
    public class DireccionesModel
    {

        #region Propiedades
        [Required]
        public int IdDireccion { get; set; }

        [Required]
        public string Nombre { get; set; }
        #endregion

    }
}
