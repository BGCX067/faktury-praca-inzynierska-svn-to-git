<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.FormyPlatnosci>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Formy płatności - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Formy płatności - szczegóły</h2>

<fieldset>
    <legend>Formy platnosci</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>

</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.FormaPlatnosciID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
