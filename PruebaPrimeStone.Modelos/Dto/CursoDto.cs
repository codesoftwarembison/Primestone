using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaPrimeStone.Modelos.Dto
{
    public class CursoDto
    {

        #region Propiedades
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public string Tiempo { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
        #endregion

    }
}
