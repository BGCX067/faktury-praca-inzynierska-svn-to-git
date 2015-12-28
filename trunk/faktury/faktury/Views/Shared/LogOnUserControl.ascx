<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated)
    {
%>
Witaj <strong>
    <%: Page.User.Identity.Name %></strong>! [
<%: Html.ActionLink("Zmień hasło", "ChangePassword", "Account") %>
] | [
<%: Html.ActionLink("Wyloguj się", "LogOff", "Account") %>
]
<%
    }
    else
    {
%>
[
<%: Html.ActionLink("Zaloguj się", "LogOn", "Account") %>
]
<%
    }
%>
