<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Repozytoria.DostawcyRepozytorium>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dostawcy - lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Dostawcy - lista</h2>
    <table>
        <tr>
            <th>
                Nazwa
            </th>
            <th>
                NIP
            </th>
            <th>
                Telefon
            </th>
            <th>
                E-mail
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.PelnaNazwaDostawcy) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Dostawca.Nip) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Dostawca.Telefon) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Dostawca.Email) %>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.Dostawca.DostawcaID})%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.Dostawca.DostawcaID})%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.Dostawca.DostawcaID})%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Dodaj", "Create")%>
    </p>
</asp:Content>
