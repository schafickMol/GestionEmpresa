using GestionPersonalEmpresa.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestionPersonalEmpresa.Modelos
{
    public class Gerente : Usuario
    {
        private readonly IProyectoService _proyectoService;

        public Gerente(int id, string nombre, string email, string contrasena, IProyectoService proyectoService)
            : base(id, nombre, email, contrasena, "Gerente")
        {
            _proyectoService = proyectoService;
        }

        public List<Proyecto> VerProyectos()
        {
            return _proyectoService.ObtenerTodosLosProyectos();
        }

        public List<Desarrollador> VerDesarrolladores(List<Usuario> usuarios)
        {
            return usuarios.OfType<Desarrollador>().ToList();
        }
    }
}