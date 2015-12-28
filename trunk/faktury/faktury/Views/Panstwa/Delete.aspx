<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Kraje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Państwo - usuń
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Państwo - usuń</h2>

<h3>Czy na pewno usunąć wybrany rekord?</h3>
<fieldset>
    <legend>Państwo</legend>

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
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>
