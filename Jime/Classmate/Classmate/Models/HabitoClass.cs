namespace Classmate.Models
{
    public class HabitoClass
    {

        private int id;
        private string habito;

        public HabitoClass(int id, string habito)
        {
            this.id = id;
            this.habito = habito;
        }


        public HabitoClass()
        {
            this.id = 0;
            this.habito = "";
        }

        public int Id { get => id; set => id = value; }
        public string Habito { get => habito; set => habito = value; }
    }
}
