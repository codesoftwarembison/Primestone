using PruebaPrimeStone.Common1.Models;
using PruebaPrimeStone.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PruebaPrimeStone.Common1.Dao
{
    public class CursoDao
    {

        #region Obtener
        public List<CursoDto> ObternerCursos()
        {
            var cursos = new List<CursoDto>();
            using (var db = new BDPrimeStoneContext())
            {
                cursos = (from e in db.Cursos
                               select new CursoDto
                               {
                                   IdCurso = e.IdCurso,
                                   Nombre = e.Nombre,
                                   Tiempo = e.Tiempo,
                                   FechaInicio = e.FechaInicio,
                                   FechaFin = e.FechaFin

                               }).ToList();
            }
            return cursos;
        }

        public CursoDto ObternerCurso(int id)
        {
            var curso = new CursoDto();
            using (var db = new BDPrimeStoneContext())
            {
                var _curso = db.Cursos.Find(id);
                curso.IdCurso = _curso.IdCurso;
                curso.Nombre = _curso.Nombre;
                curso.Tiempo = _curso.Tiempo;
                curso.FechaInicio = _curso.FechaInicio;
                curso.FechaFin = _curso.FechaFin;
            }
            return curso;
        }

        #endregion

        #region Insertar
        public CursoDto InsertarCurso(CursoDto curso)
        {
            var _curso = new Curso();
            using (var db = new BDPrimeStoneContext())
            {
                _curso.Nombre = curso.Nombre;
                _curso.Tiempo = curso.Tiempo;
                _curso.FechaInicio = curso.FechaInicio;
                _curso.FechaFin = curso.FechaFin;
                db.Cursos.Add(_curso);
                db.SaveChanges();
            }
            return curso;
        }

        #endregion

        #region Actualizar
        public void ActualizarCurso(CursoDto curso)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _curso = new Curso();
                _curso.IdCurso = curso.IdCurso;
                _curso.Nombre = curso.Nombre;
                _curso.Tiempo = curso.Tiempo;
                _curso.FechaInicio = curso.FechaInicio;
                _curso.FechaFin = curso.FechaFin;
                db.Entry(_curso).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        #region Eliminar
        public void EliminarCurso(int id)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _curso = db.Cursos.Find(id);
                db.Cursos.Remove(_curso);
                db.SaveChanges();
            }
        }
        #endregion


    }
}
