using System;
using System.Collections.Generic;
using System.Threading;

namespace GestionPersonalEmpresa.Modelos
{
    public class Desarrollador : Usuario
    {
        public List<Tarea> TareasAsignadas { get; set; }

        public Desarrollador(int id, string nombre, string email, string contrasena)
            : base(id, nombre, email, contrasena, "Desarrollador")
        {
            TareasAsignadas = new List<Tarea>();
        }

        public List<Tarea> VerTareasAsignadas()
        {
            return TareasAsignadas;
        }

        public void SolicitarVacaciones(List<SolicitudVacaciones> solicitudes, DateTime inicio, DateTime fin)
        {
            var solicitud = new SolicitudVacaciones(this.Id, inicio, fin, "Pendiente");
            solicitudes.Add(solicitud);
        }
    }
}