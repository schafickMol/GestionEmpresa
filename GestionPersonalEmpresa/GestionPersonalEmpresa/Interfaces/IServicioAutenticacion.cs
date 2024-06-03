using GestionPersonalEmpresa.Modelos;

namespace GestionPersonalEmpresa.Interfaces
{
    public interface IServicioAutenticacion
    {
        Usuario Autenticar(string email, string contrasena);
    }
}