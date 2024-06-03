using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Repositorios;

namespace GestionPersonalEmpresa.Servicios
{
    public class ProyectoService : IProyectoService
    {
        public List<Proyecto> ObtenerTodosLosProyectos()
        {
            return ProyectoRepositorio.Proyectos;
        }
    }
}
