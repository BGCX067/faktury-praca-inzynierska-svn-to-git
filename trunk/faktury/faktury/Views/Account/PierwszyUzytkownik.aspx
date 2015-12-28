<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rejestracja użytkowników - pierwszy użytkownik
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Rejestracja użytkowników - pierwszy użytkownik</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Uzytkownik</legend>

        <div class="editor-label">
            <b>Imię</b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Imie) %>
            <%: Html.ValidationMessageFor(model => model.Imie) %>
        </div>

        <div class="editor-label">
          <b>  <%: Html.LabelFor(model => model.Nazwisko) %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwisko) %>
            <%: Html.ValidationMessageFor(model => model.Nazwisko) %>
        </div>

        <div class="editor-label"><b>Login</b></div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Login) %>
            <%: Html.ValidationMessageFor(model => model.Login) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Haslo) %>
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

         <%--<div class="editor-label">
            Uprawnienia
        </div>
        
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Role.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.HasloSzum) %>
        </div>

        <div>
            <%= Html.TextBox("rola", (TextBox)ViewData["Role"], new { ReadOnly = "ReadOnly" })%>
        </div>--%>

        <p>
            <input type="submit" value="Utwórz" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Powrót", "Index") %>
</div>

</asp:Content>
