using BasicPack;
using Contexto;
using Controllers;

class Inicio
{
    static void Main(string[] args)
    {
        Console.Title = "Biblioteca DB";
        Colors.Magenta("Bienvenido!", true);
        var context = new AppDbContext();
      LibroController li = new LibroController(context);
        li.GetLibrosDisponiblesAsync();
        Console.ReadKey();

       

    }
        
}
