using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new();

        public void PrestarLibro(Usuario usuario, Libro libro)
        {
            if (!libro.Disponible)
            {
                Console.WriteLine("El libro ya está prestado");
                return;
            }

            libro.Disponible = false;
            prestamos.Add(new Prestamo
            {
                Usuario = usuario,
                Libro = libro,
                FechaPrestamo = DateTime.Now
            });
        }

        public void DevolverLibro(string isbn, string idUsuario)
        {
            var prestamo = prestamos.FirstOrDefault(p=>
                p.Libro.ISBN == isbn && p.Usuario.ID == idUsuario && p.FechaDevolucion == null);

            if (prestamo == null)
            {
                Console.WriteLine("No se encontró préstamo activo");
                return;
            }

            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Libro.Disponible = true;
        }

        public List<Prestamo> PrestamosActivos() => 
            prestamos.Where(p => p.FechaDevolucion == null).ToList();

        public List<Prestamo> HistorialUsuario(string idUsuario) =>
            prestamos.Where(p => p.Usuario.ID == idUsuario).ToList();
    }
}
