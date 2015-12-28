<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.KodyPocztowe>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kod pocztowy - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Kod pocztowy - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Kod pocztowy</legend>

    <div class="display-label"><b>Kod pocztowy</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Kod) %>
    </div>

    <div class="display-label"><b>Miejscowość</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Miejscowosci.Nazwa) %>
    </div>
   
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>
