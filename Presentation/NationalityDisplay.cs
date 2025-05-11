using Football.Business;
using Football.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Presentation
{
    public class NationalityDisplay
    {
        private int closeOperationId = 6;
        private NationalityBusiness nationalityBusiness = new NationalityBusiness();
        public int getOperation()
        { return closeOperationId; }
        public NationalityDisplay()
        {
            Input();
        }

        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Nationality" + new string(' ', 18));
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
            nationalityBusiness.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Nationality nationality = nationalityBusiness.Get(id);
            if (nationality != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("ID: " + nationality.Id);
                Console.WriteLine("Name: " + nationality.Name);
                Console.WriteLine("Price: " + nationality.BestPlayer);
                Console.WriteLine(new string('-', 40));
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Nationality nationality = nationalityBusiness.Get(id);
            if (nationality != null)
            {
                Console.WriteLine("Enter name: ");
                nationality.Name = Console.ReadLine();
                Console.WriteLine("Enter Best player: ");
                nationality.BestPlayer =int.Parse(Console.ReadLine());
            
                nationalityBusiness.Update(nationality);
            }
            else
            {
                Console.WriteLine("Product not found!");
            }
        }

        private void Add()
        {
            Nationality nationality = new Nationality();
            Console.WriteLine("Enter ID: ");
            nationality.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter name: ");
            nationality.Name = Console.ReadLine();
            Console.WriteLine("Enter Best Player: ");
            nationality.BestPlayer= int.Parse(Console.ReadLine());
            
            nationalityBusiness.Add(nationality);
        }

        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 16) + "Nationality" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            var nationality = nationalityBusiness.GetAll();
            foreach (var item in nationality)
            {
                Console.WriteLine("{0} {1} {2}", item.Id, item.Name, item.BestPlayer);
            }
        }
    }
}
