<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.KodyPocztowe>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Kod pocztowy - nowy
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Kod pocztowy - nowy</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>"
        type="text/javascript"></script>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Kod pocztowy</legend>
        <div class="display-label">
            <b>Kod pocztowy</b></div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Kod) %>
            <%: Html.ValidationMessageFor(model => model.Kod) %>
        </div>
        <div class="editor-label">
          <p>  <b>Miejscowość</b></p>
        </div>
        <div>
            <%= Html.DropDownList("miejscowosc", (SelectList)ViewData["Miejscowosci"])%>
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
