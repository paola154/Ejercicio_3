namespace Datos.Entidades
{
    public class Usuarios
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public string Rol { get; set; }
        public string Profesion { get; set; }
        public bool Estado { get; set; }
        public string Clave { get; set; }

        public Usuarios()
        {
        }

        public Usuarios(string codigo, string nombre, string edad, string rol, string profesion, bool estado, string clave)
        {
            Codigo = codigo;
            Nombre = nombre;
            Edad = edad;
            Rol = rol;
            Profesion = profesion;
            Estado = estado;
            Clave = clave;
        }
    }
}
