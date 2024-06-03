using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GestionPersonalEmpresa.Controladores
{
    public class ControladorDesarrollador
    {
        private readonly IServicioDesarrollador _servicioDesarrollador;

        public ControladorDesarrollador(IServicioDesarrollador servicioDesarrollador)
        {
            _servicioDesarrollador = servicioDesarrollador;
        }

        public void VerTareasAsignadas(int desarrolladorId)
        {
            try
            {
                List<Tarea> tareas = _servicioDesarrollador.ObtenerTareasAsignadas(desarrolladorId);
                Console.WriteLine("Tareas asignadas:");
                foreach (var tarea in tareas)
                {
                    Console.WriteLine($"- {tarea.Descripcion} (Desde {tarea.FechaInicio.ToShortDateString()} hasta {tarea.FechaFin.ToShortDateString()})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SolicitarVacaciones(int desarrolladorId, DateTime inicio, DateTime fin)
        {
            try
            {
                _servicioDesarrollador.SolicitarVacaciones(desarrolladorId, inicio, fin);
                Console.WriteLine("Solicitud de vacaciones enviada con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}