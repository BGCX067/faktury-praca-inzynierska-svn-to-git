<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.DokumentyKupna>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dokument kupna - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <body onload="pageStart()">
        <script type='text/javascript'>
            function pageStart() {
                $("#DataSprzedazy").datepicker();
                $("#DataWystawienia").datepicker();
                $("#terminPlatnosci").datepicker();
            }  
        </script>
    </body>
    <h1>
        Dokument kupna - edycja</h1>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Dokument kupna</legend>
        <div class="editor-label">
            <b>
                <%: Html.Label("Nr faktury: ") %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NrDokumentu) %>
            <%: Html.ValidationMessageFor(model => model.NrDokumentu) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data wystawienia: ") %></b>
        </div>
        <input type="text" name="DataWystawienia" id="DataWystawienia" />
        <%: Html.ValidationMessageFor(model => model.DataWystawienia) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data sprzedaży: ") %></b>
        </div>
        <input type="text" name="DataSprzedazy" id="DataSprzedazy" />
        <%: Html.ValidationMessageFor(model => model.DataSprzedazy) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Dostawca: ") %></b>
        </div>
        <div>
            <%= Html.DropDownList("Kontrahent", (SelectList)ViewData["Kontrahenci"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Forma płatności: ") %></b>
        </div>
        <div>
            <%= Html.DropDownList("FormaPlatnosci", (SelectList)ViewData["FormyPlatnosci"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Termin płatności: ") %></b>
        </div>
        <input type="text" name="terminPlatnosci" id="terminPlatnosci" />
        <%: Html.ValidationMessageFor(model => model.TerminPlatnosci) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Uwagi: ") %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Uwagi) %>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
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
