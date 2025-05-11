using Football.Data.Models;
using Football.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Business
{
    public class PlayerBusiness
    {
        private FootballContext playerContext;
        public List<Player> GetAll()
        {
            using (playerContext = new FootballContext())
            {
                return playerContext.Players.ToList();
            }
        }

        public Player Get(int id)
        {
            using (playerContext = new FootballContext())
            {
                return playerContext.Players.Find(id);
            }

        }

        public void Add(Player player)
        {
            using (playerContext = new FootballContext())
            {
                playerContext.Players.Add(player);
                playerContext.SaveChanges();
            }
        }

        public void Update(Player player)
        {
            using (playerContext = new FootballContext())
            {
                var item = playerContext.Teams.Find(player.Id);
                if (item != null)
                {
                    playerContext.Entry(item).CurrentValues.SetValues(player);
                    playerContext.SaveChanges();
                }
            }

        }

        public void Delete(int id)
        {
            using (playerContext = new FootballContext())
            {
                var player = playerContext.Players.Find(id);
                if (player != null)
                {
                    playerContext.Players.Remove(player);
                    playerContext.SaveChanges();
                }
            }

        }
    }
}
