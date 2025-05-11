using Football.Business;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
    public class TeamDisplay
    {
        private int closeOperationId = 6;
        private teamBusiness teamBusiness = new teamBusiness();
        public int getOperation()
        { return closeOperationId; }
        public TeamDisplay()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Team" + new string(' ', 18));
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
            teamBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Team team = teamBusiness.Get(id);
            if (team != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + team.Id);
                Console.WriteLine("Name: " + team.Name);
                Console.WriteLine("League ID: " + team.LeagueId);
                Console.WriteLine("Coaches ID: " + team.CoachesId);
                Console.WriteLine("Trophies: " + team.Trophies);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Team team = teamBusiness.Get(id);
            if (team != null)
            {
                Console.WriteLine("Enter name: ");
                team.Name = Console.ReadLine();
                Console.WriteLine("Enter League ID: ");
                team.LeagueId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter CoachesID: ");
                team.CoachesId = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Trophies: ");
                team.Trophies = int.Parse(Console.ReadLine());
                teamBusiness.Update(team);
            }
            else
            {
                Console.WriteLine("Team not found!");
            }
        }

        private void Add()
        {
            Team team = new Team();
            Console.WriteLine("Enter ID: ");
            team.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            team.Name = Console.ReadLine();
            Console.WriteLine("Enter League ID: ");
            team.LeagueId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CoachesID: ");
            team.CoachesId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Trophies: ");
            team.Trophies = int.Parse(Console.ReadLine());
            teamBusiness.Update(team);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Team" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var team = teamBusiness.GetAll();
            foreach (var item in team)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", item.Id, item.Name, item.LeagueId, item.CoachesId, item.Trophies);
            }
        }
    }
}
