using Classmate.Models;

public class CalendarioViewModel
{
    public DateTime FechaActual { get; set; }
    public List<EventoCalendario> Eventos { get; set; } = new List<EventoCalendario>();
}