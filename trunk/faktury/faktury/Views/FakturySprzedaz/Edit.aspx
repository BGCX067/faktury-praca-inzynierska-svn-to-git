<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.DokumentySprzedazy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dokument sprzedaży - edycja
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
    <h2>
        Dokument sprzedaży - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend></legend>
        <div>
            <%:Html.HiddenFor(m => m.NrDokumentu)%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Typ dokumentu: ") %></b>
        </div>
        <div class="editor-field">
            <%=Html.RadioButtonFor(m => m.TypDokumentu, "Faktura VAT", new { @checked = "checked" })%>
            Faktura VAT
        </div>
        <div>
            <%=Html.RadioButtonFor(m => m.TypDokumentu, "Faktura Pro-Forma")%>
            Faktura Pro-Forma
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data wystawienia: ") %></b>
        </div>
        <input type="text" name="DataWystawienia" id="DataWystawienia" />
        <%: Html.ValidationMessageFor(m => m.DataWystawienia) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data sprzedaży: ") %></b>
        </div>
        <input type="text" name="DataSprzedazy" id="DataSprzedazy" />
        <%: Html.ValidationMessageFor(m => m.DataSprzedazy) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Miejscowość: ") %></b>
        </div>
        <div>
            <%= Html.DropDownList("Miejscowosc", (SelectList)ViewData["Miejscowosci"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Płatnik: ") %></b>
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
                <%: Html.Label("Bank: ") %></b>
        </div>
        <div>
            <%= Html.DropDownList("Bank", (SelectList)ViewData["Banki"])%>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Termin płatności: ") %></b>
        </div>
        <input type="text" name="terminPlatnosci" id="terminPlatnosci" />
        <div class="editor-label">
            <b>
                <%: Html.Label("Uwagi: ") %></b>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(m => m.Uwagi) %>
            <%: Html.ValidationMessageFor(m => m.Uwagi) %>
        </div>
        <div class="editor-label">
            <b>
                <%: Html.Label("Waluta: ") %></b>
        </div>
        <div>
            <%= Html.DropDownList("Waluta", (SelectList)ViewData["Waluty"])%>
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
