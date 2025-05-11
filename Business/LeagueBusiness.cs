using Football.Data;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class LeagueBusiness
    {
        private FootballContext leagueContext;


        public List<League> GetAll()
        {
            using (leagueContext = new FootballContext())
            {
                return leagueContext.Leagues.ToList();
            }
        }

        public League Get(int id)
        {
            using (leagueContext = new FootballContext())
            {
                return leagueContext.Leagues.Find(id);
            }

        }

        public void Add(League league)
        {
            using (leagueContext = new FootballContext())
            {
                leagueContext.Leagues.Add(league);
                leagueContext.SaveChanges();
            }
        }

        public void Update(League league)
        {
            using (leagueContext = new FootballContext())
            {
                var item = leagueContext.Leagues.Find(league.Id);
                if (item != null)
                {
                    leagueContext.Entry(item).CurrentValues.SetValues(league);
                    leagueContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (leagueContext = new FootballContext())
            {
                var league = leagueContext.Leagues.Find(id);
                if (league != null)
                {
                    leagueContext.Leagues.Remove(league);
                    leagueContext.SaveChanges();
                }
            }

        }
    }
}
