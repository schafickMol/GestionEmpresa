using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestionPersonalEmpresa.Servicios
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {
        private readonly List<Usuario> _usuarios;

        public ServicioAutenticacion(List<Usuario> usuarios)
        {
            _usuarios = usuarios;
        }

        public Usuario Autenticar(string email, string contrasena)
        {
            var usuario = _usuarios.SingleOrDefault(u => u.Email == email && u.Contrasena == contrasena);
            if (usuario == null)
            {
                throw new System.Exception("Correo electrónico o contraseña incorrectos.");
            }
            return usuario;
        }
    }
}