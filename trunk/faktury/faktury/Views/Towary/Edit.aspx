<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Repozytoria.TowaryUslugiRepozytorium>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Towary i usługi - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Towary i usługi - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Towar/Usługa </legend>
      <%--  <% Html.RenderPartial("TowarUtworzEdytujPartial"); %>--%>


      
        <fieldset style="width: 17%; float: left">
            <legend>Rodzaj</legend>
            <%: Html.RadioButtonFor(model => model.rodzaj, true, new { id = "RodzajTowaruTrue" })%>
            <label for="RodzajTowaruTrue">
                Towar</label>
            <%: Html.RadioButtonFor(model => model.rodzaj, false, new { id = "RodzajTowaruFalse" } )%>
            <label for="RodzajTowaruFalse">
                Usługa</label>
        </fieldset><br /><br /><br /><br /><br />

        <div class="editor-label">
            <b><%: Html.LabelFor(model => model.NowyTowar.Nazwa)%></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NowyTowar.Nazwa)%>
            <%: Html.ValidationMessageFor(model => model.NowyTowar.Nazwa)%>
        </div>

        <fieldset style="width: 25%; float: left">
            <legend>Cena jednostkowa</legend>
            <%: Html.RadioButtonFor(model => model.netto, true, new { id = "CenaNettoFalse" })%>
            <label for="CenaNettoFalse">
                Netto</label>
            <%: Html.RadioButtonFor(model => model.netto, false, new { id = "CenaNettoTrue" } )%>
            <label for="CenaNettoTrue">
                Brutto</label><br />
            <div class="editor-field">
                <%: Html.EditorFor(model => model.cena)%>
            </div>
        </fieldset> <br /><br /><br /><br /><br /><br />

        <%: Html.ValidationMessageFor(model => model.cena)%>
        <div class="editor-label">
            <b>
                <%: Html.Label("Stawka VAT")%></b>
        </div>
        <div>
            <%= Html.DropDownList("stawka", (SelectList)ViewData["StawkiVAT"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Jednostka miary")%></b>
        </div>
        <div>
            <%= Html.DropDownList("jm", (SelectList)ViewData["JenostkiMiar"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Marża") %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NowyTowar.Marza)%>
            <%: Html.ValidationMessageFor(model => model.NowyTowar.Marza)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.LabelFor(model => model.NowyTowar.Uwagi)%></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NowyTowar.Uwagi)%>
            <%: Html.ValidationMessageFor(model => model.NowyTowar.Uwagi)%>
        </div>
        <p>
            <input type="submit" value="Zapisz" />
        </p>




    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </div>
</asp:Content>
