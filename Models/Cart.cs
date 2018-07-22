using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameStore
{
    public class Cart
    {
        List<CartLine> lineColection = new List<CartLine>();

        public decimal TotalCost
        {
            get { return lineColection.Sum(l => l.Quantity * l.Game.Price); }
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineColection; }
        }

        public void AddItem(Game game, int quantity)
        {
            CartLine cartLine = lineColection.Where(l => l.Game.GameID == game.GameID).FirstOrDefault();

            if (cartLine == null)
            {
                lineColection.Add(new CartLine()
                {
                    Game = game,
                    Quantity = quantity
                });
            }
            else {
                cartLine.Quantity += quantity;
            }
        }
        public void RemoveItem(Game game, int quantity)
        {
            CartLine cartLine = lineColection.Where(l => l.Game.GameID == game.GameID).FirstOrDefault();

            if (cartLine != null)
            {
                cartLine.Quantity -= quantity;
                if (cartLine.Quantity <= 0) RemoveLine(game);
            }
        }
        public void RemoveLine(Game game) => lineColection.RemoveAll(l => l.Game.GameID == game.GameID);

        public void Clear() => lineColection.Clear();
        
    }
    public class CartLine
    {
        public Game Game { get; set; }
        public int Quantity { get; set; }
    }
}