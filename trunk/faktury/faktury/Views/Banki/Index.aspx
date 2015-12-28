<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Banki>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rachunki bankowe - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Rachunki bankowe - lista</h2>

<table>
    <tr>
        <th>
            Nazwa
        </th>
        <th>
            Nr rachunku
        </th>
        <th>
            Uwagi
        </th>        
    <%--    <th></th>--%>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nazwa) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.NrBanku) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Uwagi) %>
        </td>
        <td>
            <%: Html.ActionLink("Edytuj", "Edit", new { id = item.BankID })%> |
            <%: Html.ActionLink("Szczegóły", "Details", new { id = item.BankID })%> |
            <%: Html.ActionLink("Usuń", "Delete", new { id = item.BankID })%>
        </td>
    </tr>
<% } %>

</table>
<p>
    <%: Html.ActionLink("Dodaj", "Create") %>
</p>

</asp:Content>
