<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.JednostkiMiar>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Jednostki miar - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Jednostki miar - lista</h2>

<table>
    <tr>
        <th>
            Nazwa
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
            <%: Html.ActionLink("Edytuj", "Edit", new { id = item.JednostkaMiarID })%> |
            <%: Html.ActionLink("Szczegóły", "Details", new { id = item.JednostkaMiarID })%> |
            <%: Html.ActionLink("Usuń", "Delete", new { id = item.JednostkaMiarID })%>
        </td>
    </tr>
<% } %>

</table>
<p>
    <%: Html.ActionLink("Dodaj", "Create")%>
</p>
</asp:Content>
