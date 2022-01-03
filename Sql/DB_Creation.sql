Create Table Dane_Klientow  (
id_klienta int not null Identity(1,1) Primary Key,
Imie varchar(30) not null,
Numer_Tel varchar(12) not null
);

--drop table Rezerwacje
--drop table jachty

Create Table Jachty (
id_jachtu int not null Identity(1,1) Primary Key,
Nazwa varchar(40) not null,
Rodzaj varchar(15) not null,
Cena_Jedn int not null,
Constraint check_jacht Check (Cena_Jedn >0 AND (Rodzaj='Srodladowy' OR Rodzaj='Morski'))
);

/*
Create function Count_Total (@cena_jedn int, @lenght int)
Returns int
AS
	Select 
*/
--drop table Rezerwacje 

Create Table Rezerwacje  (
id_rezerwacji int not null Identity(1,1) Primary Key,
id_klienta int Foreign Key References Dane_Klientow(id_klienta),
id_jachtu int Foreign Key References Jachty(id_jachtu),
Data_Poczatek date,
Data_Koniec date,
Cena_Total int, -- as ([Jachty.Cena_Jedn] * (DateDiff(day, Data_Poczatek, Data_koniec)+1)) Persisted,
Cena_Zaliczka as (Cena_total/10),
Constraint SprawdzDaty Check (Data_Koniec > Data_Poczatek)
);

