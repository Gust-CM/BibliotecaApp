using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Services
{
    public class BibliotecaService
    {
        private List<Libro> libros = new();

        public void AgregarLibro(Libro libro) => libros.Add(libro);

        public List<Libro> ListarLibros() => libros;

        public Libro? BuscarPorISBN(string isbn) => libros.FirstOrDefault(l => l.ISBN == isbn);

        public List<Libro> BuscarPorTitulo(string titulo) => libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Libro> BuscarPorAutor(string Autor) =>
            libros.Where(l => l.Autor.Contains(Autor, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
