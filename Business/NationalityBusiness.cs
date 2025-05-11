using Football.Data;
using Football.Data.Models;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class NationalityBusiness
    {
        private FootballContext nationalityContext;

        public List<Nationality> GetAll()
        {
            using (nationalityContext = new FootballContext())
            {
                return nationalityContext.Nationalities.ToList();
            }
        }

        public Nationality Get(int id)
        {
            using (nationalityContext = new FootballContext())
            {
                return nationalityContext.Nationalities.Find(id);
            }

        }

        public void Add(Nationality nationality)
        {
            using (nationalityContext = new FootballContext())
            {
                nationalityContext.Nationalities.Add(nationality);
                nationalityContext.SaveChanges();
            }
        }

        public void Update(Nationality nationality)
        {
            using (nationalityContext = new FootballContext())
            {
                var item = nationalityContext.Nationalities.Find(nationality.Id);
                if (item != null)
                {
                    nationalityContext.Entry(item).CurrentValues.SetValues(nationality);
                    nationalityContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (nationalityContext = new FootballContext())
            {
                var nationality = nationalityContext.Nationalities.Find(id);
                if (nationality != null)
                {
                    nationalityContext.Nationalities.Remove(nationality);
                    nationalityContext.SaveChanges();
                }
            }

        }

    }
}
