<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Użytkownik - usuń
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Użytkownik - usuń</h2>
    <h3>
        Czy na pewno usunąć wybrany rekord?</h3>
    <fieldset>
        <legend>Użytkownik do usunięcia</legend>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Imie) %>
            <%: Html.DisplayFor(model => model.Nazwisko) %>
        </div>
        <div class="display-label">
            Login</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Login) %>
        </div>
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>
        <input type="submit" value="Delete" />
        |
        <%: Html.ActionLink("Powrót do listy", "Index") %>
    </p>
    <% } %>
</asp:Content>
