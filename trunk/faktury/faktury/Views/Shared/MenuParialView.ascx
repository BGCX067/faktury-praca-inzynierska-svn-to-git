<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%--<ul class="sf-menu">
    <li class="current">
    <%: Html.ActionLink("Administrator", "", "")%>
    <%--<%: Html.Label("Administrator")%>--%>
      <%--  <ul>
            <li>
                <%: Html.ActionLink("Użytkownicy", "Index", "Uzytkownicy")%></li>
            <li>
                <%: Html.ActionLink("Dane przedsiębiorstwa", "Index", "Przedsiebiorstwa")%></li>
        </ul>
    </li>--%>
    <%--<li class="current">Kupno--%>
    <li class="current">
    <%: Html.ActionLink("Kupno", "", "")%>
        <ul>
            <li>
                <%: Html.ActionLink("Kontrahenci", "Index", "KontrahenciKupno")%></li>
            <li>
                <%: Html.ActionLink("Faktury", "Index", "FakturyKupno")%></li>
            <li>
                <%: Html.ActionLink("Produkty", "Index", "ProduktyKupno")%></li>
        </ul>
    </li>

    <li class="current"><%--Sprzedaż--%>
        <%: Html.ActionLink("Sprzedaż", "", "")%>
        <ul>
            <li>
                <%: Html.ActionLink("Kontrahenci", "Index", "KontrahenciSprzedaz")%></li>
            <li>
                <%: Html.ActionLink("Faktury", "Index", "FakturySprzedaz")%></li>
            <li>
                <%: Html.ActionLink("Produkty", "Index", "ProduktySprzedaz")%></li>
        </ul>
    </li>
</ul>--%>
