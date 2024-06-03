using System;

namespace GestionPersonalEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            Inicializador.Iniciar();
            GC.Collect();
        }
    }
}
