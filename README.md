# SklepSportowy

# Przygotowanie aplikacji do uruchomienia
W pliku appsettings nale¿y okreœliæ serwer oraz bazê danych.
Nale¿y utworzyæ migracjê nastepuj¹cymi komendami:

add-migration InitialCreate -context AppDbContext

update-database -context AppDbContext

add-migration userInit -context UserContext

update-database -context UserContext

W bazie danych nale¿y przypisaæ role dla administratora.



# Opis aplikacji 
Aplikacja jest symulacj¹ sklepu ze sprzêtem sportowym,
s³u¿y do pokazania oferty sklepu, firm które dostarczaj¹ sprzêt oraz informuje o promocjach.
Na stronie mo¿na równie¿ znaleœæ dane kontakowe do pracowników sklepu. W projekcie wykonana zosta³a walidacja przy dodawaniu sprzêtu sportowego

# Testowanie
W aplikacji jest wykonane testowanie kontrolera api sprzêtu sportowego.


# Rola admina
Administrator po zalogwaniu w zak³adce Sprzêt Sportowy mo¿e dodaæ, usun¹c lub edytowaæ informacje na temat produktów.
Mo¿e tak¿e dodaæ nazwe firmy, która jest producentem danego produktu oraz promocje - jej nazwê oraz wartoœæ procentow¹ jaka jest do zaoferowania na dany sprzêt.


# Rola u¿ytkownika
U¿ytkownik mo¿e utworzyæ konto oraz przegl¹daæ informacjê na temat sprzêtu sportowego, firm oraz promocji.