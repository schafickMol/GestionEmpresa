using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace GestionPersonalEmpresa.Servicios
{
    public class ServicioRRHH : IServicioRRHH
    {
        public void ContratarDesarrollador(List<Usuario> usuarios, Desarrollador nuevoDesarrollador)
        {
            usuarios.Add(nuevoDesarrollador);
        }

        public void DespedirDesarrollador(List<Usuario> usuarios, int idDesarrollador)
        {
            var desarrollador = usuarios.OfType<Desarrollador>().FirstOrDefault(d => d.Id == idDesarrollador);
            if (desarrollador == null)
            {
                throw new System.Exception("Desarrollador no encontrado.");
            }
            usuarios.Remove(desarrollador);
        }
    }
}