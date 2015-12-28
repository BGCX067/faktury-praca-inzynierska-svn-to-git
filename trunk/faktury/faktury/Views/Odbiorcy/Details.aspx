<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.OdbiorcyRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Odbiorca - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Odbiorca - szczegóły</h2>

 <fieldset>
        <div class="display-label">
            <b>Nazwa: </b>
            <%: Html.DisplayFor(model => model.PelnaNazwaOdbiorcy) %></div>
        <div class="display-label">
            <b>Ulica: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.Ulica) %></div>
        <div class="display-label">
            <b>Nr domu: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.NrDomu) %></div>
        <div class="display-label">
            <b>Nr mieszkania: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.NrMieszkania) %></div>
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
            <%: Html.DisplayFor(model => model.Odbiorca.Nip) %></div>
        <div class="display-label">
            <b>E - mail: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.Email) %>
        </div>
        <div class="display-label">
            <b>Telefon: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.Telefon) %></div>
        <div class="display-label">
            <b>Telefon2: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.Telefon2) %></div>        
        <div class="display-label">
            <b>Uwagi: </b>
            <%: Html.DisplayFor(model => model.Odbiorca.Uwagi) %></div>
        <fieldset>
            <legend>Dane kontaktowe dostawcy</legend>
            <div class="display-label">
                <b>Imię: </b>
                <%: Html.DisplayFor(model => model.Odbiorca.ImieKontakt) %></div>
            <div class="display-label">
                <b>Nazwisko: </b>
                <%: Html.DisplayFor(model => model.Odbiorca.NazwiskoKontakt) %>
            </div>
            <div class="display-label">
                <b>Ulica: </b>
                <%: Html.DisplayFor(model => model.Odbiorca.UlicaKontakt) %>
            </div>
            <div class="display-label">
                <b>Nr domu: </b>
                <%: Html.DisplayFor(model => model.Odbiorca.NrDomuKontakt) %>
            </div>
            <div class="display-label">
                <b>Nr mieszkania: </b>
                <%: Html.DisplayFor(model => model.Odbiorca.NrMieszkaniaKontakt) %>
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
        <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.Odbiorca.KlientID })%>
        |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>

</asp:Content>
