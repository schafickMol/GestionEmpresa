using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GestionPersonalEmpresa.Servicios
{
    public class ServicioDesarrollador : IServicioDesarrollador
    {
        private readonly List<Usuario> _usuarios;
        private readonly List<SolicitudVacaciones> _solicitudesVacaciones;

        public ServicioDesarrollador(List<Usuario> usuarios, List<SolicitudVacaciones> solicitudesVacaciones)
        {
            _usuarios = usuarios;
            _solicitudesVacaciones = solicitudesVacaciones;
        }

        public List<Tarea> ObtenerTareasAsignadas(int desarrolladorId)
        {
            var desarrollador = _usuarios.OfType<Desarrollador>().FirstOrDefault(d => d.Id == desarrolladorId);
            if (desarrollador == null)
            {
                throw new Exception("Desarrollador no encontrado.");
            }

            return desarrollador.TareasAsignadas;
        }

        public void SolicitarVacaciones(int desarrolladorId, DateTime inicio, DateTime fin)
        {
            var desarrollador = _usuarios.OfType<Desarrollador>().FirstOrDefault(d => d.Id == desarrolladorId);
            if (desarrollador == null)
            {
                throw new Exception("Desarrollador no encontrado.");
            }

            var solicitud = new SolicitudVacaciones(desarrolladorId, inicio, fin, "Pendiente");
            _solicitudesVacaciones.Add(solicitud);
        }
    }
}