using Football.Business;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
    public class LeagueDisplay
    {
        private int closeOperationId = 6;
        private LeagueBusiness leagueBusiness = new LeagueBusiness();
        public int getOperation()
        { return closeOperationId; }
        public LeagueDisplay()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "League" + new string(' ', 18));
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
                        Update(leagueBusiness);
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
            leagueBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            League league = leagueBusiness.Get(id);
            if (league != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + league.Id);
                Console.WriteLine("Name: " + league.Name);
              
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update(LeagueBusiness leagueBusiness)
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            League league = leagueBusiness.Get(id);
            if (league != null)
            {
                Console.WriteLine("Enter name: ");
                league.Name = Console.ReadLine();
               
                leagueBusiness.Update(league);
            }
            else
            {
                Console.WriteLine("League not found!");
            }
        }

        private void Add()
        {
            League league = new League();
            Console.WriteLine("Enter ID: ");
            league.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            league.Name = Console.ReadLine();
           
            leagueBusiness.Add(league);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "League" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var LeagueDisplay = leagueBusiness.GetAll();
            foreach (var item in LeagueDisplay)
            {
                Console.WriteLine("{0} {1}", item.Id, item.Name);
            }
        }
    }
}
