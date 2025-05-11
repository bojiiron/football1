using Football.Business;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
    public class PlayerTeamDisplay
    {
        private int closeOperationId = 6;
        private PlayerTeamBusiness playerTeamBusiness = new PlayerTeamBusiness();
        public int getOperation()
        { return closeOperationId; }
        public PlayerTeamDisplay()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "PlayerTeam" + new string(' ', 18));
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
            playerTeamBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            PlayerTeam playerTeam = playerTeamBusiness.Get(id);
            if (playerTeam != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + playerTeam.Id);
                Console.WriteLine("Player ID: " + playerTeam.PlayersId);
                Console.WriteLine("Team ID: " + playerTeam.TeamId);
                Console.WriteLine("Salary: " + playerTeam.Salary);
                Console.WriteLine("MonthsActive: " + playerTeam.MonthsActive);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            PlayerTeam playerTeam = playerTeamBusiness.Get(id);
            if (playerTeam != null)
            {
                PlayerTeam PlayerTeam = new PlayerTeam();
                Console.WriteLine("Enter Players ID: ");
                playerTeam.PlayersId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Team ID: ");
                playerTeam.TeamId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Salary: ");
                playerTeam.Salary = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Months active: ");
                playerTeam.MonthsActive = int.Parse(Console.ReadLine());
                playerTeamBusiness.Update(playerTeam);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            PlayerTeam playerTeam = new PlayerTeam();
            Console.WriteLine("Enter ID: ");
            playerTeam.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Players ID: ");
            playerTeam.PlayersId =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter Team ID: ");
            playerTeam.TeamId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Salary: ");
            playerTeam.Salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Months active: ");
            playerTeam.MonthsActive = int.Parse(Console.ReadLine());
            playerTeamBusiness.Add(playerTeam);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "PlayerTeam" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var playerTeam = playerTeamBusiness.GetAll();
            foreach (var item in playerTeam)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.PlayersId, item.TeamId, item.Salary, item.MonthsActive);
            }
        }
    }
}
