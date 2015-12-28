<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.JednostkiMiar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
     Jednostki miar - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Jednostki miar - szczegóły</h2>

<fieldset>
    <legend>Jednostki miar</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.JednostkaMiarID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
