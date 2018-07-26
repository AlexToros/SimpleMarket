using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        private Repository rep = new Repository();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int dispatchID;
                if (int.TryParse(Request.Form["dispatch"], out dispatchID))
                {
                    Order myOrder = rep.Orders.Where(o => o.OrderId == dispatchID).FirstOrDefault();
                    if (myOrder != null)
                    {
                        myOrder.Dispatched = true;
                        rep.SaveOrder(myOrder);
                    }
                }
            }
        }

        public IEnumerable<Order> GetOrders([Control] bool showDispatched)
        {
            if (showDispatched)
                return rep.Orders;
            else
                return rep.Orders.Where(o => !o.Dispatched);
        }

        public decimal Total(Order Item)
        {
            return Item.OrderLines.Sum(o => o.Quantity * o.Game.Price) + Item.WrapCost;
        }
    }
}