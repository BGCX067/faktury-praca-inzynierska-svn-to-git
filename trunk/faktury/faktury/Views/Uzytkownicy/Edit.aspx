<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Użytkownicy - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Użytkownicy - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Użytkownik</legend>
        <%: Html.HiddenFor(model => model.UzytkownikID) %>
        <div class="editor-label">
            <%: Html.Label("Imię") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Imie) %>
            <%: Html.ValidationMessageFor(model => model.Imie) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nazwisko) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwisko) %>
            <%: Html.ValidationMessageFor(model => model.Nazwisko) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Ulica) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Ulica) %>
            <%: Html.ValidationMessageFor(model => model.Ulica) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Nr domu") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NrDomu) %>
            <%: Html.ValidationMessageFor(model => model.NrDomu) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Nr mieszkania") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NrMieszkania) %>
            <%: Html.ValidationMessageFor(model => model.NrMieszkania) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Kod pocztowy") %></div>
        <div>
            <%= Html.DropDownList("KodPocztowy", (SelectList)ViewData["KodyPocztowe"])%>
        </div>
        <div class="editor-label">
            <%: Html.Label("NIP") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nip) %>
            <%: Html.ValidationMessageFor(model => model.Nip) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Pesel) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Pesel) %>
            <%: Html.ValidationMessageFor(model => model.Pesel) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("E-mail") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Uprawnienia") %>
        </div>
        <div>
            <%= Html.DropDownList("Rola", (SelectList)ViewData["Role"])%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Uwagi) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Uwagi) %>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
        </div>
        <p>
            <input type="submit" value="Zapisz" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Powrót do listy", "Index") %>
    </div>
</asp:Content>
