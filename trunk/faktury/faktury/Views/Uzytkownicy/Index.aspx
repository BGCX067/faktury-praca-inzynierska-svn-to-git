<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Uzytkownicy>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Użytkownicy - lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Użytkownicy - lista</h2>
    <table>
        <tr>
            <th>
                Imię
            </th>
            <th>
                Nazwisko
            </th>
            <th>
                Login
            </th>
            <th>
                E-mail
            </th>
            <th>
            Uprawnienia
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.Imie) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Nazwisko) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Login) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Email) %>
            </td>
              <td>
                <%: Html.DisplayFor(modelItem => item.Role.Nazwa) %>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.UzytkownikID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.UzytkownikID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.UzytkownikID })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Dodaj", "Register", "Account")%>
    </p>
</asp:Content>
