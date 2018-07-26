using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Game> Games
        {
            get { return context.Games; }
        }
        public IEnumerable<Order> Orders
        {
            get { return context.Orders.Include(o=>o.OrderLines.Select(ol => ol.Game)); }
        }
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Game).State = System.Data.Entity.EntityState.Modified;
                }
            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                    dbOrder.City = order.City;
                }
            }
            context.SaveChanges();
        }

        public void SaveGame(Game game)
        {
            if (game.GameID == 0)
                game = context.Games.Add(game);
            else {
                Game dbGame = context.Games.Find(game.GameID);
                if (dbGame != null)
                {
                    dbGame.Name = game.Name;
                    dbGame.Price = game.Price;
                    dbGame.Description = game.Description;
                    dbGame.Category = game.Category;
                }
            }
            context.SaveChanges();
        }
        public void DeleteGame(Game game)
        {
            IEnumerable<Order> orderLines = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Game))
                .Where(o => o.OrderLines.Count(ol => ol.Game.GameID == game.GameID) > 0);

            foreach (Order order in orderLines)
            {
                context.Orders.Remove(order);
            }
            context.Games.Remove(game);
            context.SaveChanges();
        }
    }
}