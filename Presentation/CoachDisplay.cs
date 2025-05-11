using Football.Business;
using Football.Data;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
     public class CoachDisplay
    {
        private int closeOperationId = 6;
        private couchBusiness coachBusiness = new couchBusiness();

        public CoachDisplay()
        {
            Input();
        }

        public int getOperation()
        { return closeOperationId; }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Coaches" + new string(' ', 18));
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
            coachBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Coach coach = coachBusiness.Get(id);
            if (coach != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + coach.Id);
                Console.WriteLine("Name: " + coach.Name);
            //    Console.WriteLine("Teams: " + coach.Teams);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Coach coach = coachBusiness.Get(id);
            if (coach != null)
            {
                Console.WriteLine("Enter name: ");
                coach.Name = Console.ReadLine();

               coachBusiness.Update(coach);
            }
            else
            {
                Console.WriteLine("Coach not found!");
            }
        }

        private void Add()
        {
            Coach coach = new Coach();
            Console.WriteLine("Enter ID: ");
            coach.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            coach.Name = Console.ReadLine();
            coachBusiness.Add(coach);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Coaches" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var coach = coachBusiness.GetAll();
            foreach (var item in coach)
            {
                Console.WriteLine("{0} {1}", item.Id, item.Name);
            }
        }

    }
}
