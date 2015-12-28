<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Repozytoria.TowaryUslugiRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Towar/Usługa - szczegóły
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Towar/Usługa - szczegóły</h2>

<fieldset>
    <legend><b>Towar/Usługa</b></legend>

    <div class="display-label"><b>Rodzaj</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.Rodzaj) %>
    </div>

    <div class="display-label"><b>Nazwa</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.Nazwa) %>
    </div>

    <div class="display-label"><b>Cena netto</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.CenaNetto) %>
    </div>
     <div class="display-label"><b>Stawka VAT</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.VatTowar.Wartosc) %>
    </div>
     <div class="display-label"><b>Cena brutto</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.CenaBrutto) %>
    </div>
     <div class="display-label"><b>Jednostka miary</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.JednostkaTowar.Nazwa) %>
    </div>
       <div class="display-label"><b>Marża</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.Marza) %>
    </div>
     <div class="display-label"><b>Uwagi</b></div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.TowarUsluga.Uwagi) %>
    </div>
</fieldset>
<p>
    <%: Html.ActionLink("Edytuj", "Edit", new { id = Model.TowarUsluga.TowarID })%> |
    <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>

</asp:Content>
