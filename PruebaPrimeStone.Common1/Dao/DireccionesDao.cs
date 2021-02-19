using Microsoft.EntityFrameworkCore;
using PruebaPrimeStone.Common1.Models;
using PruebaPrimeStone.Modelos.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace PruebaPrimeStone.Common1.Dao
{
    public class DireccionesDao
    {

        #region Obtener
        public List<DireccionesDto> ObternerDirecciones()
        {
            var direcciones = new List<DireccionesDto>();
            using (var db = new BDPrimeStoneContext())
            {
                direcciones = (from e in db.Direcciones
                               select new DireccionesDto
                               {
                                   IdDireccion = e.IdDireccion,
                                   Nombre = e.Nombre,
                               }).ToList();
            }
            return direcciones;
        }

        public DireccionesDto ObternerDireccion(int id)
        {
            var direccion = new DireccionesDto();
            using (var db = new BDPrimeStoneContext())
            {
                var _direccion = db.Direcciones.Find(id);
                direccion.IdDireccion = _direccion.IdDireccion;
                direccion.Nombre = _direccion.Nombre;
            }
            return direccion;
        }

        #endregion

        #region Insertar
        public DireccionesDto InsertarDireccion(DireccionesDto direccion)
        {
            var _direccion = new Direccione();
            using (var db = new BDPrimeStoneContext())
            {
                _direccion.IdDireccion = direccion.IdDireccion;
                _direccion.Nombre = direccion.Nombre;
                db.Direcciones.Add(_direccion);
                db.SaveChanges();
            }
            return direccion;
        }

        #endregion

        #region Actualizar
        public void ActualizarDireccion(DireccionesDto direccion)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _direccion = new Direccione();
                _direccion.IdDireccion = direccion.IdDireccion;
                _direccion.Nombre = direccion.Nombre;
                db.Entry(_direccion).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
        #endregion

        #region Eliminar
        public void EliminarDireccion(int id)
        {
            using (var db = new BDPrimeStoneContext())
            {
                var _direccion = db.Direcciones.Find(id);
                db.Direcciones.Remove(_direccion);
                db.SaveChanges();
            }
        }
        #endregion
    }
}
