using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaPrimeStone.Common1.Dao;
using PruebaPrimeStone.Modelos.Dto;
using PruebaPrimeStone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaPrimeStone.Web.Controllers
{
    public class DireccionesController : Controller
    {
        #region Propiedades 
        private readonly ILogger<DireccionesController> _logger;
        #endregion

        #region Constructor
        public DireccionesController(ILogger<DireccionesController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Obtener Estudiante
        public IActionResult Obtener()
        {
            var direccionesDao = new DireccionesDao();
            var modelo = new List<DireccionesModel>();
            try
            {
                var direcciones = direccionesDao.ObternerDirecciones();
                foreach (var direccion in direcciones)
                {
                    modelo.Add(new DireccionesModel { IdDireccion = direccion.IdDireccion, Nombre = direccion.Nombre});
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
        public ActionResult Nuevo(DireccionesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DireccionesDao = new DireccionesDao();
                    DireccionesDao.InsertarDireccion(new DireccionesDto { IdDireccion = model.IdDireccion, Nombre = model.Nombre });
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
            var DireccionesDao = new DireccionesDao();
            var modelo = new DireccionesModel();
            var Direcciones = DireccionesDao.ObternerDireccion(id);
            modelo.IdDireccion = id;
            modelo.Nombre = Direcciones.Nombre;
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(DireccionesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var DireccionesDao = new DireccionesDao();
                    DireccionesDao.ActualizarDireccion(new DireccionesDto { IdDireccion = model.IdDireccion, Nombre = model.Nombre});
                }

                return Redirect("~/direcciones/obtener");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        #endregion

        #region Eliminar Estudiante
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
                    var DireccionesDao = new DireccionesDao();
                    DireccionesDao.EliminarDireccion(id);
                }

                return Redirect("~/direcciones/obtener");

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
