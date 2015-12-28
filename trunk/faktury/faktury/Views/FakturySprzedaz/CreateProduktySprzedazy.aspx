<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Modele.FakturaSprzedazy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Dodaj produkty do faktury sprzedaży
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Dodaj produkty do faktury sprzedaży
    </h1>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <div class="editor-label">
            Produkt
        </div>
        <div>
            <%= Html.DropDownList("Towary", (SelectList)ViewData["Towary"])%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.ProduktFakturySprzedazy.Ilosc) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.ProduktFakturySprzedazy.Ilosc) %>
            <%: Html.ValidationMessageFor(model => model.ProduktFakturySprzedazy.Ilosc) %>
        </div>
        <p>
            <input type="submit" value="Dodaj produkt" />
        </p>
    </fieldset>
    <% } %>
    <p>
        <%: Html.ActionLink("Zakończ", "Details", new { id = Model.dokumentSprzedazy.DokumentSprzedazyID })%>
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
        <% foreach (var item in Model.ListaProduktowSprzedazy)
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
                <%: Html.ActionLink("Usuń", "DeleteProduktFakturySprzedazy", new { id = item.ProduktFakturySprzedazyID })%>
            </td>
        </tr>
        <% } %>
    </table>
</asp:Content>
