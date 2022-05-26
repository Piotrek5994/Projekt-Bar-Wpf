create database Bar2

	CREATE TABLE [dbo].[Dostawcy](
	[ID] [int] PRIMARY KEY IDENTITY,
	[Nazwa] [nvarchar] (50) NOT NULL,
	[Adres] [nvarchar] (100) NOT NULL,
	[KodPocztowy] [nvarchar] (20) NULL,
	[Miasto] [nvarchar] (250) NULL,
	[Telefon] [nvarchar] (20) NULL,
	Email [nvarchar] (250) NULL)

	CREATE TABLE [dbo].[Alkohole](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Nazwa_Alkoholu] [nchar](40) NULL,
	[RodzajID] [int] NOT NULL,
	[Pojemnosc] [float] NOT NULL,
	[Cena] [decimal](18, 0) NOT NULL,
	[Procent] [int] NOT NULL,
	[Ilosc] [int] NULL,
	[DostawcaID] [int] NOT NULL)

	CREATE TABLE [dbo].[Rezerwacje](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[KlientID] [int] NOT NULL,
	[StolikID] [int] NOT NULL,
	[DataRezerwacji] [datetime] NOT NULL,
	[Termin] [datetime] NOT NULL,
	[Uwagi] [nvarchar](80) NULL)

	CREATE TABLE [dbo].[Klienci](
	[K_ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Imie] [nchar](20) NOT NULL,
	[Nazwisko] [nchar](30) NOT NULL,
	[Telefon] [nchar](12) NULL)

	CREATE TABLE [dbo].[Stoliki](
	[S_ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Stolik] [nchar](20) NOT NULL)

	CREATE TABLE [dbo].[RodzajAlkoholu](
	[R_ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Rodzaj] [nchar](40) NULL)

	CREATE TABLE [dbo].[Napoje](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Nazwa] [nchar](40) NOT NULL,
	[Pojemnosc] [float] NOT NULL,
	[Cena] [decimal](18, 0) NOT NULL,
	[Ilosc] [int] NOT NULL,
	[DostawcaID] [int] NULL)

	CREATE TABLE [dbo].[Syropy](
	[ID] [int] NOT NULL PRIMARY KEY IDENTITY,
	[Smak] [nchar](20) NOT NULL,
	[Pojemnosc] [float] NOT NULL,
	[Ilosc] [int] NOT NULL,
	[Cena] [int] NOT NULL,
	[DostawcaID] [int] NULL)

	CREATE TABLE [dbo].[Zamowienia](
	[Numer_Zamowienia] [nvarchar](50) NOT NULL,
	[Status_Zamowienia] [nvarchar](30) NOT NULL,
	[Data_Zamowienia] [date] NOT NULL,
	[Zamowiony_Alkohol] [int] NOT NULL,
	[Ilosc] [int] NOT NULL,
	[Dostawca] [int] NOT NULL)