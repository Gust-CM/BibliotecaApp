namespace BibliotecaApp.Models
{
    public class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; } = true;

        public override string ToString()
        {
            return $"[{ISBN}] {Titulo} - {Autor} | {(Disponible ? "Disponible" : "Prestado")}";
        }
    }
}