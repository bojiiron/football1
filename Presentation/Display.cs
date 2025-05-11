using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Football.Presentation
{
     public class Display
    {

        public Display()
        {
            Input();
        }
        private void ShowMenu()
        {
            /*  Console.WriteLine(new string('-', 40));
              Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
              Console.WriteLine(new string('-', 40));
            */
            Console.WriteLine(LogoTitle());
            Console.WriteLine("1. Nationality");
            Console.WriteLine("2. Player");
            Console.WriteLine("3. Player Team");
            Console.WriteLine("4. League");
            Console.WriteLine("5. Coach");
            Console.WriteLine("6. Exit");
        }

        private string LogoTitle()
        {

            String s = "\n ______          _   _           _ _                      _     _ " +
                      "\n |  ____|        | | | |         | | |                    | |   | | " +
                      "\n | |__ ___   ___ | |_| |__   __ _| | | __      _____  _ __| |__ | | " +
                      "\n |  __/ _ \\ / _ \\| __| '_ \\ / _` | | | \\ \\ /\\ / / _ \\| '__| |/ _` | " +
                      "\n | | | (_) | (_) | |_| |_) | (_| | | |  \\ V  V / (_) | |  | | (_| | " +
                      "\n |_|  \\___/ \\___/ \\__|_.__/ \\__,_|_|_|   \\_/\\_/ \\___/|_|  |_|\\__,_| " +
                      "\n \n";


            return s;
        }
        private void Input()
        {
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1:
                        {
                            new NationalityDisplay();
                            break;
                        }
                    case 2:
                        {
                            new PlayerDisplay();
                            break;
                        }
                    case 3:
                        {
                            new PlayerTeamDisplay();
                            break;
                        }
                    case 4:
                        {
                            new LeagueDisplay();
                            break;
                        }
                    case 5:
                        {
                            new CoachDisplay();
                            break;
                        }
                    default:
                        break;
                }
            } while (operation != 6);
        }
    }
}
