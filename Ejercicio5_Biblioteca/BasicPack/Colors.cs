using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicPack
{
   public static class Colors
    {
        public static void Blue (string sc,bool salto=false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(sc);
                Console.ResetColor();                   
            }else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(sc);
                Console.ResetColor();
            }
}
        public static void Cyan(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(sc);
                Console.ResetColor();
            }
        }
        public static void White(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(sc);
                Console.ResetColor();
            }
        }
        public static void Magenta(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(sc);
                Console.ResetColor();
            }
        }
        public static void Red(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sc);
                Console.ResetColor();
            }
        }
        public static void DarkGray(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(sc);
                Console.ResetColor();
            }
        }
        public static void Green(string sc, bool salto = false)
        {
            if (salto)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(sc);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(sc);
                Console.ResetColor();
            }
        }


    }
}

