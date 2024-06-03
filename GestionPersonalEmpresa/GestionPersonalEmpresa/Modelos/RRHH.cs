using System.Collections.Generic;
using System.Linq;

namespace GestionPersonalEmpresa.Modelos
{
    public class RRHH : Usuario
    {
        public RRHH(int id, string nombre, string email, string contrasena)
            : base(id, nombre, email, contrasena, "RRHH")
        {
        }

        public void ContratarDesarrollador(List<Usuario> usuarios, Desarrollador nuevoDesarrollador)
        {
            usuarios.Add(nuevoDesarrollador);
        }

        public void DespedirPersonal(List<Usuario> usuarios, int idDesarrollador)
        {
            var desarrollador = usuarios.OfType<Desarrollador>().FirstOrDefault(d => d.Id == idDesarrollador);
            if (desarrollador != null)
            {
                usuarios.Remove(desarrollador);
            }
        }
    }
}
