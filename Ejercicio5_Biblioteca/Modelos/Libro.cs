using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Libro
    {
        [Key]
        public int Isbn { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Disponibilidad { get; set; }

        public Libro(string titulo, string autor, string disponibilidad)
        {
            Titulo = titulo ?? throw new ArgumentNullException(nameof(titulo));
            Autor = autor ?? throw new ArgumentNullException(nameof(autor));
            Disponibilidad = disponibilidad ?? throw new ArgumentNullException(nameof(disponibilidad));
        }

        public Libro()
        {
        }
    }
}
