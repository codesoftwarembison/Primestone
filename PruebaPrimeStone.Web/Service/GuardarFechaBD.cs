using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PruebaPrimeStone.Common1.Dao;
using PruebaPrimeStone.Modelos.Dto;

namespace PruebaPrimeStone.Web.Service
{
    public class GuardarFechaBD : IHostedService, IDisposable
    {
        #region Propiedades
        private Timer timer;
        #endregion

        #region Metodos
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(40));
            return Task.CompletedTask;
        }

        //Guarda Direcciones random en la tabla Direcciones base de datos
        private void DoWork(object state)
        {
            var DireccionesDao = new DireccionesDao();
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            var direccion = "AC 70 #76-" + number + "";
            DireccionesDao.InsertarDireccion(new DireccionesDto { IdDireccion = 0, Nombre = direccion});
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;

        }
        #endregion
    }
}
