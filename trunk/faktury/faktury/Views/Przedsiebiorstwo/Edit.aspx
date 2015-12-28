<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.DanePrzedsiebiorstwa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dane przedsiębiorstwa - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Dane przedsiębiorstwa - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Edycja danych</legend>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nazwa: ")%></b>
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Imię: ")%></b>
            <%: Html.EditorFor(model => model.Imie) %>
            <%: Html.ValidationMessageFor(model => model.Imie) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nazwisko: ")%></b>
            <%: Html.EditorFor(model => model.Nazwisko) %>
            <%: Html.ValidationMessageFor(model => model.Nazwisko) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Ulica: ")%></b>
            <%: Html.EditorFor(model => model.Ulica) %>
            <%: Html.ValidationMessageFor(model => model.Ulica) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr domu: ")%></b>
            <%: Html.EditorFor(model => model.NrDomu) %>
            <%: Html.ValidationMessageFor(model => model.NrDomu) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr mieszkania: ")%></b>
            <%: Html.EditorFor(model => model.NrMieszkania) %>
            <%: Html.ValidationMessageFor(model => model.NrMieszkania) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Kod pocztowy: ") %></b>
            <%= Html.DropDownList("kodPocztowy", (SelectList)ViewData["KodPocztowy"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("NIP: ")%></b>
            <%: Html.EditorFor(model => model.Nip) %>
            <%: Html.ValidationMessageFor(model => model.Nip) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Regon ")%></b>
            <%: Html.EditorFor(model => model.Regon) %>
            <%: Html.ValidationMessageFor(model => model.Regon) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Uwagi: ")%></b>
            <%: Html.TextAreaFor(model => model.Uwagi) %>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
        </div>
        <fieldset>
            <legend>Kontakt</legend>
            <div class="editor-label">
                <b>
                    <%: Html.Label("WWW: ")%></b>
                <%: Html.EditorFor(model => model.Www) %>
                <%: Html.ValidationMessageFor(model => model.Www) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("E-mail: ")%></b>
                <%: Html.EditorFor(model => model.Email) %>
                <%: Html.ValidationMessageFor(model => model.Email) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Telefon: ")%></b>
                <%: Html.EditorFor(model => model.Telefon) %>
                <%: Html.ValidationMessageFor(model => model.Telefon) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Telefon 2: ")%></b>
                <%: Html.EditorFor(model => model.Telefon2) %>
                <%: Html.ValidationMessageFor(model => model.Telefon2) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Fax: ")%></b>
                <%: Html.EditorFor(model => model.Fax) %>
                <%: Html.ValidationMessageFor(model => model.Fax) %>
            </div>
        </fieldset>
        <fieldset>
            <legend>Adres korespondencyjny</legend>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr domu: ")%></b>
                <%: Html.EditorFor(model => model.NrDomuKontakt) %>
                <%: Html.ValidationMessageFor(model => model.NrDomuKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr mieszkania: ")%></b>
                <%: Html.EditorFor(model => model.NrMieszkaniaKontakt) %>
                <%: Html.ValidationMessageFor(model => model.NrMieszkaniaKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Kod pocztowy: ")%></b>
                <%: Html.EditorFor(model => model.KodPocztowyKontaktID) %>
                <%: Html.ValidationMessageFor(model => model.KodPocztowyKontaktID) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Kod pocztowy: ") %></b>
                <%= Html.DropDownList("kodPocztowyKontakt", (SelectList)ViewData["KodPocztowyKontakt"])%>
            </div>
        </fieldset>
        <p>
            <input type="submit" value="Zapisz" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </div>
</asp:Content>
