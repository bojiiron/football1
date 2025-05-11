using Football.Data;
using Football.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class teamBusiness
    {
        private FootballContext teamContext;
        public List<Team> GetAll()
        {
            using (teamContext = new FootballContext())
            {
                return teamContext.Teams.ToList();
            }
        }

        public Team Get(int id)
        {
            using (teamContext = new FootballContext())
            {
                return teamContext.Teams.Find(id);
            }

        }

        public void Add(Team team)
        {
            using (teamContext = new FootballContext())
            {
                teamContext.Teams.Add(team);
                teamContext.SaveChanges();
            }
        }

        public void Update(Team team)
        {
            using (teamContext = new FootballContext())
            {
                var item = teamContext.Teams.Find(team.Id);
                if (item != null)
                {
                    teamContext.Entry(item).CurrentValues.SetValues(team);
                    teamContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (teamContext = new FootballContext())
            {
                var team = teamContext.Teams.Find(id);
                if (team != null)
                {
                    teamContext.Teams.Remove(team);
                    teamContext.SaveChanges();
                }
            }

        }
    }
}
