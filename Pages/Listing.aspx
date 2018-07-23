<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Listing.aspx.cs" Inherits="GameStore.Listing" 
    MasterPageFile="~/Pages/Store.Master"%>
<%@ Import Namespace="System.Web.Routing" %>

<asp:Content ContentPlaceHolderID="bodyContent" runat="server">

        <div id ="content">
            <asp:Repeater ItemType="GameStore.Game" SelectMethod="GetGames" runat="server">
                <ItemTemplate>
                    <div class="item">
                        <h3><%# Item.Name %></h3>
                        <%# Item.Description %>
                        <table>
                            <tr>
                                <td class ="list"><h4><%# Item.Price.ToString("c") %></h4></td>
                                <td class ="list">
                                    <button name="add" type="submit" value="<%# Item.GameID %>">
                                        Добавить в корзину
                                    </button>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    <div class ="pager">
        <%
            for (int i = 1, n = MaxPage; i <= n; i++)
            {
                string path = RouteTable.Routes.GetVirtualPath(null, null,
                    new RouteValueDictionary() { { "category", CurrentCategory }, { "page", i } }).VirtualPath;

                Response.Write(String.Format("<a href='{0}' {1}>{2}</a>",
                       path, i == CurrentPage ? "class='selected'" : "", i));
            }%>
    </div>
</asp:Content>
