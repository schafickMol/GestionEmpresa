using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using System;
using System.Collections.Generic;

namespace GestionPersonalEmpresa.Controladores
{
    public class ControladorGerente
    {
        private readonly IServicioGerente _servicioGerente;

        public ControladorGerente(IServicioGerente servicioGerente)
        {
            _servicioGerente = servicioGerente;
        }

        public void VerTodosLosProyectos()
        {
            try
            {
                List<Proyecto> proyectos = _servicioGerente.ObtenerTodosLosProyectos();
                Console.WriteLine("Lista de todos los proyectos:");
                foreach (var proyecto in proyectos)
                {
                    Console.WriteLine($"- {proyecto.Nombre} ({proyecto.Estado})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void VerTodosLosDesarrolladores()
        {
            try
            {
                List<Desarrollador> desarrolladores = _servicioGerente.ObtenerTodosLosDesarrolladores();
                Console.WriteLine("Lista de todos los desarrolladores:");
                foreach (var desarrollador in desarrolladores)
                {
                    Console.WriteLine($"- {desarrollador.Nombre} ({desarrollador.Email})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}