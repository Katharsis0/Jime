namespace Classmate.Models

{
    public class EventoCalendario
    {
        public DateTime Fecha { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}