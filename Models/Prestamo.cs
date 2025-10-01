using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaApp.Models
{
    public class Prestamo
    {
        public Usuario Usuario { get; set; }
        public Libro Libro { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaDevolucion { get; set }

        public override string ToString()
        {
            string estado = FechaDevolucion == null ? "Activo" : $"Devuelto en {FechaDevolucion}";
            return $"{Libro.Titulo} prestado a {Usuario.Nombre} el {FechaPrestamo.ToShortDateString()} - {estado}";
        }
    }
}