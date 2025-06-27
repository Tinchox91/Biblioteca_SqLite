using System.Net.Mail;

namespace BasicPack
{
    public static class Valid
    {
        public static double IsNumberDouble()
        {
            bool valid = true;
            string numero = "";
            double number = 0;
            do
            {

                numero = Console.ReadLine();
                if (string.IsNullOrEmpty(numero) || string.IsNullOrWhiteSpace(numero))
                {
                    valid = false;
                    Colors.Red("No debe estar vacio o con espacios...", true);
                    Colors.White("Ingrese de nuevo: ");
                    continue;
                }
                try
                {
                    number = double.Parse(numero);
                    valid = true;
                    return number;
                }
                catch (FormatException e)
                {
                    valid = false;
                    Colors.Red($"Error intente de nuevo: {e.Message}", true);
                    Colors.White("Ingrese de nuevo: ");
                }

            } while (!valid);
            return number;
        }
        public static int IsNumber()
        {
            bool valid = true;
            string numero = "";
            int number = 0;
            do
            {

                numero = Console.ReadLine();
                if (string.IsNullOrEmpty(numero) || string.IsNullOrWhiteSpace(numero))
                {
                    valid = false;
                    Colors.Red("No debe estar vacio o con espacios...", true);
                    Colors.White("Ingrese de nuevo: ");
                    continue;

                }
                try
                {
                    number = int.Parse(numero);
                    valid = true;
                    return number;
                }
                catch (FormatException e)
                {
                    valid = false;
                    Colors.Red($"Error intente de nuevo  {e.Message}", true);
                    Colors.White("Ingrese de nuevo: ");
                }

            } while (!valid);
            return number;
        }
        public static string IsString()
        {
            string texto = Console.ReadLine();
            if (string.IsNullOrEmpty(texto) || string.IsNullOrWhiteSpace(texto))
            {
                Colors.Red("No debe estar vacio o con espacios...", true);
                return IsString();
            }
            return texto;
        }
        public static string IsNumberString()
        {
            bool valid = true;
            string numero = "";
            int number = 0;
            do
            {

                numero = Console.ReadLine();
                if (string.IsNullOrEmpty(numero) || string.IsNullOrWhiteSpace(numero))
                {
                    valid = false;
                    Colors.Red("No debe estar vacio o con espacios...", true);
                    Colors.White("Ingrese de nuevo: ");
                    continue;

                }
                try
                {
                    number = int.Parse(numero);
                    valid = true;
                    return numero;
                }
                catch (FormatException e)
                {
                    valid = false;
                    Colors.Red($"Error intente de nuevo  {e.Message}", true);
                    Colors.White("Ingrese de nuevo: ");
                }

            } while (!valid);
            return numero;
        }
        public static string IsMail()
        {
            string mail = "";
            do
            {
               mail = Console.ReadLine();
                if (string.IsNullOrEmpty(mail) || string.IsNullOrWhiteSpace(mail))
                {
                    Colors.Red("No debe estar vacio o con espacios...", true);
                    Colors.White("Ingrese de nuevo: ");
                    mail = null;
                    continue;
                }
                try
                {
                    MailAddress mailAddress = new MailAddress(mail);
                    return mail;
                }
                catch (FormatException e)
                {
                    Colors.Red($"Error intente de nuevo: {e.Message}", true);
                    Colors.White("Ingrese de nuevo: ");
                    mail = null;
                }
              
            } while (mail!=null);

            return mail;

        }

        public static string EsFecha() {

            string fecha = "";  
            do
            {
                fecha = IsString();
               
                try
                {
                    DateTime.Parse(fecha);
                    return fecha;
                }
                catch (FormatException e)
                {
                    Colors.Red($"Error intente de nuevo: {e.Message}", true);
                    Colors.White("Ingrese de nuevo: ");
                    fecha = "";
                }
            } while (fecha != null);
            return fecha;
        }
    }
}
