<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaSprzedazy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dokument sprzedaży - szczegóły
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dokument sprzedaży - szczegóły</h1>
    <fieldset>
        <legend>Szczegóły dotyczące faktury</legend>
        <div class="display-label">
            <b>Typ dokumentu: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.TypDokumentu) %></div>
        <div class="display-label">
            <b>Nr dokumentu: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.NrDokumentu) %></div>
        <div class="display-label">
            <b>Odbiorca: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Klienci.Nazwa)%>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Klienci.Imie)%>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Klienci.Nazwisko)%>
        </div>
        <div class="display-label">
            <b>Data wystawienia: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.DataWystawienia) %></div>
        <div class="display-label">
            <b>Data sprzedaży: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.DataSprzedazy) %></div>
        <div class="display-label">
            <b>Wartość netto: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.WartoscNetto)%>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Kraje.WalutaSkrot)%></div>
        <div class="display-label">
            <b>Wartość brutto: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.WartoscBrutto)%>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Kraje.WalutaSkrot)%></div>
        <div class="display-label">
            <b>Forma płatności: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.FormyPlatnosci.Nazwa) %></div>
        <div class="display-label">
            <b>Bank: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Banki.Nazwa) %>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Banki.NrBanku) %></div>
        <div class="display-label">
            <b>Termin płatności: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.TerminPlatnosci) %></div>
        <div class="display-label">
            <b>Miejsce wystawienia faktury: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Miejscowosci.Nazwa) %></div>
        <div class="display-label">
            <b>Pozostało do zapłaty: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.PozostaloDoZaplaty) %></div>
        <div class="display-label">
            <b>Uwagi: </b>
            <%: Html.DisplayFor(model => model.dokumentSprzedazy.Uwagi) %></div>
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
                <% foreach (var item in Model.ListaProduktowSprzedazy)
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
                <%: Html.ActionLink("Edytuj listę produktów", "EditListaProduktowSprzedazy", new { id = Model.dokumentSprzedazy.DokumentSprzedazyID })%>
            </p>
        </fieldset>
        <fieldset>
            <legend>Rozliczenie faktury</legend>
            <table>
                <tr>
                    <th>
                        Data wpłaty
                    </th>
                    <th>
                        Kwota
                    </th>
                </tr>
                <% foreach (var item in Model.ListaRozliczeniaSprzedazy)
                   { %>
                <tr>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.DataWplaty) %>
                    </td>
                    <td>
                        <%: Html.DisplayFor(modelItem => item.Kwota) %>
                    </td>
                </tr>
                <% } %>
            </table>
            <p>
                <%: Html.ActionLink("Edytuj listę", "EdytujRozliczeniaFakturySprzedazy", new { id =  Model.dokumentSprzedazy.DokumentSprzedazyID })%>
            </p>
        </fieldset>
    </fieldset>
    <p>
        <%: Html.ActionLink("Utwórz PDF", "CreatePDF", new { id =  Model.dokumentSprzedazy.DokumentSprzedazyID })%>
        <%-- |
        <%: Html.ActionLink("Wystaw korektę", "Korekta", new { id =  Model.dokumentSprzedazy.DokumentSprzedazyID })%>--%>
<%--        |
        <%: Html.ActionLink("Powiadomienie", "Powiadomienie", new { id =  Model.dokumentSprzedazy.DokumentSprzedazyID })%>--%>
        |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
</asp:Content>
