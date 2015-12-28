<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.FormyPlatnosci>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Formy płatności - edycja
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Formy płatności - edycja</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Formy płatności</legend>

        <%: Html.HiddenFor(model => model.FormaPlatnosciID) %>

        <div class="editor-label">
            <%: Html.Label("Forma płatności") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
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
