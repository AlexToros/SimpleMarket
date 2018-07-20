<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GameStore.Listing" 
    MasterPageFile="~/Pages/Store.Master"%>
<asp:Content ContentPlaceHolderID="bodyContent" runat="server">

        <div id ="content">
            <%
                foreach (GameStore.Game game in GetGames())
                {
                    Response.Write(String.Format(@"
                        <div class='item'>
                            <h3>{0}</h3>
                            {1}
                            <h4>{2:c}</h4>
                        </div>",
                        game.Name, game.Description, game.Price));
                }
                %>
        </div>

    <div class ="pager">
        <%
            for (int i = 1, n = MaxPage; i <= n; i++)
            {
                Response.Write(String.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>  ",
                       i, i == CurrentPage ? "class='selected'" : "", i));
            }%>
    </div>
</asp:Content>
