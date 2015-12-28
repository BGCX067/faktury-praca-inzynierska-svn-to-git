<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<faktury.Models.Repozytoria.TowaryUslugiRepozytorium>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Towary i usługi - lista
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Towary i usługi - lista</h2>
    <table>
        <tr>
            <th>
                Nazwa
            </th>
            <th>
                Rodzaj
            </th>
            <th>
                Jm
            </th>
            <th>
                Marża
            </th>
            <th>
                Cena netto
            </th>
            <th>
                VAT
            </th>
            <th>
                Cena brutto
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowarUsluga.Nazwa) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowarUsluga.Rodzaj) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.JednostkaTowar.Nazwa)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowarUsluga.Marza)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowarUsluga.CenaNetto)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.VatTowar.Wartosc)%>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowarUsluga.CenaBrutto)%>
            </td>
            <td>
                <%: Html.ActionLink("Edytuj", "Edit", new { id = item.TowarUsluga.TowarID })%>
                |
                <%: Html.ActionLink("Szczegóły", "Details", new { id = item.TowarUsluga.TowarID })%>
                |
                <%: Html.ActionLink("Usuń", "Delete", new { id = item.TowarUsluga.TowarID })%>
            </td>
        </tr>
        <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Dodaj", "Create")%>
    </p>
</asp:Content>
