<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rejestracja użytkowników
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script>
$("#KodPocztowy").change(function() {
    $.ajax({
        url: 'Account/Register',
        type: "POST",
        data: { 'sortBy': $(this).val() },
        dataType: "json",
        success: function(result) { $('#updateText').text(result); },
        error: function(error) { alert(error); }
    })

});
</script>
    <h2>
        Rejestracja użytkowników</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Uzytkownik</legend>
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
            Login
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Login) %>
            <%: Html.ValidationMessageFor(model => model.Login) %>
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
        <div class="editor-label"><%: Html.Label("Kod pocztowy") %></div>
        <div>
            <%= Html.DropDownList("KodPocztowy", (SelectList)ViewData["KodyPocztowe"])%>
        </div>
        <div class="editor-label">
            <%: Html.Label("Nip") %>
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
            <%: Html.LabelFor(model => model.Uwagi) %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Uwagi) %>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
        </div>
        <div class="editor-label">
           <%: Html.Label("Uprawnienia") %> 
        </div>
        <div>
            <%= Html.DropDownList("Rola", (SelectList)ViewData["Role"])%>
        </div>
        <div class="editor-label">
            <%: Html.Label("E-mail") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Hasło") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Haslo) %>
            <%: Html.ValidationMessageFor(model => model.Haslo) %>
        </div>

        <%--
        <div class="editor-label">
            <%: Html.LabelFor(model => model.HasloSzum) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.HasloSzum) %>
            <%: Html.ValidationMessageFor(model => model.HasloSzum) %>
        </div>--%>

        <p>
            <input type="submit" value="Utwórz" />
        </p>
    </fieldset>
    <% } %>
    <div>
         <%: Html.ActionLink("Powrót do listy", "Index") %>
    </div>
</asp:Content>
