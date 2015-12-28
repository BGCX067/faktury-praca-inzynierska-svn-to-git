<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Kraje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Państwo - nowy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Państwo - nowy</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Państwo</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nazwa) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>
        <div class="editor-label">Waluta</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Waluta) %>
            <%: Html.ValidationMessageFor(model => model.Waluta) %>
        </div>
        <div class="editor-label">Skrótowe oznaczenie waluty</div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.WalutaSkrot) %>
            <%: Html.ValidationMessageFor(model => model.WalutaSkrot) %>
        </div>
        <p>
            <input type="submit" value="Dodaj" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Powrót do listy", "Index")%>
    </div>
</asp:Content>
