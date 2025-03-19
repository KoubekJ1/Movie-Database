# Movie database

Program poskytující uživatelské rozhraní pro práci s SQL databází filmů

## Požadavky pro spuštění
Před spuštěním vytvořte na libovolném SQL serveru databázi vytvořenou pomocí SQL souboru "database creation.sql". Tento skript naleznete i na konci tohoto dokumentu. Aby program používal Vaši databázi, nastavte v konfiguračním souboru App.config informace o Vaší databázi. Pokud se programu nepodaří připojení k databázi, ukáže se hned po startu chybová hláška a program se ukončí.

### Konfigurační soubor
Konfigurační soubor je XML soubor, který Vám umožní upravit nastavení programu před jeho spuštěním. Jednotlivá nastavení jsou obklopena symboli "menší než" (<) a "větší než" (>). Název konkrétního nastavení se nachází v uvozovkách napravo od klíčového slova "key", následná samotná hodnota nastavení se nachází v uvozovkách napravo od klíčového slova "value".

#### DataSource
"DataSource" určuje název či adresu SQL serveru, na kterém se nachází Vaše databáze.

#### InitialCatalog
"InitialCatalog" určuje název konkrétní databáze, se kterou bude program pracovat.

#### IntegratedSecurity
"IntegratedSecurity" určuje, zda-li se pro přihlášení na SQL server použijí přihlašovací údaje uživatele přihlášeného do operačního systému Windows. Pokud je tato hodnota nastavena na "true", nemusí se nastavit hodnoty "UserID" a "Password".

#### UserID
"UserID" určuje jméno uživatele, které se použije při přihlášení na SQL server. Pokud je nastavena hodnota "IntegratedSecurity" na true, tato hodnota se nemusí specifikovat

#### Password
"UserID" určuje heslo uživatele, které se použije při přihlášení na SQL server. Pokud je nastavena hodnota "IntegratedSecurity" na true, tato hodnota se nemusí specifikovat

#### Nepovinná nastavení

Pro rychlý přístup lze nastavit v konfiguračním souboru přihlašovací údaje uživatele v databázi. Tyto přihlašovací údaje se ukládají automaticky po zaškrtnutí možnosti "Save password"

##### Username
"Username" určuje uživatelské jméno konkrétního uživatele v databázi. Toto slouží pro automatické přihlášení po spuštění programu.

##### Username
"User_Password" určuje uživatelské jméno konkrétního uživatele v databázi. Toto slouží pro automatické přihlášení po spuštění programu.

## Základní ovládání

### Přihlášení
Před vstupem do programu je nutné projít přihlašovacím dialogem, popřípadě se zaregistrovat. Přihlašovací údaje lze uložit do konfiguračního souboru, následně Vás program při každém dalším spuštění pustí rovnou s přihlašovacími údaji dále.

### Hlavní okno
Po průchodu přihlašovacím dialogem se ocitnete v hlavním okně programu. Lze můžete vyhledávat filmy, zobrazit si či upravit informace o konkrétním filmu, přidat nový film či film odebrat a přidávat filmy do Vašeho seznamu. Na levé straně obrazovky se nachází seznam filmů, který je z počátku prázdný a vyplní se až po vyhledání filmů v databázi. Na pravé straně obrazovky se nachází panel pro úpravu filmu. V horní liště se nachází možnost odhlásit se, přidat nový film do databáze či importovat/exportovat seznam filmů do souboru JSON.

#### Vyhledávání
Stiskem tlačítka "Search" se zobrazí okno vyhledávání. Vyhledávání slouží k vyhledávání filmů v databázi na základě určitých parametrů.

#### Váš seznam filmů
Pro zobrazení filmů, které jste si přidali do seznamu, stiskněte přepínač "My list". Tím se na seznamu filmů zobrazí filmy z Vašeho seznamu.

#### Úprava filmu
Po kliknutí na film v seznamu filmů se v panelu vpravo vyplní informace o filmu. Tyto informace lze upravit a následně uložit stiskem tlačítka "Save changes". Film je také možné smazat z databáze stiskem tlačítka "Delete". Film je také možné přidat do Vašeho seznamu filmů stiskem přepínače "Add to my list".

#### Přidání filmu
Po kliknutí na lištu "Add" a následně na tlačítko "New movie" lze přidat do databáze nový film. Po vyplnění informací stiskněte na tlačítko "Create" pro uložení nového filmu do databáze.

#### Import/Export do souboru JSON
Seznam filmů v databázi lze uložit do souboru JSON pomocí tlačítka "Export JSON" v liště Import/Export. Pro Import ze souboru JSON, použijte tlačítko "Import JSON". Tím se přidají do databáze všechny filmy v souboru.

## SQL Skript databáze

```
create table genres (
	id int identity(1,1) primary key,
	genre_name nvarchar(30) not null unique check(len(genre_name) > 0)
);

create table actors (
	id int identity(1,1) primary key,
	actor_name nvarchar(30) not null check(len(actor_name) > 0),
	actor_surname nvarchar(30) not null check(len(actor_surname) > 0)
);

create table movies (
	id int identity(1,1) primary key,
	movie_name nvarchar(30) not null check(len(movie_name) > 0),
	movie_description nvarchar(100) not null check(len(movie_description) > 0),
	release_date date not null check(release_date < getdate()),
	rating float default 0,

	check (rating >= 0 and rating <= 5)
);

create table movie_genres (
	id int identity(1,1) primary key,
	id_movie int not null,
	id_genre int not null,
	foreign key (id_movie) references movies (id) on delete cascade,
	foreign key (id_genre) references genres (id) on delete cascade
);

create table movie_actors (
	id int identity(1,1) primary key,
	id_movie int not null,
	id_actor int not null,
	foreign key (id_movie) references movies (id) on delete cascade,
	foreign key (id_actor) references actors (id) on delete cascade
);

create table users (
	id int identity(1,1) primary key,
	username nvarchar(30) not null unique check(len(username) > 0),
	password nvarchar(50) not null check(len(password) > 8), 
	first_name nvarchar(30) not null check(len(first_name) > 0),
	last_name nvarchar(30) not null check(len(last_name) > 0),
	date_of_birth date not null check(date_of_birth < getdate()),
	email nvarchar(320) not null check(email like '%@%.%'),
	country nvarchar(50) not null check(len(country) > 0),
);

create table list (
	id int identity(1,1) primary key,
	id_user int not null,
	id_movie int not null,
	foreign key (id_user) references users (id) on delete cascade,
	foreign key (id_movie) references movies (id) on delete cascade
);
```
