<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Banki>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Rachunki bankowe - nowy
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Rachunki bankowe - nowy</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Banki</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Nazwa) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Nazwa) %>
            <%: Html.ValidationMessageFor(model => model.Nazwa) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.NrBanku) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.NrBanku) %>
            <%: Html.ValidationMessageFor(model => model.NrBanku) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Uwagi) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Uwagi) %>
            <%: Html.ValidationMessageFor(model => model.Uwagi) %>
        </div>     

        <p>
            <input type="submit" value="Dodaj" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Powrót do listy", "Index") %>
</div>

</asp:Content>
