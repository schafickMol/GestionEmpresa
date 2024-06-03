using GestionPersonalEmpresa.Modelos;
using System.Threading;

namespace GestionPersonalEmpresa.Interfaces
{
    public interface IServicioDesarrollador
    {
        List<Tarea> ObtenerTareasAsignadas(int desarrolladorId);
        void SolicitarVacaciones(int desarrolladorId, DateTime inicio, DateTime fin);
    }
}
