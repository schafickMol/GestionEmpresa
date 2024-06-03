using GestionPersonalEmpresa.Modelos;
using System.Collections.Generic;

namespace GestionPersonalEmpresa.Interfaces
{
    public interface IProyectoService
    {
        List<Proyecto> ObtenerTodosLosProyectos();
    }
}