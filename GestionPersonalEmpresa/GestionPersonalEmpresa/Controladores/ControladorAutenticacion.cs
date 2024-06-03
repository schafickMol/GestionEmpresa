using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using System;

namespace GestionPersonalEmpresa.Controladores
{
    public class ControladorAutenticacion
    {
        private readonly IServicioAutenticacion _servicioAutenticacion;

        public ControladorAutenticacion(IServicioAutenticacion servicioAutenticacion)
        {
            _servicioAutenticacion = servicioAutenticacion;
        }

        public Usuario IniciarSesion(string email, string contrasena)
        {
            try
            {
                var usuario = _servicioAutenticacion.Autenticar(email, contrasena);
                Console.WriteLine($"Bienvenido, {usuario.Nombre} ({usuario.Rol})");
                return usuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}