using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaPrimeStone.Common1.Dao;
using PruebaPrimeStone.Modelos.Dto;
using PruebaPrimeStone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PruebaPrimeStone.Web.Controllers
{
    public class EstudianteController : Controller
    {
        #region Propiedades 
        private readonly ILogger<EstudianteController> _logger;
        #endregion

        #region Constructor
        public EstudianteController(ILogger<EstudianteController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Obtener Estudiante
        public IActionResult Obtener()
        {
            var estudianteDao = new EstudianteDao();
            var modelo = new List<EstudianteModel>();
            try
            {
                var estudiantes = estudianteDao.ObtenerEstudiantes();
                foreach (var estudiante in estudiantes)
                {
                    modelo.Add(new EstudianteModel { IdEstudiante = estudiante.IdEstudiante, Nombre = estudiante.Nombre, Edad = estudiante.Edad, Telefono = estudiante.Telefono });
                }

                return View(modelo);

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }
        }
        #endregion

        #region Nuevo Estudiante
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(EstudianteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estudianteDao = new EstudianteDao();
                    estudianteDao.InsertarEstudiante(new EstudianteDto { IdEstudiante = model.IdEstudiante, Nombre = model.Nombre, Edad = model.Edad, Telefono = model.Telefono });
                }

                return Redirect("obtener");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        #endregion

        #region Editar Estudiante
        public ActionResult Editar(int id)
        {
            var estudianteDao = new EstudianteDao();
            var modelo = new EstudianteModel();
            var estudiante = estudianteDao.ObtenerEstudiante(id);
            modelo.IdEstudiante = id;
            modelo.Nombre = estudiante.Nombre;
            modelo.Edad = estudiante.Edad;
            modelo.Telefono = estudiante.Telefono;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(EstudianteModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estudianteDao = new EstudianteDao();
                    estudianteDao.ActualizarEstudiante(new EstudianteDto { IdEstudiante = model.IdEstudiante, Nombre = model.Nombre, Edad = model.Edad, Telefono = model.Telefono });
                }

                return Redirect("~/estudiante/obtener");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        #endregion

        #region Eliminar Estudiante
        //UTILIZA JSON WEB TOKEN

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public ActionResult Eliminar()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var estudianteDao = new EstudianteDao();
                    estudianteDao.EliminarEstudiante(id);
                }

                return Redirect("~/estudiante/obtener");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        #endregion

    }
}
