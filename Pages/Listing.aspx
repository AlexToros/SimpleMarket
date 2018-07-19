<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GameStore.Listing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Game-Store</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
    </form>
    <div>
        <%
            for (int i = 1, n = MaxPage; i <= n; i++)
            {
                Response.Write(String.Format("<a href='/Pages/Listing.aspx?page={0}' {1}>{2}</a>  ",
                       i, i == CurrentPage ? "class='selected'" : "", i));
            }%>
    </div>
</body>
</html>
