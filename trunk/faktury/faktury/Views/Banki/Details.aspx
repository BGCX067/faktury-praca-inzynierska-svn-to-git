<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Banki>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rachunki bankowe - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Rachunki bankowe - szczegóły</h2>

<fieldset>
    <legend>Banki</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>

    <div class="display-label">Nr Banku</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NrBanku) %>
    </div>

    <div class="display-label">Uwagi</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Uwagi) %>
    </div>
    
</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.BankID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index") %>
</p>

</asp:Content>
