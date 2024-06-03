namespace GestionPersonalEmpresa.Modelos
{
    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Rol { get; set; }

        public Usuario(int id, string nombre, string email, string contrasena, string rol)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Contrasena = contrasena;
            Rol = rol;
        }
    }
}