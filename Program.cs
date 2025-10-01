using BibliotecaApp.Models;
using BibliotecaApp.Services;

BibliotecaService biblioteca = new();
PrestamoService prestamoService = new();

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- Sistema de Biblioteca ---");
    Console.WriteLine("1. Agregar libro");
    Console.WriteLine("2. Listar libros");
    Console.WriteLine("3. Buscar libro");
    Console.WriteLine("4. Prestar libro");
    Console.WriteLine("5. Devolver libro");
    Console.WriteLine("6. Listar préstamos activos");
    Console.WriteLine("7. Historial de usuario");
    Console.WriteLine("0. Salir");
    Console.Write("Opción: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor: ");
            string autor = Console.ReadLine();
            biblioteca.AgregarLibro(new Libro { ISBN = isbn, Titulo = titulo, Autor = autor });
            break;

        case "2":
            foreach (var l in biblioteca.ListarLibros())
                Console.WriteLine(l);
            break;

        case "3":
            Console.Write("Buscar por (titulo/autor/isbn): ");
            string tipo = Console.ReadLine()?.ToLower();
            Console.Write("Ingrese término: ");
            string termino = Console.ReadLine();

            List<Libro> resultados = tipo switch
            {
                "titulo" => biblioteca.BuscarPorTitulo(termino),
                "autor" => biblioteca.BuscarPorAutor(termino),
                "isbn" => new List<Libro> { biblioteca.BuscarPorISBN(termino) }.Where(l => l != null).ToList(),
                _ => new List<Libro>()
            };

            resultados.ForEach(r => Console.WriteLine(r));
            break;

        case "4":
            Console.Write("ID Usuario: ");
            string idUsuario = Console.ReadLine();
            Console.Write("Nombre Usuario: ");
            string nombreUsuario = Console.ReadLine();
            Console.Write("ISBN Libro: ");
            string isbnPrestamo = Console.ReadLine();

            var libro = biblioteca.BuscarPorISBN(isbnPrestamo);
            if (libro != null)
            {
                prestamoService.PrestarLibro(new Usuario { ID = idUsuario, Nombre = nombreUsuario }, libro);
            }
            else
            {
                Console.WriteLine("Libro no encontrado.");
            }
            break;

        case "5":
            Console.Write("ID Usuario: ");
            string idU = Console.ReadLine();
            Console.Write("ISBN Libro: ");
            string isbnDev = Console.ReadLine();
            prestamoService.DevolverLibro(isbnDev, idU);
            break;

        case "6":
            foreach (var p in prestamoService.PrestamosActivos())
                Console.WriteLine(p);
            break;

        case "7":
            Console.Write("ID Usuario: ");
            string idHist = Console.ReadLine();
            foreach (var p in prestamoService.HistorialUsuario(idHist))
                Console.WriteLine(p);
            break;

        case "0":
            salir = true;
            break;
    }
}
