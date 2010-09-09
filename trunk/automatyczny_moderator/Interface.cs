using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace automatyczny_moderator
{
    class Interface
    {
        private const string YES = "y";
        private const string NO = "n";

        public bool startModerator()
        {
            Console.WriteLine("Automatyczny moderator");
            Console.WriteLine("Patryk Jar");
            Console.WriteLine("wrzesien 2010 r.");
            Console.WriteLine("");
            
            string dec = "";
            while (YES != dec && NO != dec)
            {
                Console.WriteLine("Czy chcesz uruchomić automatycznego moderatora? y /n");
                dec = Console.ReadLine();
            }
            return (YES == dec);
        }

        public void goodByeScreen()
        {
            Console.WriteLine("Dziękuję za skorzystanie z programu.");
            Console.WriteLine("\nNaciśnij enter by zakończyć program...");
            Console.Read();
        }
    }
}
