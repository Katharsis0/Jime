namespace Classmate.Models
{
    public class Usuario
    {


        private int id;
        private string nombre;
        private string apellidoUno;
        private string apellidoDos;
        private string nombreUsuario;
        private string clave;
        private string correo;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoUno { get => apellidoUno; set => apellidoUno = value; }
        public string ApellidoDos { get => apellidoDos; set => apellidoDos = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Clave { get => clave; set => clave = value; }
        public string Correo { get => correo; set => correo = value; }

        public Usuario(int id, string nombre, string apellidoUno, string apellidoDos, string nombreUsuario, string clave, string correo)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidoUno = apellidoUno;
            this.apellidoDos = apellidoDos;
            this.nombreUsuario = nombreUsuario;
            this.clave = clave;
            this.correo = correo;
        }


        public Usuario()
        {
            this.id = 0;
            this.nombre = "";
            this.apellidoUno = "";
            this.apellidoDos = "";
            this.nombreUsuario = "";
            this.clave = "";
            this.correo = "";
        }

        



    }
}
