namespace GestionPersonalEmpresa.Modelos
{
    public class Proyecto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; } 

        public Proyecto(int id, string nombre, string estado)
        {
            Id = id;
            Nombre = nombre;
            Estado = estado;
        }
    }
}
