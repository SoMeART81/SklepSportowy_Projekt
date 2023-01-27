# SklepSportowy

# Przygotowanie aplikacji do uruchomienia
W pliku appsettings nale�y okre�li� serwer oraz baz� danych.
Nale�y utworzy� migracj� nastepuj�cymi komendami:

add-migration InitialCreate -context AppDbContext

update-database -context AppDbContext

add-migration userInit -context UserContext

update-database -context UserContext

W bazie danych nale�y przypisa� role dla administratora.



# Opis aplikacji 
Aplikacja jest symulacj� sklepu ze sprz�tem sportowym,
s�u�y do pokazania oferty sklepu, firm kt�re dostarczaj� sprz�t oraz informuje o promocjach.
Na stronie mo�na r�wnie� znale�� dane kontakowe do pracownik�w sklepu. W projekcie wykonana zosta�a walidacja przy dodawaniu sprz�tu sportowego

# Testowanie
W aplikacji jest wykonane testowanie kontrolera api sprz�tu sportowego.


# Rola admina
Administrator po zalogwaniu w zak�adce Sprz�t Sportowy mo�e doda�, usun�c lub edytowa� informacje na temat produkt�w.
Mo�e tak�e doda� nazwe firmy, kt�ra jest producentem danego produktu oraz promocje - jej nazw� oraz warto�� procentow� jaka jest do zaoferowania na dany sprz�t.


# Rola u�ytkownika
U�ytkownik mo�e utworzy� konto oraz przegl�da� informacj� na temat sprz�tu sportowego, firm oraz promocji.