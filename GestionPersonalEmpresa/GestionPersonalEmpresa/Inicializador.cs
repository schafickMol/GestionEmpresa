using GestionPersonalEmpresa.Controladores;
using GestionPersonalEmpresa.Interfaces;
using GestionPersonalEmpresa.Modelos;
using GestionPersonalEmpresa.Servicios;
using GestionPersonalEmpresa.Repositorios;
using Spectre.Console;
using System;
using System.Collections.Generic;

namespace GestionPersonalEmpresa
{
    public static class Inicializador
    {
        public static void Iniciar()
        {       
            IProyectoService proyectoService = new ProyectoService();

            var proyecto1 = new Proyecto(1, "Sistema de Gestión de Inventarios", "Activo");
            var proyecto2 = new Proyecto(2, "Aplicación de E-commerce", "Terminado");
            var proyecto3 = new Proyecto(3, "Plataforma de Aprendizaje en Línea", "Activo");
            var proyecto4 = new Proyecto(4, "Sistema de Reserva de Vuelos", "Terminado");

            ProyectoRepositorio.Proyectos.Add(proyecto1);
            ProyectoRepositorio.Proyectos.Add(proyecto2);
            ProyectoRepositorio.Proyectos.Add(proyecto3);
            ProyectoRepositorio.Proyectos.Add(proyecto4);

            var gerente1 = new Gerente(1, "María López", "maria.lopez@empresa.com", "password123", proyectoService);
            var gerente2 = new Gerente(2, "Carlos Pérez", "carlos.perez@empresa.com", "password123", proyectoService);

            var rrhh1 = new RRHH(3, "Ana García", "ana.garcia@empresa.com", "password123");
            var rrhh2 = new RRHH(4, "Luis Fernández", "luis.fernandez@empresa.com", "password123");

            var desarrollador1 = new Desarrollador(5, "José Martínez", "jose.martinez@empresa.com", "password123");
            var desarrollador2 = new Desarrollador(6, "Elena Gómez", "elena.gomez@empresa.com", "password123");
            var desarrollador3 = new Desarrollador(7, "Ricardo Sánchez", "ricardo.sanchez@empresa.com", "password123");

            desarrollador1.TareasAsignadas.Add(new Tarea(1, "Desarrollar módulo de autenticación", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(5), 1, 5));
            desarrollador2.TareasAsignadas.Add(new Tarea(2, "Crear diseño de base de datos", DateTime.Now.AddDays(-3), DateTime.Now.AddDays(7), 2, 6));

            List<Usuario> usuarios = new List<Usuario>
            {
                gerente1,
                gerente2,
                rrhh1,
                rrhh2,
                desarrollador1,
                desarrollador2,
                desarrollador3
            };

            IServicioAutenticacion servicioAutenticacion = new ServicioAutenticacion(usuarios);
            IServicioDesarrollador servicioDesarrollador = new ServicioDesarrollador(usuarios, new List<SolicitudVacaciones>());
            IServicioGerente servicioGerente = new ServicioGerente(ProyectoRepositorio.Proyectos, usuarios);
            IServicioRRHH servicioRRHH = new ServicioRRHH();

            ControladorAutenticacion controladorAutenticacion = new ControladorAutenticacion(servicioAutenticacion);
            ControladorDesarrollador controladorDesarrollador = new ControladorDesarrollador(servicioDesarrollador);
            ControladorGerente controladorGerente = new ControladorGerente(servicioGerente);
            ControladorRRHH controladorRRHH = new ControladorRRHH(servicioRRHH, usuarios);

            MostrarMenuInicio(controladorAutenticacion, controladorDesarrollador, controladorGerente, controladorRRHH);
        }

