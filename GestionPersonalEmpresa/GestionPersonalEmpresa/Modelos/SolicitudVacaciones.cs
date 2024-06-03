using System;

namespace GestionPersonalEmpresa.Modelos
{
    public class SolicitudVacaciones
    {
        public int Id { get; set; } 
        public int IdDesarrollador { get; set; } 
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; } 
        public string Estado { get; set; } 

        public SolicitudVacaciones(int idDesarrollador, DateTime fechaInicio, DateTime fechaFin, string estado)
        {
            IdDesarrollador = idDesarrollador;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            Estado = estado;
        }
    }
}