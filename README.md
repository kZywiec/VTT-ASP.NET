# VTT-ASP.NET

# VTT App
Aplikacja ułatwiająca zarządzanie ekwipunkiem oraz opisami światów przy prowadzeniu sesji rpg. 
Użytkownik musi się zalogować/zarejestrować by móc korzystać ze strony.
Informacje są przypisywane do obecnie zalogowanego użytkownka.


## Wymagania
Aby korzystać z aplikacji wymagany jest [Visual Studio Code](https://code.visualstudio.com/), pakiet [ASP.NET Core 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) oraz  [SQL Server](https://www.microsoft.com/pl-pl/sql-server/sql-server-downloads). 

## Jak uruchomić?
1. Sklonuj [repozytorum](https://github.com/kZywiec/VTT-ASP.NET).
2. Otwórz plik `appsetings.json` w Visual Studio Code.
3. Zamień `"DefaultConnection": "Data Source=YourSqlServerPath; [...]` na ścieżkę do twojego Servera SQL.
4. Skompiluj aplikację.
![ServerPath](https://user-images.githubusercontent.com/92109351/215616179-42c1b659-d031-430a-987a-27bb69620a22.png)

## Testowi użytkownicy

Administrator:
- Login: admin
- Hasło: admin

Chcąc przetestować funkcje zwykłego użytkownika załóż konto poprzez formularz rejestracji.


## Perspektywa użytkownika
## Logowanie
Strona z logowaniem: ``https://localhost:7104`` jest stroną startową. Należy podać adres login i hasło.
![Login](https://user-images.githubusercontent.com/92109351/215615319-87703329-dded-4469-8219-1752f975cbfa.jpg)
Po przesłaniu formularza w przypadku podania poprawnych danych logowania użytkownik jest przenoszony pod adres: ``https://localhost:7104/Home/Index`` do strony głównej z Menu.

## Rejestracja

Dowolny użytkownik ma dostęp do strony ``https://localhost:7104/Home/Register`` na której w formularzu zostawia dane logowania: adres login i hasło. 

Po wysłaniu formularza w przypadku ustawienia poprawnych danych użytkownik jest przenoszony do strony głównej z Menu ``https://localhost:7104/Home/Index``.

## Menu

Użytkownik dostaje dostęp do zarządzania:

- Użytkownikami [Admin]
- Światami
- Postaciami z poszczegulnych światach
![Menu_admin](https://user-images.githubusercontent.com/92109351/215616108-b50b9116-726b-484c-8eb5-c2a9d2749374.png)


Każde z przekierowań przenosi użytkownika do listy przypisanych mu obiektów które może:
- Tworzyć
- Edytować 
- Usuwać
- Sprawdzać ich szczegóły
![UsersList](https://user-images.githubusercontent.com/92109351/215616140-4e3393a8-5c7e-4fa1-834f-23be58420e72.png)
![CharacterCreate](https://user-images.githubusercontent.com/92109351/215616147-c798a172-2a8d-44aa-9871-4905ac2cfe74.png)

W Przypadku Postaci każda z nich posiada niewielką ikono skrzyni odwołującą do Ekwipunku postaci.
## Zależności

Każdy świat przypisany jest do użytkownika, który go stworzył.
Do każdego świata są przypisani jego mieszkańcy (Postacie) a każda z nich posiada własną listę posiadanych przedmiotów.
![baza](https://user-images.githubusercontent.com/92109351/215628235-fa593d1c-9e3d-4d22-aa8f-aaf7d494cf67.png)

## Wykorzystane pakiety

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServe
- Microsoft.VisualStudio.Web.CodeGeneration.Design
- Microsoft.NET.Test.Sdk
- MSTest.TestFramework
- MSTest.TestAdapter
