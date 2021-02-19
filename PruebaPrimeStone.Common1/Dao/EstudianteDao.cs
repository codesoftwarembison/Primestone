using Microsoft.EntityFrameworkCore;
using PruebaPrimeStone.Common1.Models;
using PruebaPrimeStone.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PruebaPrimeStone.Common1.Dao
{
    public class EstudianteDao
    {

        #region Obtener
        public List<EstudianteDto> ObtenerEstudiantes()
        {
            var estudiantes = new List<EstudianteDto>();
            using (var db = new BDPrimeStoneContext())
            {
                estudiantes = (from e in db.Estudiantes
                               select new EstudianteDto
                               {
                                   IdEstudiante = e.IdEstudiante,
                                   Nombre = e.Nombre,
                                   Edad = e.Edad,
                                   Telefono = e.Telefono

                               }).ToList();
            }
            return estudiantes;
        }

        public EstudianteDto ObtenerEstudiante(int id)
        {
            var estudiante = new EstudianteDto();
            using (var db = new BDPrimeStoneContext())
            {
                var _estudiantes = db.Estudiantes.Find(id);
                estudiante.IdEstudiante = _estudiantes.IdEstudiante;
                estudiante.Nombre = _estudiantes.Nombre;
                estudiante.Edad = _estudiantes.Edad;
                estudiante.Telefono = _estudiantes.Telefono;
            }
            return estudiante;
        }

        #endregion

        #region Insertar
        public EstudianteDto InsertarEstudiante(EstudianteDto estudiante)
        {
            var _estudiante = new Estudiante();
            using (var db = new BDPrimeStoneContext())
            {
                _estudiante.IdEstudiante = estudiante.IdEstudiante;
                _estudiante.Nombre = estudiante.Nombre;
                _estudiante.Edad = estudiante.Edad;
                _estudiante.Telefono = estudiante.Telefono;
                db.Estudiantes.Add(_estudiante);
                db.SaveChanges();
            }
            return estudiante;
        }

        #endregion

        #region Actualizar
        public void ActualizarEstudiante(EstudianteDto estudiante)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _estudiante = new Estudiante();
                _estudiante.IdEstudiante = estudiante.IdEstudiante;
                _estudiante.Nombre = estudiante.Nombre;
                _estudiante.Edad = estudiante.Edad;
                _estudiante.Telefono = estudiante.Telefono;
                db.Entry(_estudiante).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        #region Eliminar
        public void EliminarEstudiante(int id)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _estudiante = db.Estudiantes.Find(id);
                db.Estudiantes.Remove(_estudiante);
                db.SaveChanges();
            }
        }
        #endregion

    }
}
