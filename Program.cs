using BibliotecaApp.Models;
using BibliotecaApp.Services;

BibliotecaService biblioteca = new();
PrestamoService prestamoService = new();
UsuarioService usuarioService = new();

bool salir = false;

while (!salir)
{
    Console.WriteLine("\n--- Sistema de Biblioteca ---");
    Console.WriteLine("1. Agregar libro");
    Console.WriteLine("2. Listar libros");
    Console.WriteLine("3. Buscar libro");
    Console.WriteLine("4. Registrar usuario");
    Console.WriteLine("5. Listar usuarios");
    Console.WriteLine("6. Prestar libro");
    Console.WriteLine("7. Devolver libro");
    Console.WriteLine("8. Listar préstamos activos");
    Console.WriteLine("9. Historial de usuario");
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
            Console.WriteLine("\n--- Buscar libro ---");
            Console.WriteLine("1. Buscar por título");
            Console.WriteLine("2. Buscar por autor");
            Console.WriteLine("3. Buscar por ISBN");
            Console.Write("Elija una opción: ");
            string tipoBusqueda = Console.ReadLine();

            Console.Write("Ingrese el texto a buscar: ");
            string termino = Console.ReadLine();

            List<Libro> resultados = new();

            switch (tipoBusqueda)
            {
                case "1":
                    resultados = biblioteca.BuscarPorTitulo(termino);
                    break;
                case "2":
                    resultados = biblioteca.BuscarPorAutor(termino);
                    break;
                case "3":
                    var libroEncontrado = biblioteca.BuscarPorISBN(termino);
                    if (libroEncontrado != null) resultados.Add(libroEncontrado);
                    break;
                default:
                    Console.WriteLine("❌ Opción no válida.");
                    break;
            }

            if (resultados.Count == 0)
                Console.WriteLine("⚠️ No se encontraron libros.");
            else
                resultados.ForEach(r => Console.WriteLine(r));
            break;


        case "4":
            Console.Write("ID Usuario: ");
            string idU = Console.ReadLine();
            Console.Write("Nombre: ");
            string nombreU = Console.ReadLine();
            usuarioService.RegistrarUsuario(new Usuario { Id = idU, Nombre = nombreU });
            break;

        case "5":
            foreach (var u in usuarioService.ListarUsuarios())
                Console.WriteLine($"{u.Id} - {u.Nombre}");
            break;

        case "6":
            Console.Write("ID Usuario: ");
            string idUsuario = Console.ReadLine();
            var usuario = usuarioService.BuscarUsuario(idUsuario);

            if (usuario == null)
            {
                Console.WriteLine("❌ Usuario no registrado.");
                break;
            }

            Console.Write("ISBN Libro: ");
            string isbnPrestamo = Console.ReadLine();
            var libro = biblioteca.BuscarPorISBN(isbnPrestamo);

            if (libro == null)
            {
                Console.WriteLine("❌ Libro no encontrado.");
                break;
            }

            prestamoService.PrestarLibro(usuario, libro);
            break;

        case "7":
            Console.Write("ID Usuario: ");
            string idUser = Console.ReadLine();
            Console.Write("ISBN Libro: ");
            string isbnDev = Console.ReadLine();
            prestamoService.DevolverLibro(isbnDev, idUser);
            break;

        case "8":
            foreach (var p in prestamoService.PrestamosActivos())
                Console.WriteLine(p);
            break;

        case "9":
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
