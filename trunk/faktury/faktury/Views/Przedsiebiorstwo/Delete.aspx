<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.PrzedsiebiorstwoRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Przedsiębiorstwo - usuń
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Przedsiębiorstwo - usuń</h1>
    <h3>
        Czy na pewno usunąć wybrany rekord?</h3>
    <fieldset>
        <legend>Przedsiębiorstwo</legend>
        
        <div class="display-field">
           <b> <%: Html.DisplayFor(model => model.PelnaNazwaPrzedsiebiorsta) %></b>
        </div>

</fieldset>
<% using (Html.BeginForm()) { %>
    <p>
        <input type="submit" value="Usuń" /> |
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </p>
<% } %>

</asp:Content>
