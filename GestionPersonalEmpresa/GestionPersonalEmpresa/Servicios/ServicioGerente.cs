using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestionPersonalEmpresa.Servicios
{
    public class ServicioGerente : IServicioGerente
    {
        private readonly List<Proyecto> _proyectos;
        private readonly List<Usuario> _usuarios;

        public ServicioGerente(List<Proyecto> proyectos, List<Usuario> usuarios)
        {
            _proyectos = proyectos;
            _usuarios = usuarios;
        }

        public List<Proyecto> ObtenerTodosLosProyectos()
        {
            return _proyectos;
        }

        public List<Desarrollador> ObtenerTodosLosDesarrolladores()
        {
            return _usuarios.OfType<Desarrollador>().ToList();
        }
    }
}
