<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.OdbiorcyRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Odbiorca - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Odbiorca - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Odbiorca</legend>

    <div class="display-field">
        <%: Html.DisplayFor(model => model.PelnaNazwaOdbiorcy) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>
