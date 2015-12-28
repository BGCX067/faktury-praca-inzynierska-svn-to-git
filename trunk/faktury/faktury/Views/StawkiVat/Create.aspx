﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.StawkiVat>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
     Stawki VAT - nowy
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Stawki VAT - nowy</h2>

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>

<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Stawki Vat</legend>

        <div class="editor-label">
         <b><%: Html.Label("Wartość") %></b>   
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Wartosc) %><%: Html.Label("[%]") %> 
            <%: Html.ValidationMessageFor(model => model.Wartosc) %>
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
