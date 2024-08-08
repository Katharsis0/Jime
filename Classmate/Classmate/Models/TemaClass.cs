namespace Classmate.Models
{
    public class TemaClass
    {

        private int id;
        private string tema;

        public TemaClass(int id, string tema)
        {
            this.id = id;
            this.tema = tema;
        }


        public TemaClass()
        {
            this.id = 0;
            this.tema = "";
        }

        public int Id { get => id; set => id = value; }
        public string Tema { get => tema; set => tema = value; }
    }
}
