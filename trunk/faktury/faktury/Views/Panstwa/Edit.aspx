<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Kraje>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Państwo - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Państwo - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Państwo</legend>
        <%: Html.HiddenFor(model => model.KrajID) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nazwa) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>
        <div class="editor-label">
            <p>
                Waluta</p>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Waluta) %>
            <%: Html.ValidationMessageFor(model => model.Waluta) %>
        </div>
        <div class="editor-label">
            <p>
                Skrótowe oznaczenie waluty</p>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.WalutaSkrot) %>
            <%: Html.ValidationMessageFor(model => model.WalutaSkrot) %>
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
