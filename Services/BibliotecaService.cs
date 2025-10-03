using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaApp.Services
{
    public class BibliotecaService
    {
        private List<Libro> libros = new();

        // Agregar un libro
        public void AgregarLibro(Libro libro) => libros.Add(libro);

        // Listar todos los libros
        public List<Libro> ListarLibros() => libros;

        // Buscar por título (ignora mayúsculas/minúsculas)
        public List<Libro> BuscarPorTitulo(string titulo) =>
            libros.Where(l => l.Titulo.Contains(titulo, StringComparison.OrdinalIgnoreCase)).ToList();

        // Buscar por autor
        public List<Libro> BuscarPorAutor(string autor) =>
            libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();

        // Buscar por ISBN
        public Libro? BuscarPorISBN(string isbn) =>
            libros.FirstOrDefault(l => l.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
    }
}
