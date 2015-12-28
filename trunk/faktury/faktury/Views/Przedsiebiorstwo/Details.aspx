<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.PrzedsiebiorstwoRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dane przedsiębiorstwa - szczegóły
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dane przedsiębiorstwa - szczegóły</h1>
    <fieldset>
        <legend>Przedsiębiorca</legend>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nazwa: ")%></b>
            <%: Html.DisplayFor(model => model.PelnaNazwaPrzedsiebiorstwa) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Ulica: ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Ulica) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr domu: ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.NrDomu)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr mieszkania: ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.NrMieszkania)%>
        </div>
         <div class="editor-label">
            <b>
                <%: Html.Label("Kod pocztowy: ")%></b>
            <%: Html.DisplayFor(model => model.KodPocztowy)%>
        </div>
         <div class="editor-label">
            <b>
                <%: Html.Label("Miejscowość: ")%></b>
            <%: Html.DisplayFor(model => model.Miejscowosc)%>
        </div>
         <div class="editor-label">
            <b>
                <%: Html.Label("Państwo: ")%></b>
            <%: Html.DisplayFor(model => model.Panstwo)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("NIP: ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Nip)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Regon ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Regon)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Uwagi: ")%></b>
            <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Uwagi)%>
        </div>
        <fieldset>
            <legend>Kontakt</legend>
            <div class="editor-label">
                <b>
                    <%: Html.Label("WWW: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Www)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("E-mail: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Email)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Telefon: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Telefon)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Telefon 2: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Telefon2)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Fax: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.Fax)%>
            </div>
        </fieldset>
        <fieldset>
            <legend>Adres korespondencyjny</legend>
             <div class="editor-label">
                <b>
                    <%: Html.Label("Ulica: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.UlicaKontakt)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr domu: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.NrDomuKontakt)%>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr mieszkania: ")%></b>
                <%: Html.DisplayFor(model => model.Przedsiebiorstwo.NrMieszkaniaKontakt)%>
            </div>
          <div class="editor-label">
            <b>
                <%: Html.Label("Kod pocztowy: ")%></b>
            <%: Html.DisplayFor(model => model.KodPocztowyKontakt)%>
        </div>
         <div class="editor-label">
            <b>
                <%: Html.Label("Miejscowość: ")%></b>
            <%: Html.DisplayFor(model => model.MiejscowoscKontakt)%>
        </div>
        </fieldset>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.Przedsiebiorstwo.DanePrzedsiebiorstwaID })%>
         |
        <%: Html.ActionLink("Powrót", "Index")%>
    </p>
</asp:Content>

