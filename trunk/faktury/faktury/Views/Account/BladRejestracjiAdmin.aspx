<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<faktury.Models.Uzytkownicy>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Brak uprwanień!
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-size: large; text-decoration: underline; font-weight: bold;">
        Brak uprawnień! </h3>
    <h4>
        <p style="font-size: medium">
            Przepraszamy, aby móc kontynuować, musisz być zalogowany oraz należeć do
            grupy Administratorów</p>
        <p style="font-size: medium">
            W celu dalszego korzystania z programu
            <%: Html.ActionLink("Zaloguj się", "LogOn")%>
            , jeżeli nie posiadasz konta, prosimy o kontakt z Administratorem systemu.
        </p>
    </h4>
</asp:Content>
