<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Repozytoria.KodyPocztoweRepozytorium>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kody pocztowe - lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Kody pocztowe - lista</h2>
    <table>
        <tr>
            <th>
                Kod pocztowy
            </th>
            <th>
                Miejscowość
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.KodPocztowy.Kod) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.KodyPocztoweMiejscowosci.Nazwa) %>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.KodPocztowy.KodPocztowyID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.KodPocztowy.KodPocztowyID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.KodPocztowy.KodPocztowyID })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Dodaj", "Create")%>
    </p>
</asp:Content>
