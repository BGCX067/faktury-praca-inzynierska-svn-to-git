<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.StawkiVat>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Stawki Vat - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Stawki Vat - lista</h2>

<table>
    <tr>
        <th>
            Wartość
        </th>       
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Wartosc) %>
        </td>
        <td>
            <%: Html.ActionLink("Edytuj", "Edit", new { id = item.StawkaVatID })%> |
            <%: Html.ActionLink("Szczegóły", "Details", new { id = item.StawkaVatID })%> |
            <%: Html.ActionLink("Usuń", "Delete", new { id = item.StawkaVatID })%>
        </td>
    </tr>
<% } %>

</table>

<p>
    <%: Html.ActionLink("Dodaj", "Create")%>
</p>

</asp:Content>