        private static void MostrarMenuInicio(ControladorAutenticacion controladorAutenticacion,
                                              ControladorDesarrollador controladorDesarrollador,
                                              ControladorGerente controladorGerente,
                                              ControladorRRHH controladorRRHH)
        {
            while (true)
            {
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .AddChoices(new[] { "Iniciar Sesión", "Salir" }));

                if (opcion == "Salir")
                {
                    break;
                }

                var email = AnsiConsole.Ask<string>("Ingrese su [green]correo electrónico[/]:");
                var contrasena = AnsiConsole.Prompt(
                    new TextPrompt<string>("Ingrese su [green]contraseña[/]:")
                        .PromptStyle("red")
                        .Secret());

                var usuarioAutenticado = controladorAutenticacion.IniciarSesion(email, contrasena);

                if (usuarioAutenticado != null)
                {
                    switch (usuarioAutenticado.Rol)
                    {
                        case "Gerente":
                            MostrarMenuGerente(controladorGerente);
                            break;
                        case "RRHH":
                            MostrarMenuRRHH(controladorRRHH);
                            break;
                        case "Desarrollador":
                            MostrarMenuDesarrollador(controladorDesarrollador, usuarioAutenticado.Id);
                            break;
                        default:
                            AnsiConsole.MarkupLine("[red]Rol no reconocido[/]");
                            break;
                    }
                }
            }
        }

        private static void MostrarMenuGerente(ControladorGerente controladorGerente)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold blue]Menú de Gerente[/]");
                var opcion = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .AddChoices(new[] { "Ver todos los proyectos", "Ver todos los desarrolladores", "Regresar" }));

                if (opcion == "Regresar")
                {
                    AnsiConsole.Clear();
                    break;
                }

                switch (opcion)
                {
                    case "Ver todos los proyectos":
                        controladorGerente.VerTodosLosProyectos();
                        break;
                    case "Ver todos los desarrolladores":
                        controladorGerente.VerTodosLosDesarrolladores();
                        break;
                }

                AnsiConsole.MarkupLine("[grey]Presione [green]Enter[/] para regresar al menú[/]");
                Console.ReadLine();
            }
        }

        private static void MostrarMenuRRHH(ControladorRRHH controladorRRHH)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold blue]Menú de Recursos Humanos[/]");
                var opcionRRHH = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .AddChoices(new[] { "Ver todos los desarrolladores", "Contratar desarrollador", "Despedir desarrollador", "Regresar" }));

                if (opcionRRHH == "Regresar")
                {
                    AnsiConsole.Clear();
                    break;
                }

                switch (opcionRRHH)
                {
                    case "Ver todos los desarrolladores":
                        controladorRRHH.VerTodosLosDesarrolladores();
                        break;
                    case "Contratar desarrollador":
                        controladorRRHH.ContratarDesarrollador();
                        break;
                    case "Despedir desarrollador":
                        controladorRRHH.DespedirDesarrollador();
                        break;
                }

                AnsiConsole.MarkupLine("[grey]Presione [green]Enter[/] para regresar al menú[/]");
                Console.ReadLine();
            }
        }

        private static void MostrarMenuDesarrollador(ControladorDesarrollador controladorDesarrollador, int desarrolladorId)
        {
            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold blue]Menú de Desarrollador[/]");
                var opcionDesarrollador = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Seleccione una opción")
                        .AddChoices(new[] { "Ver tareas asignadas", "Solicitar vacaciones", "Regresar" }));

                if (opcionDesarrollador == "Regresar")
                {
                    AnsiConsole.Clear();
                    break;
                }

                switch (opcionDesarrollador)
                {
                    case "Ver tareas asignadas":
                        controladorDesarrollador.VerTareasAsignadas(desarrolladorId);
                        break;
                    case "Solicitar vacaciones":
                        var inicio = AnsiConsole.Ask<DateTime>("Ingrese la [green]fecha de inicio[/] (yyyy-mm-dd):");
                        var fin = AnsiConsole.Ask<DateTime>("Ingrese la [green]fecha de fin[/] (yyyy-mm-dd):");
                        controladorDesarrollador.SolicitarVacaciones(desarrolladorId, inicio, fin);
                        break;
                }

                AnsiConsole.MarkupLine("[grey]Presione [green]Enter[/] para regresar al menú[/]");
                Console.ReadLine();
            }
        }
    }
}