<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.KodyPocztowe>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kody pocztowe - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Kody pocztowe - szczegóły</h2>

<fieldset>
    <legend>Kody pocztowe</legend>

   <div class="display-label"><b>Kod pocztowy</b></div> 
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Kod) %>
    </div>

    <div class="display-label"><b>Miejscowość</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Miejscowosci.Nazwa) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.KodPocztowyID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
