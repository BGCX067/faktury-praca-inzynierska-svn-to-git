<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Użytkownicy - szczegóły
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Użytkownicy - szczegóły</h2>
    <fieldset>
        <legend>Użytkownik</legend>
        <div class="display-label">
            Imię</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Imie) %>
        </div>
        <div class="display-label">
            Nazwisko</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Nazwisko) %>
        </div>
        <div class="display-label">
            Login</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Login) %>
        </div>
        <div class="display-label">
            Ulica</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Ulica) %>
        </div>
        <div class="display-label">
            Nr domu</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.NrDomu) %>
        </div>
        <div class="display-label">
            Nr mieszkania</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.NrMieszkania) %>
        </div>
        <div class="display-label">
            Kod pocztowy</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.KodyPocztowe3.Kod) %>
        </div>
        <div class="display-label">
            Miejscowość</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.KodyPocztowe3.Miejscowosci.Nazwa) %>
        </div>
        <div class="display-label">
            NIP</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Nip) %>
        </div>
        <div class="display-label">
            Pesel</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Pesel) %>
        </div>
        <div class="display-label">
            Email</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Email) %>
        </div>
        <div class="display-label">
            Uwagi</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Uwagi) %>
        </div>
        <div class="display-label">
            Uprawnienia</div>
        <div class="display-field">
            <%: Html.DisplayFor(model => model.Role.Nazwa) %>
        </div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Edytuj", "Edit", new { id=Model.UzytkownikID }) %>
        |
        <%: Html.ActionLink("Powrót do listy", "Index") %>
    </p>
</asp:Content>
