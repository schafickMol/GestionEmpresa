using GestionPersonalEmpresa.Modelos;
namespace GestionPersonalEmpresa.Interfaces
{
    public interface IServicioGerente
    {
        List<Proyecto> ObtenerTodosLosProyectos();
        List<Desarrollador> ObtenerTodosLosDesarrolladores();
    }
}
