using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore
{
    public partial class Listing : Page
    {
        Repository rep = new Repository();

        private int pageSize = 4;

        protected int CurrentPage
        {
            get {
                int page;
                page = GetPageFrowRequest();
                if (page <= 0) return 1;
                if (page > MaxPage) return MaxPage;
                return page;
            }
        }

        private int GetPageFrowRequest()
        {
            int page;
            string reqValue = (string)RouteData.Values["page"] ?? Request.QueryString["page"];
            return reqValue != null && int.TryParse(reqValue, out page) ? page : 1;
        }

        protected int MaxPage
        {
            get { return (int)Math.Ceiling((decimal)rep.Games.Count() / pageSize); }
        }

        protected IEnumerable<Game> GetGames()
        {
            return rep.Games
                .OrderBy(g => g.GameID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}