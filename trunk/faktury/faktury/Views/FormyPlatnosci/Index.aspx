<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.FormyPlatnosci>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Formy płatności - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Formy płatności - lista</h2>

<table>
    <tr>
        <th>
            Nazwa
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Nazwa) %>
        </td>
       
        <td>
            <%: Html.ActionLink("Edytuj", "Edit", new { id = item.FormaPlatnosciID })%> |
            <%: Html.ActionLink("Szczegóły", "Details", new { id = item.FormaPlatnosciID })%> |
            <%: Html.ActionLink("Usuń", "Delete", new { id = item.FormaPlatnosciID })%>
        </td>
    </tr>
<% } %>

</table>
<p>
    <%: Html.ActionLink("Dodaj", "Create")%>
</p>

</asp:Content>
