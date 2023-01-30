
# VTT App
Aplikacja ułatwiająca zarządzanie ekwipunkiem oraz opisami światów przy prowadzeniu sesji rpg. 
Użytkownik musi się zalogować/zarejestrować by móc korzystać ze strony.
Informacje są przypisywane do obecnie zalogowanego użytkownika.


## Wymagania
Aby korzystać z aplikacji wymagany jest [Visual Studio Code](https://code.visualstudio.com/), pakiet [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) oraz  [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads). 

## Jak uruchomić?
1. Sklonuj [repozytorium](https://github.com/kZywiec/VTT-ASP.NET).
2. Otwórz plik `appsetings.json` w Visual Studio Code.
3. Zamień `"DefaultConnection": "Data Source=YourSqlServerPath; [...]` na ścieżkę do twojego Serwera SQL.
4. Skompiluj aplikację.

## Testowi użytkownicy
 
Administrator:
- Login: admin
- Hasło: admin

Chcąc przetestować funkcje zwykłego użytkownika załóż konto poprzez formularz rejestracji.


## Perspektywa użytkownika
## Logowanie
Strona z logowaniem: ``https://localhost:7104`` jest stroną startową. Należy podać adres login i hasło.

Po przesłaniu formularza w przypadku podania poprawnych danych logowania użytkownik jest przenoszony pod adres: ``https://localhost:7104/Home/Index`` do strony głównej z Menu.

## Rejestracja

Dowolny użytkownik ma dostęp do strony ``https://localhost:7104/Home/Register`` na której w formularzu zostawia dane logowania: adres login i hasło. 

Po wysłaniu formularza w przypadku ustawienia poprawnych danych użytkownik jest przenoszony do strony głównej z Menu ``https://localhost:7104/Home/Index``.

## Menu

Użytkownik dostaje dostęp do zarządzania:

- Użytkownikami [Admin]
- Światami
- Postaciami z poszczególnych światach


Każde z przekierowań przenosi użytkownika do listy przypisanych mu obiektów które może:
- Tworzyć
- Edytować 
- Usuwać
- Sprawdzać ich szczegóły

W Przypadku Postaci każda z nich posiada niewielką ikono skrzyni odwołującą do Ekwipunku postaci.
## Zależności

Każdy świat przypisany jest do użytkownika, który go stworzył.
Do każdego świata są przypisani jego mieszkańcy (Postacie) a każda z nich posiada własną listę posiadanych przedmiotów.
## Wykorzystane pakiety

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServe
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.NET.Test.Sdk
- MSTest.TestFramework
- MSTest.TestAdapter
