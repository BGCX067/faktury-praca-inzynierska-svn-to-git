<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<faktury.Models.Uzytkownicy>" %>

<fieldset>
    <legend>Użytkownik</legend>

    <div class="display-label">Imię</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Imie) %>
    </div>

    <div class="display-label">Nazwisko</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nazwisko) %>
    </div>

    <div class="display-label">Login</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Login) %>
    </div>

    <div class="display-label">Ulica</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Ulica) %>
    </div>

    <div class="display-label">NrDomu</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NrDomu) %>
    </div>

    <div class="display-label">NrMieszkania</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.NrMieszkania) %>
    </div>

    <div class="display-label">KodPocztowyID</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.KodPocztowyID) %>
    </div>

    <div class="display-label">Nip</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Nip) %>
    </div>

    <div class="display-label">Pesel</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Pesel) %>
    </div>

    <div class="display-label">Uwagi</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Uwagi) %>
    </div>

    <div class="display-label">WlascicielID</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.WlascicielID) %>
    </div>

    <div class="display-label">DataWprowadzenia</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DataWprowadzenia) %>
    </div>

    <div class="display-label">ModyfikujacyID</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.ModyfikujacyID) %>
    </div>

    <div class="display-label">DataModyfikacji</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DataModyfikacji) %>
    </div>
    
    <div class="display-label">Email</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.Email) %>
    </div>

    <div class="display-label">DataZablokowania</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.DataZablokowania) %>
    </div>

    <div class="display-label">BlokujacyID</div>
    <div class="display-field">
        <%: Html.DisplayFor(model => model.BlokujacyID) %>
    </div>
</fieldset>
<p>

     <%: Html.ActionLink("Edytuj", "Edit", new { id=Model.UzytkownikID }) %> |
  <%: Html.ActionLink("Powrót do listy", "Index")%>
</p>
