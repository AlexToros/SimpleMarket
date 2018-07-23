using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages
{
    public partial class CartView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Repository rep = new Repository();
                int gameId;
                if (int.TryParse(Request.Form["remove"], out gameId))
                {
                    Game gameToRemove = rep.Games.FirstOrDefault(g => g.GameID == gameId);
                    if (gameToRemove != null)
                        SessionHelper.GetCart(Session).RemoveLine(gameToRemove);
                }
            }
        }
        public IEnumerable<CartLine> GetCartLines()
        {
            return SessionHelper.GetCart(Session).Lines;
        }
        public decimal CartTotal
        {
            get { return SessionHelper.GetCart(Session).TotalCost; }
        }
        public string ReturnUrl
        {
            get { return SessionHelper.Get<string>(Session, SessionKey.RETURN_URL); }
        }
    }
}