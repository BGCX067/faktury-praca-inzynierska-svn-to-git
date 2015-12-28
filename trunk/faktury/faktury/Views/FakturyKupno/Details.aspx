<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaKupna>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dokument kupna - szczegóły
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dokument kupna - szczegóły</h1>
    <fieldset>
        <legend>Szczegóły dotyczące faktury</legend>
        <div class="display-label">
            <b>Nr dokumentu: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.NrDokumentu) %></div>
        <div class="display-label">
            <b>Odbiorca: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.Dostawcy.Nazwa)%>
            <%: Html.DisplayFor(model => model.dokumentKupna.Dostawcy.Imie)%>
            <%: Html.DisplayFor(model => model.dokumentKupna.Dostawcy.Nazwisko)%>
        </div>
        <div class="display-label">
            <b>Data wystawienia: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.DataWystawienia)%></div>
        <div class="display-label">
            <b>Data sprzedaży: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.DataSprzedazy)%></div>
        <div class="display-label">
            <b>Wartość netto: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.WartoscNetto)%></div>
        <div class="display-label">
            <b>Wartość brutto: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.WartoscBrutto)%></div>
        <div class="display-label">
            <b>Forma płatności: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.FormyPlatnosci.Nazwa)%></div>
        <div class="display-label">
            <b>Termin płatności: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.TerminPlatnosci)%></div>
        <div class="display-label">
            <b>Pozostało do zapłaty: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.PozostaloDoZaplaty)%></div>
        <div class="display-label">
            <b>Uwagi: </b>
            <%: Html.DisplayFor(model => model.dokumentKupna.Uwagi)%></div>
        <fieldset>
            <legend>Produkty faktury</legend>
            <table>
                <tr>
                    <th>
                        Nazwa
                    </th>
                    <th>
                        Ilość
                    </th>
                    <th>
                        Cena netto
                    </th>
                    <th>
                        Stawka VAT
                    </th>
                    <th>
                        Cena brutto
                    </th>
                </tr>
                <% foreach (var item in Model.ListaProduktowKupna)
                   { %>
                <tr>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.TowaryUslugi.Nazwa) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Ilosc) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.WartoscNetto) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.TowaryUslugi.StawkiVat.Wartosc) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.WartoscBrutto) %>
                    </td>
                </tr>
                <% } %>
            </table>
            <p>
                <%: Html.ActionLink("Edytuj listę produktów", "EditListaProduktowKupna", new { id = Model.dokumentKupna.DokumentKupnaID })%>
            </p>
        </fieldset>
        <fieldset>
            <legend>Rozliczenie faktury</legend>
            <table>
                <tr>
                    <th>
                        Data zapłaty
                    </th>
                    <th>
                        Kwota
                    </th>
                </tr>
                <% foreach (var item in Model.ListaRozliczeniaKupna)
                   { %>
                <tr>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.DataZaplaty) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Kwota) %>
                    </td>
                </tr>
                <% } %>
            </table>
            <p>
                <%: Html.ActionLink("Edytuj listę", "EdytujRozliczeniaFakturyKupna", new { id =  Model.dokumentKupna.DokumentKupnaID })%>
            </p>
        </fieldset>
    </fieldset>
    <p>
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
</asp:Content>
