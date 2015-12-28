<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.DokumentySprzedazy>>" %>

<%@ Import Namespace="System" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dokumenty sprzedaży - lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dokumenty sprzedaży - lista</h1>
    <p>
        <%: Html.ActionLink("Dodaj nowy", "Create") %>
    </p>
    <table>
        <tr>
            <th>
                <%: Html.ActionLink("Nr", "Index", new { sort = "NrDokumentu" }, new { @style = "color:white;" })%>
            </th>
            <th>
                Typ
            </th>
            <th>
                <%: Html.ActionLink("Klient", "Index", new { sort = "Klient" }, new { @style = "color:white;" })%>
            </th>
            <th>
                <%: Html.ActionLink("Data Wystawienia", "Index", new { sort = "DataWystawienia" }, new { @style = "color:white;" })%>
            </th>
            <th>
                <%: Html.ActionLink("Data Sprzedaży", "Index", new { sort = "DataSprzedazy" }, new { @style = "color:white;" })%>
            </th>
            <th>
                <%: Html.ActionLink("Termin Płatnosci", "Index", new { sort = "TerminPlatnosci" }, new { @style = "color:white;" })%>
            </th>
            <th>
                Wartość netto
            </th>
            <th>
                <%: Html.ActionLink("Wartość brutto", "Index", new { sort = "WartoscBrutto" }, new { @style = "color:white;" })%>
            </th>
            <th>
                <%: Html.ActionLink("Do zapłaty", "Index", new { sort = "DoZaplaty" }, new { @style = "color:white;" })%>
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.NrDokumentu) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TypDokumentu) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Klienci.Nazwa) %>
                <%: Html.DisplayFor(modelItem => item.Klienci.Imie) %>
                <%: Html.DisplayFor(modelItem => item.Klienci.Nazwisko) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.DataWystawienia.Year)%>-<%: Html.DisplayFor(modelItem => item.DataWystawienia.Month) %>-<%: Html.DisplayFor(modelItem => item.DataWystawienia.Day) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.DataSprzedazy.Year)%>-<%: Html.DisplayFor(modelItem => item.DataSprzedazy.Month) %>-<%: Html.DisplayFor(modelItem => item.DataSprzedazy.Day) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TerminPlatnosci.Year)%>-<%: Html.DisplayFor(modelItem => item.TerminPlatnosci.Month) %>-<%: Html.DisplayFor(modelItem => item.TerminPlatnosci.Day) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.WartoscNetto) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.WartoscBrutto) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.PozostaloDoZaplaty) %>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.DokumentSprzedazyID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.DokumentSprzedazyID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.DokumentSprzedazyID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
