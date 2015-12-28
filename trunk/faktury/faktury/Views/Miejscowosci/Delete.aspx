<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Miejscowosci>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    MiejscowoSci - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>MiejscowoSci - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Miejscowość</legend>

    <div class="display-label"><b>Nazwa</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwa) %>
    </div>

    <div class="display-label"><b>Kraj</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Kraje.Nazwa) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>
