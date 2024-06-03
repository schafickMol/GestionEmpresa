using System;

namespace GestionPersonalEmpresa.Modelos
{
    public class Tarea
    {
        public int Id { get; set; } 
        public string Descripcion { get; set; } 
        public DateTime FechaInicio { get; set; } 
        public DateTime FechaFin { get; set; } 
        public int IdProyecto { get; set; } 
        public int IdDesarrollador { get; set; } 

        public Tarea(int id, string descripcion, DateTime fechaInicio, DateTime fechaFin, int idProyecto, int idDesarrollador)
        {
            Id = id;
            Descripcion = descripcion;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            IdProyecto = idProyecto;
            IdDesarrollador = idDesarrollador;
        }
    }
}
