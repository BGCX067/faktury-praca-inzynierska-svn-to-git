<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.LogOnModel>" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Logowanie
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Logowanie</h1>
    <p>
        Proszę wpisać swój login i hasło. <%: Html.ActionLink("Rejestracja", "Register") %> - jeżeli jesteś pierwszym użytkownikiem systemu.
    </p>

    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

    <% using (Html.BeginForm()) { %>
        <%: Html.ValidationSummary(true, "Logowanie zakończone niepowodzeniem. Proszę poprawić błędy i spróbować jeszcze raz.") %>
        <div>
            <fieldset>
                <legend>Informacje o użytkowniku</legend>
                
                <div class="editor-label">
                    <%: Html.Label("Login") %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.UserName) %>
                    <%: Html.ValidationMessageFor(m => m.UserName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.Label("Hasło") %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.CheckBoxFor(m => m.RememberMe) %>
                    <%: Html.Label("Zapamiętaj mnie") %>
                </div>
                
                <p>
                    <input type="submit" value="Zaloguj" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
