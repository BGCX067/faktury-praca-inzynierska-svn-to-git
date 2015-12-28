<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaKupna>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dodaj rozliczenie do faktury kupna
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <body onload="pageStart()">
        <script type='text/javascript'>
            function pageStart() {
                $("#DataZaplaty").datepicker();
            }  
        </script>
    </body>
    <h1>
        Dodaj rozliczenie do faktury kupna</h1>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <div class="editor-label">
            <b>
                <%: Html.Label("Data zapłaty: ") %></b>
        </div>
        <input type="text" name="RozliczenieKupna.DataZaplaty" id="DataZaplaty" />
        <%: Html.ValidationMessageFor(model => model.RozliczenieKupna.DataZaplaty) %>
        <div class="editor-label">
            <b>
                <%: Html.Label("Kwota: ") %></b>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.RozliczenieKupna.Kwota)%>
            <%: Html.ValidationMessageFor(model => model.RozliczenieKupna.Kwota)%>
        </div>
        <p>
            <input type="submit" value="Dodaj rozliczenie" />
        </p>
    </fieldset>
    <% } %>
    <p>
        <%: Html.ActionLink("Zakończ", "Details", new { id = Model.dokumentKupna.DokumentKupnaID })%>
    </p>
    <table>
        <tr>
            <th>
                Data zapłaty
            </th>
            <th>
                Kwota
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model.ListaRozliczeniaKupna)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.DataZaplaty) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Kwota) %>
            </td>
            <td>
                <%: Html.ActionLink("Usuń", "DeleteRozliczenieFakturyKupna", new { id = item.RozliczenieKupnaID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
