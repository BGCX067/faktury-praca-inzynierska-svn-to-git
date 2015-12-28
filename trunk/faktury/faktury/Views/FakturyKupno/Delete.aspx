<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.DokumentyKupna>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Faktura kupna - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Faktura kupna - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Faktura do usunięcia</legend>
    <div class="display-label"><b>Nr faktury: </b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NrDokumentu) %>
    </div>
</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>