<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.OdbiorcyRepozytorium>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Odbiorcy - lista
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Odbiorcy - lista</h2>

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

<% foreach (var item in Model) { %>
    <tr>
        <td>
                <%: Html.DisplayFor(modelItem => item.PelnaNazwaOdbiorcy) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Odbiorca.Nip) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Odbiorca.Telefon)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Odbiorca.Email)%>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.Odbiorca.KlientID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.Odbiorca.KlientID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.Odbiorca.KlientID })%>
            </td>
    </tr>
<% } %>

</table>
    <p>
        <%: Html.ActionLink("Dodaj", "Create")%>
    </p>
</asp:Content>
