<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaSprzedazy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dodaj rozliczenie do faktury sprzedaży
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <body onload="pageStart()">
        <script type='text/javascript'>
            function pageStart() {
                $("#DataWplaty").datepicker();
            }  
        </script>
    </body>
    <h1>
        Dodaj rozliczenie do faktury sprzedaży </h1>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data wpłaty: ") %></b>
        </div>
        <input type="text" name="RozliczenieSprzedazy.DataWplaty" id="DataWplaty" />
        <%: Html.ValidationMessageFor(model => model.RozliczenieSprzedazy.DataWplaty) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Kwota: ") %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RozliczenieSprzedazy.Kwota) %>
            <%: Html.ValidationMessageFor(model => model.RozliczenieSprzedazy.Kwota) %>
        </div>
        <p>
            <input type="submit" value="Dodaj rozliczenie" />
        </p>
    </fieldset>
    <% } %>
    <p>
        <%: Html.ActionLink("Zakończ", "Details", new { id = Model.dokumentSprzedazy.DokumentSprzedazyID })%>
    </p>
    <table>
        <tr>
            <th>
                Data wpłaty
            </th>
            <th>
                Kwota
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model.ListaRozliczeniaSprzedazy)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.DataWplaty) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Kwota) %>
            </td>
            <td>
                <%: Html.ActionLink("Usuń", "DeleteRozliczenieFakturySprzedazy", new { id = item.RozliczenieSprzedazyID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
