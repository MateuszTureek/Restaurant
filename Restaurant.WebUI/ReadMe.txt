Copyright: Mateusz Turek

Serwis WWW restauracja.

Funkcje zaimplementowane:
- prezentacja restauracji i oferty
- prezentacja danych kontaktowych
- logowanie uzytkowaników(system bazujacy na rolach)
- zarzadzanie rezerwacjami
- zarzadzanie poszczególnymi elementami takimi jak oferta restuaracji uzytkownikom z rola employee
- zarzadzanie uzytkownikami systemu dzieki przydzieleniu roli admin
- zaznaczenie potwierdzenia przybucia w danym zarezerwowanym dniu
- mozliwosc rezerwacji przez kazdego uzytkownika
- mozliwosc zarzadzania danymi konta przez zalogowanego uzytkownika np: zmiana hasła, email, numeru telefonu

Funkcje nie zaimplementowane ktore można by dodac do serwisu:
- prezentacja poszczegolnych stolików z numerem i pozycja na sali
- mozliwosc przypisania rezerazcji do poszczególnego stolika
- mozliwosc klientowi zalozenie konta i zarzadzanie przez internet rezerwacjami jak i przegladanie historii,
sledzenie ewentualnych zmian
- powiadomienia sms klienta o zblizajacym sie terminie zarezerwowanym

System powinno sie przetesować poprzez napisanie testów jednostkowy dla sprawdzenia poprawności kontrolerów i zwracanych danych poprzez repozytoria.

Co mozna ulepszyc:
- dodac dodatkowa warstwe serwis(odchudzic kontrolery)
- mapowanie view modeli do encji i usprawnic poprzez uzycie biblioteki Automapper

Konta testowe:

- admin

login: admin@fake.com
hasło: 12345

- employee
login: testUser@fake.com
hasło: 12345