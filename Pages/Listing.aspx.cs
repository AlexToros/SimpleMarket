using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GameStore
{
    public partial class Listing : System.Web.UI.Page
    {
        Repository rep = new Repository();

        private int pageSize = 4;

        protected int CurrentPage
        {
            get {
                int page;
                return int.TryParse(Request.QueryString["page"], out page) ? page : 1;
            }
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