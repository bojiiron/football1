using Football.Business;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
    public class PlayerDisplay
    {
        private int closeOperationId = 6;
        private PlayerBusiness playerBusiness = new PlayerBusiness();
        public int getOperation()
        { return closeOperationId; }
        public PlayerDisplay()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Player" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
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
                        ListAll();
                        break;
                    case 2:
                        Add();
                        break;
                    case 3:
                        Update();
                        break;
                    case 4:
                        Fetch();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        break;
                }
            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            playerBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Player player = playerBusiness.Get(id);
            if (playerBusiness != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + player.Id);
                Console.WriteLine("Name: " + player.Name);
                Console.WriteLine("Team ID: " + player.TeamId);
                Console.WriteLine("Nationality ID: " + player.NationalityId);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Player player = playerBusiness.Get(id);
            if (player != null)
            {
                Console.WriteLine("Enter name: ");
                player.Name = Console.ReadLine();
                Console.WriteLine("Enter team: ");
                player.TeamId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter nationality: ");
                player.NationalityId = int.Parse(Console.ReadLine());
                playerBusiness.Update(player);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Player player = new Player();
            Console.WriteLine("Enter ID: ");
            player.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            player.Name = Console.ReadLine();
            Console.WriteLine("Enter Team: ");
            player.TeamId =int.Parse(Console.ReadLine());
            Console.WriteLine("Enter nationality: ");
            player.NationalityId = int.Parse(Console.ReadLine());
            playerBusiness.Add(player);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Player" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var player = playerBusiness.GetAll();
            foreach (var item in player)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.Id, item.Name, item.TeamId, item.NationalityId);
            }
        }
    }
}
