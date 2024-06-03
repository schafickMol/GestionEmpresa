using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using System;
using System.Collections.Generic;

namespace GestionPersonalEmpresa.Controladores
{
    public class ControladorRRHH
    {
        private readonly IServicioRRHH _servicioRRHH;
        private readonly List<Usuario> _usuarios;

        public ControladorRRHH(IServicioRRHH servicioRRHH, List<Usuario> usuarios)
        {
            _servicioRRHH = servicioRRHH;
            _usuarios = usuarios;
        }

        public void ContratarDesarrollador()
        {
            try
            {
                Console.WriteLine("Ingrese el ID del nuevo desarrollador:");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del nuevo desarrollador:");
                string nombre = Console.ReadLine();
                Console.WriteLine("Ingrese el correo electrónico del nuevo desarrollador:");
                string email = Console.ReadLine();
                Console.WriteLine("Ingrese la contraseña del nuevo desarrollador:");
                string contrasena = Console.ReadLine();

                var nuevoDesarrollador = new Desarrollador(id, nombre, email, contrasena);
                _servicioRRHH.ContratarDesarrollador(_usuarios, nuevoDesarrollador);
                Console.WriteLine("Desarrollador contratado con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DespedirDesarrollador()
        {
            try
            {
                Console.WriteLine("Ingrese el ID del desarrollador a despedir:");
                int id = int.Parse(Console.ReadLine());

                _servicioRRHH.DespedirDesarrollador(_usuarios, id);
                Console.WriteLine("Desarrollador despedido con éxito.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void VerTodosLosDesarrolladores()
        {
            try
            {
                List<Desarrollador> desarrolladores = _usuarios.OfType<Desarrollador>().ToList();
                Console.WriteLine("Lista de todos los desarrolladores:");
                foreach (var desarrollador in desarrolladores)
                {
                    Console.WriteLine($"- {desarrollador.Nombre} ({desarrollador.Email})");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}