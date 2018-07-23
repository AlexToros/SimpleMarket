<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="GameStore.Pages.CartView" 
    MasterPageFile="~/Pages/Store.Master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <h2>Ваша корзина</h2>
        <table id ="cartTable">
            <thead>
                <tr>
                    <th>Количество</th>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="GameStore.CartLine" 
                    SelectMethod="GetCartLines" EnableViewState="false" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity%></td>
                            <td><%# Item.Game.Name%></td>
                            <td><%# Item.Game.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity*Item.Game.Price).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name ="remove"
                                    value="<%# Item.Game.GameID %>">
                                    Удалить
                                </button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3"> ИТОГО:</td>
                    <td><%= CartTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%= ReturnUrl %>">Продолжить покупки</a>
        </p>
    </div>
</asp:Content>