﻿using System;
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

        private int pageSize = 3;

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
        protected string CurrentCategory
        {
            get {
                return (string)RouteData.Values["category"] ?? Request.QueryString["category"];
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
            get { return (int)Math.Ceiling((decimal)FilterGames().Count() / pageSize); }
        }

        protected IEnumerable<Game> GetGames()
        {
            return FilterGames()
                .OrderBy(g => g.GameID)
                .Skip((CurrentPage - 1) * pageSize)
                .Take(pageSize);
        }

        private IEnumerable<Game> FilterGames()
        {
            IEnumerable<Game> games = rep.Games;
            return CurrentCategory == null ? games : games.Where(g => g.Category.Equals(CurrentCategory));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}