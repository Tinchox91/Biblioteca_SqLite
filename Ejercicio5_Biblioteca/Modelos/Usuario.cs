using System.Net.Mail;

namespace Modelos

{
   public class Usuario
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public Usuario(string name, string mail)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Mail = mail ?? throw new ArgumentNullException(nameof(mail));
        }

        public Usuario()
        {
        }
    }
}
