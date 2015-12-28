<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Błąd postepowania
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-size: large; text-decoration: underline; font-weight: bold;">
        Błąd przy postępowaniu z programem</h3>
    <h4>
        Proszę postępować zgodnie z logiką programu i uzupełnić brakujące elementy:
    </h4>
    <ul id="colors">
        <% foreach (var brakuje in ViewData["Brakuje"] as List<string>)
           { %>
        <li>
            <%: brakuje%>
        </li>
        <% } %>
    </ul>
</asp:Content>
