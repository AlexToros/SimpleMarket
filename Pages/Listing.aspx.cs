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
        protected IEnumerable<Game> GetGames()
        {
            return rep.Games;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}