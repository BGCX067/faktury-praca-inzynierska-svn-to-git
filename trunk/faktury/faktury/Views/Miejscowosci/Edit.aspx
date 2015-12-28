<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Miejscowosci>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Miejscowości - edycja
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Miejscowości - edycja</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Miejscowość</legend>
        <%: Html.HiddenFor(model => model.MiejscowoscID) %>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nazwa) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>
        <div class="editor-label">
            <p>
                <b>Kraj</b></p>
        </div>
        <div>
            <%= Html.DropDownList("kraj", (SelectList)ViewData["Kraje"])%>
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
