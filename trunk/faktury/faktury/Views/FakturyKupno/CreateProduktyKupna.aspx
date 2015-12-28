<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaKupna>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dodaj produkty do faktury kupna
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h1>Dodaj produkty do faktury kupna</h1>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
     <fieldset>
        <div class="editor-label">
            Produkt
        </div>
        <div>
            <%= Html.DropDownList("Towary", (SelectList)ViewData["Towary"])%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ProduktFakturyKupna.Ilosc) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ProduktFakturyKupna.Ilosc)%>
            <%: Html.ValidationMessageFor(model => model.ProduktFakturyKupna.Ilosc)%>
        </div>
        <p>
            <input type="submit" value="Dodaj produkt" />
        </p>
    </fieldset>
 <% } %>
    <p>
        <%: Html.ActionLink("Zakończ", "Details", new { id = Model.dokumentKupna.DokumentKupnaID })%>
    </p>
    <table>
        <tr>
            <th>
                Nazwa
            </th>
            <th>
                Ilość
            </th>
            <th>
                Cena netto
            </th>
            <th>
                Cena brutto
            </th>
            <th>
                Operacje
            </th>
        </tr>
        <% foreach (var item in Model.ListaProduktowKupna)
           { %>
        <tr>
            <td>
                <%: Html.DisplayFor(modelItem => item.TowaryUslugi.Nazwa) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.Ilosc) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.WartoscNetto) %>
            </td>
            <td>
                <%: Html.DisplayFor(modelItem => item.WartoscBrutto) %>
            </td>
            <td>
                <%: Html.ActionLink("Usuń", "DeleteProduktFakturKupna", new { id = item.ProduktFakturyKupnaID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>