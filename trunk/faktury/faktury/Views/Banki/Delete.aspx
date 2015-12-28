<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Banki>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rachunki bankowe - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Rachunki bankowe - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Usuń rekord</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>

    <div class="display-label">NrBanku</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NrBanku) %>
    </div>

    <div class="display-label">Uwagi</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Uwagi) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index") %>
    </p>
<% } %>

</asp:Content>
