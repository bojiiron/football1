using Football.Data.Models;
using Football.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class PlayerTeamBusiness
    {
        private FootballContext playerTeamContext;
        public List<PlayerTeam> GetAll()
        {
            using (playerTeamContext = new FootballContext())
            {
                return playerTeamContext.PlayerTeams.ToList();
            }
        }

        public PlayerTeam Get(int id)
        {
            using (playerTeamContext = new FootballContext())
            {
                return playerTeamContext.PlayerTeams.Find(id);
            }

        }

        public void Add(PlayerTeam playerTeam)
        {
            using (playerTeamContext = new FootballContext())
            {
                playerTeamContext.PlayerTeams.Add(playerTeam);
                playerTeamContext.SaveChanges();
            }
        }

        public void Update(PlayerTeam playerTeam)
        {
            using (playerTeamContext = new FootballContext())
            {
                var item = playerTeamContext.PlayerTeams.Find(playerTeam.Id);
                if (item != null)
                {
                    playerTeamContext.Entry(item).CurrentValues.SetValues(playerTeam);
                    playerTeamContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (playerTeamContext = new FootballContext())
            {
                var coach = playerTeamContext.PlayerTeams.Find(id);
                if (coach != null)
                {
                    playerTeamContext.PlayerTeams.Remove(coach);
                    playerTeamContext.SaveChanges();
                }
            }

        }
    }
}
