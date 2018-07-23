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