using GestionPersonalEmpresa.Modelos;
namespace GestionPersonalEmpresa.Interfaces
{
    public interface IServicioRRHH
    {
        void ContratarDesarrollador(List<Usuario> usuarios, Desarrollador nuevoDesarrollador);
        void DespedirDesarrollador(List<Usuario> usuarios, int idDesarrollador);
    }
}