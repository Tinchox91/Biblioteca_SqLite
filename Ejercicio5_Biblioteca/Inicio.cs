using BasicPack;
using Contexto;
using Controllers;
using Views;

class Inicio
{
    static void Main(string[] args)
    {
        // Inicializar el contexto de la base de datos
        var context = new AppDbContext();
        LibroController li = new LibroController(context);
        UsuarioController us = new UsuarioController(context);
        PrestamoController pr = new PrestamoController(context);
        /// ******************************************************
        /// 
        //Titulo de la consola
        Console.Title = "Biblioteca DB";
        // ******************************************************


       

      string opcion="4";
        do
        {
            Console.Clear();
          
            //Menu principal
            string mensaje = "Bienvenido a la Biblioteca";
            string x = new string('-', mensaje.Length);
            Colors.Magenta(mensaje, true);
            Colors.DarkGray(x, true);

            Colors.White("Seleccione una opción:", true);
            Colors.Magenta(" 1. ");
            Colors.White("Libros", true);
            Colors.Magenta(" 2. ");
            Colors.White("Usuarios", true);
            Colors.Magenta(" 3. ");
            Colors.White("Préstamos", true);
            Colors.Magenta(" 4. ");
            Colors.White("Salir", true);

            Colors.DarkGray(x, true);


            // Leer la opción del usuario
            opcion = Console.ReadLine();
            switch (opcion)
            {
                //Libros
                case "1":
                    string opcionLibro;
                    do
                    {
                        Console.Clear();
                        opcionLibro = LibroView.MenuLibro();
                        switch (opcionLibro)
                        {
                            case "1":
                                li.AddLibroAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "2":
                               li.DeleteLibroAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "3":
                                li.UpdateLibroAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "4":
                              li.SearchLibrosAutorAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "5":
                              li.GetLibroByIsbnAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "6":
                                li.GetLibrosAsync().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                                case "7":
                                    Colors.White("Saliendo del menú de Libros...");
                                break;
                            default:
                                Colors.Red("Opción no válida. Intente nuevamente.");
                                break;
                        }
                    } while (opcionLibro != "7");
                    break;
                //Usuarios
                case "2":
                    
                        string opcionUsuario;
                  
                    do
                    {
                        Console.Clear();
                        opcionUsuario = UsuarioView.MenuUsuario();
                        switch (opcionUsuario)
                        {
                            case "1":
                              us.AddUsuario().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...",true);
                                Console.ReadKey();
                                
                                break;
                            case "2":
                               us.GetUsuarioById().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "3":
                              us.GetUsuarios().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "4":
                               us.UpdateUsuario().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "5":
                                us.DeleteUsuario().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "6":
                                us.SearchUsuarios().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "7":
                                Colors.White("Saliendo del menú de Usuarios...");
                                break;
                            default:
                                Colors.Red("Opción no válida. Intente nuevamente.");
                                break;
                        }
                    } while (opcionUsuario!="7");
                    

                    break;
                //Préstamos
                case "3":
                        string opcionPrestamo;
                    Console.Clear();
                   
                    do
                    {
                        Console.Clear();
                        opcionPrestamo = PrestamoView.MenuPrestamo();
                        switch (opcionPrestamo)
                        {
                            case "1":
                                pr.AddPrestamo().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "2":
                                pr.GetPrestamos().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "3":
                              pr.UpdatePrestamo().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "4":
                               pr.DeletePrestamo().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "5":
                               pr.GetPrestamoById().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "6":
                                pr.SearchPrestamos().GetAwaiter().GetResult();
                                Colors.DarkGray("Apriete cualquier tecla para continuar...", true);
                                Console.ReadKey();
                                break;
                            case "7":
                                Colors.White("Saliendo del menú de Préstamos...");
                                break;
                            default:
                                Colors.Red("Opción no válida. Intente nuevamente.");
                               break;
                        }
                    } while (opcionPrestamo!="7");
                    break;
            }
        } while (opcion!="4");
    
    }
        
}
