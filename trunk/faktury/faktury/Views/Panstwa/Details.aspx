<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Kraje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Państwa - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Państwa - szczegóły</h2>

<fieldset>
    <legend>Państwa</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>
        <div class="display-label">Waluta</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Waluta) %>
    </div>
        <div class="display-label">Skrótowe oznaczenie waluty</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.WalutaSkrot) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.KrajID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
