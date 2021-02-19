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
    public class CursoController : Controller
    {
        #region Propiedades 
        private readonly ILogger<CursoController> _logger;
        #endregion

        #region Constructor
        public CursoController(ILogger<CursoController> logger)
        {
            _logger = logger;
        }
        #endregion

        #region Obtener Curso
        public IActionResult Obtener()
        {
            var cursoDao = new CursoDao();
            var modelo = new List<CursoModel>();
            try
            {
                var cursos = cursoDao.ObternerCursos();
                foreach (var curso in cursos)
                {
                    modelo.Add(new CursoModel { IdCurso = curso.IdCurso, Nombre = curso.Nombre, Tiempo = curso.Tiempo, FechaInicio = (Convert.ToDateTime(curso.FechaInicio)), FechaFin= Convert.ToDateTime(curso.FechaFin) });
                }

                return View(modelo);

            }
            catch (Exception ex)
            {
                _logger.LogError(@"Error: {0}",ex);
                throw;
            }
        }
        #endregion

        #region Nuevo Curso
        public ActionResult Nuevo()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(CursoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cursoDao = new CursoDao();
                    cursoDao.InsertarCurso(new CursoDto { IdCurso = model.IdCurso, Nombre = model.Nombre, Tiempo = model.Tiempo, FechaInicio = Convert.ToString(model.FechaInicio.ToString("dd/MM/yyyy")), FechaFin = Convert.ToString(model.FechaFin.ToString("dd/MM/yyyy")) });
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

        #region Editar Curso
        public ActionResult Editar(int id)
        {
            var cursoDao = new CursoDao();
            var modelo = new CursoModel();
            var curso = cursoDao.ObternerCurso(id);
            modelo.IdCurso = id;
            modelo.Nombre = curso.Nombre;
            modelo.Tiempo = curso.Tiempo;
            modelo.FechaInicio = Convert.ToDateTime( curso.FechaInicio);
            modelo.FechaFin = Convert.ToDateTime(curso.FechaFin);
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Editar(CursoModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var cursoDao = new CursoDao();
                    cursoDao.ActualizarCurso(new CursoDto { IdCurso = model.IdCurso, Nombre = model.Nombre, Tiempo = model.Tiempo, FechaInicio = Convert.ToString( model.FechaInicio.ToString("dd/MM/yyyy")), FechaFin = Convert.ToString(model.FechaFin.ToString("dd/MM/yyyy")) });
                }

                return Redirect("~/Curso/obtener");

            }
            catch (Exception ex)
            {

                _logger.LogError(@"Error: {0}", ex);
                throw;
            }

        }
        #endregion

        #region Eliminar Curso
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
                    var cursoDao = new CursoDao();
                    cursoDao.EliminarCurso(id);
                }

                return Redirect("~/Curso/obtener");

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
