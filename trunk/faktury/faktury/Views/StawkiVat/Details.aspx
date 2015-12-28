<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.StawkiVat>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
     Stawki VAT - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Stawki VAT - szczegóły</h2>

<fieldset>
    <legend>Stawki Vat</legend>

    <div class="display-label">Wartość</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Wartosc) %>
    </div>
</fieldset>
<p>

    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.StawkaVatID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
