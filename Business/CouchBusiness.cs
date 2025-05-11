using Football.Data.Models;
using Football.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class couchBusiness
    {
        private FootballContext coachContext;
        public List<Coach> GetAll()
        {
            using (coachContext = new FootballContext())
            {
                return coachContext.Coaches.ToList();
            }
        }

        public Coach Get(int id)
        {
            using (coachContext = new FootballContext())
            {
                return coachContext.Coaches.Find(id);
            }

        }

        public void Add(Coach coach)
        {
            using (coachContext = new FootballContext())
            {
                coachContext.Coaches.Add(coach);
                coachContext.SaveChanges();
            }
        }

        public void Update(Coach coach)
        {
            using (coachContext = new FootballContext())
            {
                var item = coachContext.Coaches.Find(coach.Id);
                if (item != null)
                {
                    coachContext.Entry(item).CurrentValues.SetValues(coach);
                    coachContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (coachContext = new FootballContext())
            {
                var coach = coachContext.Coaches.Find(id);
                if (coach != null)
                {
                    coachContext.Coaches.Remove(coach);
                    coachContext.SaveChanges();
                }
            }

        }
    }
}
