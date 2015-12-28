<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Repozytoria.MiejscowosciRepozytorium>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Miejscowości - Lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Miejscowości - Lista</h2>
    <table>
        <tr>
            <th>
                Nazwa
            </th>
            <th>
                Kraj
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Miejscowosc.Nazwa) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.MiejscowosciKraje.Nazwa)%>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.Miejscowosc.MiejscowoscID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.Miejscowosc.MiejscowoscID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.Miejscowosc.MiejscowoscID })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Dodaj", "Create")%>
    </p>
</asp:Content>
