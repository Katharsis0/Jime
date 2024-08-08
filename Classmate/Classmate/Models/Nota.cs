namespace Classmate.Models
{
    public class Nota
    {
        private int id;
        private string nombre;
        private string contenido;
        private string tema;
        private DateTime fecha;
        private Boolean pendiente;
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string Tema { get => tema; set => tema = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public bool Pendiente { get => pendiente; set => pendiente = value; }

        public Nota(int id, string nombre, string contenido, string tema, DateTime fecha, Boolean pendiente)
        {
            this.id = id;
            this.nombre = nombre;
            this.contenido = contenido;
            this.tema = tema;
            this.fecha = fecha;
            this.pendiente = pendiente;
        }
        public Nota()
        {
            this.id = 0;
            this.nombre = "";
            this.contenido = "";
            this.tema = "";
            this.fecha = DateTime.Now;
            this.pendiente = false;
        }
    }
}