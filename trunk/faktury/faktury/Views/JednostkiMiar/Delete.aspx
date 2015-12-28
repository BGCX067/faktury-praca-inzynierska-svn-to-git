<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.JednostkiMiar>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Jednostki miar - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Jednostki miar - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Jednostki miar</legend>

    <div class="display-label">Nazwa</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index") %>
    </p>
<% } %>

</asp:Content>
