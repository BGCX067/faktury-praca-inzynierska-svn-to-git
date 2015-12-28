<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Dostawcy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dostawcy - nowy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Dostawcy - nowy</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Dostawca</legend>
        <div class="editor-label">
            <b>
                <%: Html.Label("Imię: ") %></b>
            <%: Html.EditorFor(model => model.Imie) %>
            <%: Html.ValidationMessageFor(model => model.Imie) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nazwisko: ") %></b>
            <%: Html.EditorFor(model => model.Nazwisko) %>
            <%: Html.ValidationMessageFor(model => model.Nazwisko) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nazwa: ") %></b>
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Ulica: ") %></b>
            <%: Html.EditorFor(model => model.Ulica) %>
            <%: Html.ValidationMessageFor(model => model.Ulica) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr domu: ") %></b>
            <%: Html.EditorFor(model => model.NrDomu) %>
            <%: Html.ValidationMessageFor(model => model.NrDomu) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr mieszkania: ") %></b>
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
                <%: Html.Label("NIP: ") %></b>
            <%: Html.EditorFor(model => model.Nip) %>
            <%: Html.ValidationMessageFor(model => model.Nip) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("E - mail: ") %></b>
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Telefon: ") %></b>
            <%: Html.EditorFor(model => model.Telefon) %>
            <%: Html.ValidationMessageFor(model => model.Telefon) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Telefon2: ") %></b>
            <%: Html.EditorFor(model => model.Telefon2) %>
            <%: Html.ValidationMessageFor(model => model.Telefon2) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Bank: ") %></b>
            <%: Html.EditorFor(model => model.Bank) %>
            <%: Html.ValidationMessageFor(model => model.Bank) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr banku: ") %></b>
            <%: Html.EditorFor(model => model.NrBanku) %>
            <%: Html.ValidationMessageFor(model => model.NrBanku) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.LabelFor(model => model.Uwagi) %></b>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Uwagi)%>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
        </div>
        <fieldset>
            <legend>Dane kontaktowe dostawcy</legend>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Imię: ") %></b>
                <%: Html.EditorFor(model => model.ImieKontakt) %>
                <%: Html.ValidationMessageFor(model => model.ImieKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nazwisko: ") %></b>
                <%: Html.EditorFor(model => model.NazwiskoKontakt) %>
                <%: Html.ValidationMessageFor(model => model.NazwiskoKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Ulica: ") %></b>
                <%: Html.EditorFor(model => model.UlicaKontakt) %>
                <%: Html.ValidationMessageFor(model => model.UlicaKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr domu: ") %></b>
                <%: Html.EditorFor(model => model.NrDomuKontakt) %>
                <%: Html.ValidationMessageFor(model => model.NrDomuKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Nr mieszkania: ") %></b>
                <%: Html.EditorFor(model => model.NrMieszkaniaKontakt) %>
                <%: Html.ValidationMessageFor(model => model.NrMieszkaniaKontakt) %>
            </div>
            <div class="editor-label">
                <b>
                    <%: Html.Label("Kod pocztowy: ") %></b>
                <%= Html.DropDownList("kodPocztowyKontakt", (SelectList)ViewData["KodPocztowyKontakt"])%>
            </div>
        </fieldset>
        <p>
            <input type="submit" value="Dodaj" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </div>
</asp:Content>
