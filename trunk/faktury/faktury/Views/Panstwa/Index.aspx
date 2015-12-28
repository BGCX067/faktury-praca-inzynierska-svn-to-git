<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Kraje>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Państwa - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Państwa - lista</h2>

<table>
    <tr>
        <th>
            Nazwa
        </th>
        <th>
            Waluta
        </th>
        <th>
            Skrót
        </th>
        <th>
            Operacje
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nazwa) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Waluta) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.WalutaSkrot) %>
        </td>
        <td>
            <%: Html.ActionLink("Edytuj", "Edit", new { id = item.KrajID })%> |
            <%: Html.ActionLink("Szczegóły", "Details", new { id = item.KrajID })%> |
            <%: Html.ActionLink("Usuń", "Delete", new { id = item.KrajID })%>
        </td>
    </tr>
<% } %>

</table>

<p>
    <%: Html.ActionLink("Dodaj", "Create")%>
</p>

</asp:Content>
