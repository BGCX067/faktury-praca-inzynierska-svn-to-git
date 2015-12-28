<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Repozytoria.DostawcyRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dostawcy - szczegóły
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Dostawcy - szczegóły</h2>
    <fieldset>
        <div class="display-label">
            <b>Nazwa: </b>
            <%: Html.DisplayFor(model => model.PelnaNazwaDostawcy) %></div>
        <div class="display-label">
            <b>Ulica: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Ulica) %></div>
        <div class="display-label">
            <b>Nr domu: </b>
            <%: Html.DisplayFor(model => model.Dostawca.NrDomu) %></div>
        <div class="display-label">
            <b>Nr mieszkania: </b>
            <%: Html.DisplayFor(model => model.Dostawca.NrMieszkania) %></div>
        <div class="display-label">
            <b>Kod pocztowy: </b>
            <%: Html.DisplayFor(model => model.KodPocztowy) %></div>
        <div class="display-label">
            <b>Miejscowość: </b>
            <%: Html.DisplayFor(model => model.Miejscowosc) %></div>
        <div class="display-label">
            <b>Państwo: </b>
            <%: Html.DisplayFor(model => model.Panstwo) %>
        </div>
        <div class="display-label">
            <b>NIP: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Nip) %></div>
        <div class="display-label">
            <b>E - mail: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Email) %>
        </div>
        <div class="display-label">
            <b>Telefon: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Telefon) %></div>
        <div class="display-label">
            <b>Telefon2: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Telefon2) %></div>
        <div class="display-label">
            <b>Bank: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Bank) %></div>
        <div class="display-label">
            <b>Nr banku: </b>
            <%: Html.DisplayFor(model => model.Dostawca.NrBanku) %></div>
        <div class="display-label">
            <b>Uwagi: </b>
            <%: Html.DisplayFor(model => model.Dostawca.Uwagi) %></div>
        <fieldset>
            <legend>Dane kontaktowe dostawcy</legend>
            <div class="display-label">
                <b>Imię: </b>
                <%: Html.DisplayFor(model => model.Dostawca.ImieKontakt) %></div>
            <div class="display-label">
                <b>Nazwisko: </b>
                <%: Html.DisplayFor(model => model.Dostawca.NazwiskoKontakt) %>
            </div>
            <div class="display-label">
                <b>Ulica: </b>
                <%: Html.DisplayFor(model => model.Dostawca.UlicaKontakt) %>
            </div>
            <div class="display-label">
                <b>Nr domu: </b>
                <%: Html.DisplayFor(model => model.Dostawca.NrDomuKontakt) %>
            </div>
            <div class="display-label">
                <b>Nr mieszkania: </b>
                <%: Html.DisplayFor(model => model.Dostawca.NrMieszkaniaKontakt) %>
            </div>
            <div class="display-label">
                <b>Kod pocztowy: </b>
                <%: Html.DisplayFor(model => model.KodPocztowyKontakt) %>
            </div>
            <div class="display-label">
                <b>Miejscowość: </b>
                <%: Html.DisplayFor(model => model.MiejscowoscKontakt) %>
            </div>
        </fieldset>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.Dostawca.DostawcaID })%>
        |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
</asp:Content>
