
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 10/24/2012 15:13:23
-- Generated from EDMX file: C:\Documents and Settings\Administrator\Moje dokumenty\Visual Studio 2010\Projects\faktury\faktury\faktury\Models\FakturyDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [FakturyDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Banki_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Banki] DROP CONSTRAINT [FK_Banki_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Banki_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Banki] DROP CONSTRAINT [FK_Banki_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_Banki_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Banki] DROP CONSTRAINT [FK_Banki_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_DanePrzedsiebiorstwa_KodyPocztowe2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DanePrzedsiebiorstwa] DROP CONSTRAINT [FK_DanePrzedsiebiorstwa_KodyPocztowe2];
GO
IF OBJECT_ID(N'[dbo].[FK_DanePrzedsiebiorstwa_KodyPocztowe3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DanePrzedsiebiorstwa] DROP CONSTRAINT [FK_DanePrzedsiebiorstwa_KodyPocztowe3];
GO
IF OBJECT_ID(N'[dbo].[FK_DanePrzedsiebiorstwa_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DanePrzedsiebiorstwa] DROP CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_DanePrzedsiebiorstwa_Uzytkownicy3]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DanePrzedsiebiorstwa] DROP CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy3];
GO
IF OBJECT_ID(N'[dbo].[FK_DanePrzedsiebiorstwa_Uzytkownicy4]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DanePrzedsiebiorstwa] DROP CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy4];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentyKupna_Dostawcy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentyKupna] DROP CONSTRAINT [FK_DokumentyKupna_Dostawcy];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentyKupna_FormyPlatnosci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentyKupna] DROP CONSTRAINT [FK_DokumentyKupna_FormyPlatnosci];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentyKupna_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentyKupna] DROP CONSTRAINT [FK_DokumentyKupna_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentyKupna_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentyKupna] DROP CONSTRAINT [FK_DokumentyKupna_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Banki]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Banki];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_FormyPlatnosci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_FormyPlatnosci];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Klienci1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Klienci1];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Kraje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Kraje];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Miejscowosci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Miejscowosci];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_DokumentySprzedazy_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DokumentySprzedazy] DROP CONSTRAINT [FK_DokumentySprzedazy_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_Dostawcy_KodyPocztowe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawcy] DROP CONSTRAINT [FK_Dostawcy_KodyPocztowe];
GO
IF OBJECT_ID(N'[dbo].[FK_Dostawcy_KodyPocztoweKontakt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawcy] DROP CONSTRAINT [FK_Dostawcy_KodyPocztoweKontakt];
GO
IF OBJECT_ID(N'[dbo].[FK_Dostawcy_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawcy] DROP CONSTRAINT [FK_Dostawcy_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Dostawcy_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Dostawcy] DROP CONSTRAINT [FK_Dostawcy_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_FormyPlatnosci_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormyPlatnosci] DROP CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_FormyPlatnosci_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormyPlatnosci] DROP CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_FormyPlatnosci_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormyPlatnosci] DROP CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_JednostkiMiar_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JednostkiMiar] DROP CONSTRAINT [FK_JednostkiMiar_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_JednostkiMiar_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JednostkiMiar] DROP CONSTRAINT [FK_JednostkiMiar_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_JednostkiMiar_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JednostkiMiar] DROP CONSTRAINT [FK_JednostkiMiar_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_Klienci_KodyPocztowe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klienci] DROP CONSTRAINT [FK_Klienci_KodyPocztowe];
GO
IF OBJECT_ID(N'[dbo].[FK_Klienci_KodyPocztoweKontakt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klienci] DROP CONSTRAINT [FK_Klienci_KodyPocztoweKontakt];
GO
IF OBJECT_ID(N'[dbo].[FK_Klienci_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klienci] DROP CONSTRAINT [FK_Klienci_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Klienci_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Klienci] DROP CONSTRAINT [FK_Klienci_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_KodyPocztowe_Miejscowosci]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KodyPocztowe] DROP CONSTRAINT [FK_KodyPocztowe_Miejscowosci];
GO
IF OBJECT_ID(N'[dbo].[FK_KodyPocztowe_UzytkownikBlokujacy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KodyPocztowe] DROP CONSTRAINT [FK_KodyPocztowe_UzytkownikBlokujacy];
GO
IF OBJECT_ID(N'[dbo].[FK_KodyPocztowe_UzytkownikModyfikujacy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KodyPocztowe] DROP CONSTRAINT [FK_KodyPocztowe_UzytkownikModyfikujacy];
GO
IF OBJECT_ID(N'[dbo].[FK_KodyPocztowe_UzytkownikWlasciciel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KodyPocztowe] DROP CONSTRAINT [FK_KodyPocztowe_UzytkownikWlasciciel];
GO
IF OBJECT_ID(N'[dbo].[FK_Kraje_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kraje] DROP CONSTRAINT [FK_Kraje_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Kraje_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kraje] DROP CONSTRAINT [FK_Kraje_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_Kraje_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Kraje] DROP CONSTRAINT [FK_Kraje_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_Miejscowosci_Kraje]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Miejscowosci] DROP CONSTRAINT [FK_Miejscowosci_Kraje];
GO
IF OBJECT_ID(N'[dbo].[FK_Miejscowosci_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Miejscowosci] DROP CONSTRAINT [FK_Miejscowosci_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_Miejscowosci_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Miejscowosci] DROP CONSTRAINT [FK_Miejscowosci_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_Miejscowosci_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Miejscowosci] DROP CONSTRAINT [FK_Miejscowosci_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturyKupna_DokumentyKupna]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturyKupna] DROP CONSTRAINT [FK_ProduktyFakturyKupna_DokumentyKupna];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturyKupna_TowaryUslugi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturyKupna] DROP CONSTRAINT [FK_ProduktyFakturyKupna_TowaryUslugi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturyKupna_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturyKupna] DROP CONSTRAINT [FK_ProduktyFakturyKupna_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturyKupna_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturyKupna] DROP CONSTRAINT [FK_ProduktyFakturyKupna_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturySprzedazy_DokumentySprzedazy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturySprzedazy] DROP CONSTRAINT [FK_ProduktyFakturySprzedazy_DokumentySprzedazy];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturySprzedazy_TowaryUslugi]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturySprzedazy] DROP CONSTRAINT [FK_ProduktyFakturySprzedazy_TowaryUslugi];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturySprzedazy_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturySprzedazy] DROP CONSTRAINT [FK_ProduktyFakturySprzedazy_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_ProduktyFakturySprzedazy_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProduktyFakturySprzedazy] DROP CONSTRAINT [FK_ProduktyFakturySprzedazy_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaKupna_DokumentyKupna]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaKupna] DROP CONSTRAINT [FK_RozliczeniaKupna_DokumentyKupna];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaKupna_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaKupna] DROP CONSTRAINT [FK_RozliczeniaKupna_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaKupna_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaKupna] DROP CONSTRAINT [FK_RozliczeniaKupna_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaSprzedazy_DokumentySprzedazy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaSprzedazy] DROP CONSTRAINT [FK_RozliczeniaSprzedazy_DokumentySprzedazy];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaSprzedazy_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaSprzedazy] DROP CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaSprzedazy_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaSprzedazy] DROP CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_RozliczeniaSprzedazy_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RozliczeniaSprzedazy] DROP CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_StawkiVat_Uzytkownicy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StawkiVat] DROP CONSTRAINT [FK_StawkiVat_Uzytkownicy];
GO
IF OBJECT_ID(N'[dbo].[FK_StawkiVat_Uzytkownicy1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StawkiVat] DROP CONSTRAINT [FK_StawkiVat_Uzytkownicy1];
GO
IF OBJECT_ID(N'[dbo].[FK_StawkiVat_Uzytkownicy2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StawkiVat] DROP CONSTRAINT [FK_StawkiVat_Uzytkownicy2];
GO
IF OBJECT_ID(N'[dbo].[FK_TowaryUslugi_JednostkiMiar]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TowaryUslugi] DROP CONSTRAINT [FK_TowaryUslugi_JednostkiMiar];
GO
IF OBJECT_ID(N'[dbo].[FK_TowaryUslugi_StawkiVat]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TowaryUslugi] DROP CONSTRAINT [FK_TowaryUslugi_StawkiVat];
GO
IF OBJECT_ID(N'[dbo].[FK_TowaryUslugi_UzytkownikBlokujacy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TowaryUslugi] DROP CONSTRAINT [FK_TowaryUslugi_UzytkownikBlokujacy];
GO
IF OBJECT_ID(N'[dbo].[FK_TowaryUslugi_UzytkownikWlasciciel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TowaryUslugi] DROP CONSTRAINT [FK_TowaryUslugi_UzytkownikWlasciciel];
GO
IF OBJECT_ID(N'[dbo].[FK_Uzytkownicy_Blokujacy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uzytkownicy] DROP CONSTRAINT [FK_Uzytkownicy_Blokujacy];
GO
IF OBJECT_ID(N'[dbo].[FK_Uzytkownicy_KodyPocztowe]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uzytkownicy] DROP CONSTRAINT [FK_Uzytkownicy_KodyPocztowe];
GO
IF OBJECT_ID(N'[dbo].[FK_Uzytkownicy_Modyfikujacy]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uzytkownicy] DROP CONSTRAINT [FK_Uzytkownicy_Modyfikujacy];
GO
IF OBJECT_ID(N'[dbo].[FK_Uzytkownicy_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uzytkownicy] DROP CONSTRAINT [FK_Uzytkownicy_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Uzytkownicy_Wlasciciel]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Uzytkownicy] DROP CONSTRAINT [FK_Uzytkownicy_Wlasciciel];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Banki]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Banki];
GO
IF OBJECT_ID(N'[dbo].[DanePrzedsiebiorstwa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DanePrzedsiebiorstwa];
GO
IF OBJECT_ID(N'[dbo].[DokumentyKupna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DokumentyKupna];
GO
IF OBJECT_ID(N'[dbo].[DokumentySprzedazy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DokumentySprzedazy];
GO
IF OBJECT_ID(N'[dbo].[Dostawcy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Dostawcy];
GO
IF OBJECT_ID(N'[dbo].[FormyPlatnosci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormyPlatnosci];
GO
IF OBJECT_ID(N'[dbo].[JednostkiMiar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JednostkiMiar];
GO
IF OBJECT_ID(N'[dbo].[Klienci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klienci];
GO
IF OBJECT_ID(N'[dbo].[KodyPocztowe]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KodyPocztowe];
GO
IF OBJECT_ID(N'[dbo].[Kraje]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Kraje];
GO
IF OBJECT_ID(N'[dbo].[Miejscowosci]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Miejscowosci];
GO
IF OBJECT_ID(N'[dbo].[ProduktyFakturyKupna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProduktyFakturyKupna];
GO
IF OBJECT_ID(N'[dbo].[ProduktyFakturySprzedazy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProduktyFakturySprzedazy];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[RozliczeniaKupna]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RozliczeniaKupna];
GO
IF OBJECT_ID(N'[dbo].[RozliczeniaSprzedazy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RozliczeniaSprzedazy];
GO
IF OBJECT_ID(N'[dbo].[StawkiVat]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StawkiVat];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TowaryUslugi]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TowaryUslugi];
GO
IF OBJECT_ID(N'[dbo].[Uzytkownicy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uzytkownicy];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Banki'
CREATE TABLE [dbo].[Banki] (
    [BankID] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(32)  NOT NULL,
    [NrBanku] nvarchar(64)  NOT NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL
);
GO

-- Creating table 'DanePrzedsiebiorstwa'
CREATE TABLE [dbo].[DanePrzedsiebiorstwa] (
    [DanePrzedsiebiorstwaID] int  NOT NULL,
    [Nazwa] nvarchar(32)  NULL,
    [Imie] nvarchar(16)  NULL,
    [Nazwisko] nvarchar(32)  NULL,
    [Ulica] nvarchar(64)  NULL,
    [NrDomu] nvarchar(8)  NOT NULL,
    [NrMieszkania] nvarchar(8)  NULL,
    [KodPocztowyID] int  NOT NULL,
    [UlicaKontakt] nvarchar(64)  NULL,
    [NrDomuKontakt] nvarchar(8)  NULL,
    [NrMieszkaniaKontakt] nvarchar(8)  NULL,
    [KodPocztowyKontaktID] int  NULL,
    [Nip] nvarchar(16)  NULL,
    [Regon] nvarchar(16)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [Email] nvarchar(128)  NULL,
    [Www] nvarchar(128)  NULL,
    [Telefon] nvarchar(16)  NULL,
    [Telefon2] nvarchar(16)  NULL,
    [Fax] nvarchar(16)  NULL
);
GO

-- Creating table 'DokumentyKupna'
CREATE TABLE [dbo].[DokumentyKupna] (
    [DokumentKupnaID] int IDENTITY(1,1) NOT NULL,
    [NrDokumentu] nvarchar(64)  NOT NULL,
    [DataWystawienia] datetime  NOT NULL,
    [DataSprzedazy] datetime  NOT NULL,
    [DostawcaID] int  NOT NULL,
    [FormaPlatnosciID] int  NOT NULL,
    [TerminPlatnosci] datetime  NOT NULL,
    [WartoscNetto] decimal(9,2)  NULL,
    [WartoscBrutto] decimal(9,2)  NULL,
    [PozostaloDoZaplaty] decimal(9,2)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL
);
GO

-- Creating table 'DokumentySprzedazy'
CREATE TABLE [dbo].[DokumentySprzedazy] (
    [DokumentSprzedazyID] int IDENTITY(1,1) NOT NULL,
    [TypDokumentu] nvarchar(16)  NOT NULL,
    [NrDokumentu] nvarchar(32)  NOT NULL,
    [KlientID] int  NOT NULL,
    [MiejscowoscID] int  NOT NULL,
    [KrajID] int  NOT NULL,
    [BankID] int  NOT NULL,
    [FormaPlatnosciID] int  NOT NULL,
    [DataWystawienia] datetime  NOT NULL,
    [DataSprzedazy] datetime  NOT NULL,
    [TerminPlatnosci] datetime  NOT NULL,
    [WartoscNetto] decimal(9,2)  NULL,
    [WartoscBrutto] decimal(9,2)  NULL,
    [PozostaloDoZaplaty] decimal(9,2)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL
);
GO

-- Creating table 'Dostawcy'
CREATE TABLE [dbo].[Dostawcy] (
    [DostawcaID] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(16)  NULL,
    [Nazwisko] nvarchar(32)  NULL,
    [Nazwa] nvarchar(32)  NULL,
    [Ulica] nvarchar(64)  NOT NULL,
    [NrDomu] nvarchar(8)  NOT NULL,
    [NrMieszkania] nvarchar(8)  NULL,
    [KodPocztowyID] int  NOT NULL,
    [ImieKontakt] nvarchar(16)  NULL,
    [NazwiskoKontakt] nvarchar(32)  NULL,
    [UlicaKontakt] nvarchar(64)  NULL,
    [NrDomuKontakt] nvarchar(8)  NULL,
    [NrMieszkaniaKontakt] nvarchar(8)  NULL,
    [KodPocztowyKontaktID] int  NULL,
    [Nip] nvarchar(16)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [Email] nvarchar(128)  NULL,
    [Telefon] nvarchar(16)  NULL,
    [Telefon2] nvarchar(16)  NULL,
    [Bank] nvarchar(16)  NULL,
    [NrBanku] nvarchar(32)  NULL
);
GO

-- Creating table 'FormyPlatnosci'
CREATE TABLE [dbo].[FormyPlatnosci] (
    [FormaPlatnosciID] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(16)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL
);
GO

-- Creating table 'JednostkiMiar'
CREATE TABLE [dbo].[JednostkiMiar] (
    [JednostkaMiarID] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(16)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL
);
GO

-- Creating table 'Klienci'
CREATE TABLE [dbo].[Klienci] (
    [KlientID] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(16)  NULL,
    [Nazwisko] nvarchar(32)  NULL,
    [Nazwa] nvarchar(32)  NULL,
    [Ulica] nvarchar(64)  NOT NULL,
    [NrDomu] nvarchar(8)  NOT NULL,
    [NrMieszkania] nvarchar(8)  NULL,
    [KodPocztowyID] int  NOT NULL,
    [ImieKontakt] nvarchar(16)  NULL,
    [NazwiskoKontakt] nvarchar(32)  NULL,
    [UlicaKontakt] nvarchar(64)  NULL,
    [NrDomuKontakt] nvarchar(8)  NULL,
    [NrMieszkaniaKontakt] nvarchar(8)  NULL,
    [KodPocztowyKontaktID] int  NULL,
    [Nip] nvarchar(16)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [Email] nvarchar(64)  NULL,
    [Telefon] nvarchar(16)  NULL,
    [Telefon2] nvarchar(16)  NULL
);
GO

-- Creating table 'KodyPocztowe'
CREATE TABLE [dbo].[KodyPocztowe] (
    [KodPocztowyID] int IDENTITY(1,1) NOT NULL,
    [Kod] nvarchar(8)  NOT NULL,
    [MiejscowoscID] int  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL
);
GO

-- Creating table 'Kraje'
CREATE TABLE [dbo].[Kraje] (
    [KrajID] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(64)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [Waluta] nvarchar(32)  NOT NULL,
    [WalutaSkrot] nvarchar(8)  NOT NULL
);
GO

-- Creating table 'Miejscowosci'
CREATE TABLE [dbo].[Miejscowosci] (
    [MiejscowoscID] int IDENTITY(1,1) NOT NULL,
    [Nazwa] nvarchar(64)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [KrajID] int  NOT NULL
);
GO

-- Creating table 'ProduktyFakturyKupna'
CREATE TABLE [dbo].[ProduktyFakturyKupna] (
    [ProduktFakturyKupnaID] int IDENTITY(1,1) NOT NULL,
    [DokumentKupnaID] int  NOT NULL,
    [TowarID] int  NOT NULL,
    [Ilosc] decimal(8,2)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [WartoscNetto] decimal(9,2)  NULL,
    [WartoscBrutto] decimal(9,2)  NULL
);
GO

-- Creating table 'ProduktyFakturySprzedazy'
CREATE TABLE [dbo].[ProduktyFakturySprzedazy] (
    [ProduktFakturySprzedazyID] int IDENTITY(1,1) NOT NULL,
    [DokumentSprzedazyID] int  NOT NULL,
    [TowarID] int  NOT NULL,
    [Ilosc] decimal(8,2)  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [WartoscNetto] decimal(9,2)  NULL,
    [WartoscBrutto] decimal(9,2)  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RolaID] int  NOT NULL,
    [Nazwa] nvarchar(16)  NULL
);
GO

-- Creating table 'RozliczeniaKupna'
CREATE TABLE [dbo].[RozliczeniaKupna] (
    [RozliczenieKupnaID] int IDENTITY(1,1) NOT NULL,
    [DokumentKupnaID] int  NOT NULL,
    [Kwota] decimal(8,2)  NOT NULL,
    [DataZaplaty] datetime  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL
);
GO

-- Creating table 'RozliczeniaSprzedazy'
CREATE TABLE [dbo].[RozliczeniaSprzedazy] (
    [RozliczenieSprzedazyID] int IDENTITY(1,1) NOT NULL,
    [DokumentSprzedazyID] int  NOT NULL,
    [Kwota] decimal(19,4)  NOT NULL,
    [DataWplaty] datetime  NOT NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL
);
GO

-- Creating table 'StawkiVat'
CREATE TABLE [dbo].[StawkiVat] (
    [StawkaVatID] int IDENTITY(1,1) NOT NULL,
    [Wartosc] int  NOT NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TowaryUslugi'
CREATE TABLE [dbo].[TowaryUslugi] (
    [TowarID] int IDENTITY(1,1) NOT NULL,
    [Rodzaj] nvarchar(8)  NOT NULL,
    [Nazwa] nvarchar(64)  NOT NULL,
    [CenaNetto] decimal(19,2)  NULL,
    [CenaBrutto] decimal(19,2)  NULL,
    [Marza] decimal(8,2)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NOT NULL,
    [DataWprowadzenia] datetime  NOT NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [JednostkaMiarID] int  NOT NULL,
    [StawkaVatID] int  NOT NULL
);
GO

-- Creating table 'Uzytkownicy'
CREATE TABLE [dbo].[Uzytkownicy] (
    [UzytkownikID] int IDENTITY(1,1) NOT NULL,
    [Imie] nvarchar(16)  NOT NULL,
    [Nazwisko] nvarchar(32)  NOT NULL,
    [Ulica] nvarchar(64)  NULL,
    [NrDomu] nvarchar(8)  NULL,
    [NrMieszkania] nvarchar(8)  NULL,
    [KodPocztowyID] int  NULL,
    [Nip] nvarchar(16)  NULL,
    [Pesel] nvarchar(16)  NULL,
    [Uwagi] nvarchar(max)  NULL,
    [WlascicielID] int  NULL,
    [DataWprowadzenia] datetime  NULL,
    [ModyfikujacyID] int  NULL,
    [DataModyfikacji] datetime  NULL,
    [Email] nvarchar(128)  NULL,
    [BlokujacyID] int  NULL,
    [DataZablokowania] datetime  NULL,
    [Haslo] nvarchar(128)  NULL,
    [HasloSzum] nvarchar(128)  NULL,
    [RolaID] int  NULL,
    [Login] nvarchar(16)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BankID] in table 'Banki'
ALTER TABLE [dbo].[Banki]
ADD CONSTRAINT [PK_Banki]
    PRIMARY KEY CLUSTERED ([BankID] ASC);
GO

-- Creating primary key on [DanePrzedsiebiorstwaID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [PK_DanePrzedsiebiorstwa]
    PRIMARY KEY CLUSTERED ([DanePrzedsiebiorstwaID] ASC);
GO

-- Creating primary key on [DokumentKupnaID] in table 'DokumentyKupna'
ALTER TABLE [dbo].[DokumentyKupna]
ADD CONSTRAINT [PK_DokumentyKupna]
    PRIMARY KEY CLUSTERED ([DokumentKupnaID] ASC);
GO

-- Creating primary key on [DokumentSprzedazyID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [PK_DokumentySprzedazy]
    PRIMARY KEY CLUSTERED ([DokumentSprzedazyID] ASC);
GO

-- Creating primary key on [DostawcaID] in table 'Dostawcy'
ALTER TABLE [dbo].[Dostawcy]
ADD CONSTRAINT [PK_Dostawcy]
    PRIMARY KEY CLUSTERED ([DostawcaID] ASC);
GO

-- Creating primary key on [FormaPlatnosciID] in table 'FormyPlatnosci'
ALTER TABLE [dbo].[FormyPlatnosci]
ADD CONSTRAINT [PK_FormyPlatnosci]
    PRIMARY KEY CLUSTERED ([FormaPlatnosciID] ASC);
GO

-- Creating primary key on [JednostkaMiarID] in table 'JednostkiMiar'
ALTER TABLE [dbo].[JednostkiMiar]
ADD CONSTRAINT [PK_JednostkiMiar]
    PRIMARY KEY CLUSTERED ([JednostkaMiarID] ASC);
GO

-- Creating primary key on [KlientID] in table 'Klienci'
ALTER TABLE [dbo].[Klienci]
ADD CONSTRAINT [PK_Klienci]
    PRIMARY KEY CLUSTERED ([KlientID] ASC);
GO

-- Creating primary key on [KodPocztowyID] in table 'KodyPocztowe'
ALTER TABLE [dbo].[KodyPocztowe]
ADD CONSTRAINT [PK_KodyPocztowe]
    PRIMARY KEY CLUSTERED ([KodPocztowyID] ASC);
GO

-- Creating primary key on [KrajID] in table 'Kraje'
ALTER TABLE [dbo].[Kraje]
ADD CONSTRAINT [PK_Kraje]
    PRIMARY KEY CLUSTERED ([KrajID] ASC);
GO

-- Creating primary key on [MiejscowoscID] in table 'Miejscowosci'
ALTER TABLE [dbo].[Miejscowosci]
ADD CONSTRAINT [PK_Miejscowosci]
    PRIMARY KEY CLUSTERED ([MiejscowoscID] ASC);
GO

-- Creating primary key on [ProduktFakturyKupnaID] in table 'ProduktyFakturyKupna'
ALTER TABLE [dbo].[ProduktyFakturyKupna]
ADD CONSTRAINT [PK_ProduktyFakturyKupna]
    PRIMARY KEY CLUSTERED ([ProduktFakturyKupnaID] ASC);
GO

-- Creating primary key on [ProduktFakturySprzedazyID] in table 'ProduktyFakturySprzedazy'
ALTER TABLE [dbo].[ProduktyFakturySprzedazy]
ADD CONSTRAINT [PK_ProduktyFakturySprzedazy]
    PRIMARY KEY CLUSTERED ([ProduktFakturySprzedazyID] ASC);
GO

-- Creating primary key on [RolaID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RolaID] ASC);
GO

-- Creating primary key on [RozliczenieKupnaID] in table 'RozliczeniaKupna'
ALTER TABLE [dbo].[RozliczeniaKupna]
ADD CONSTRAINT [PK_RozliczeniaKupna]
    PRIMARY KEY CLUSTERED ([RozliczenieKupnaID] ASC);
GO

-- Creating primary key on [RozliczenieSprzedazyID] in table 'RozliczeniaSprzedazy'
ALTER TABLE [dbo].[RozliczeniaSprzedazy]
ADD CONSTRAINT [PK_RozliczeniaSprzedazy]
    PRIMARY KEY CLUSTERED ([RozliczenieSprzedazyID] ASC);
GO

-- Creating primary key on [StawkaVatID] in table 'StawkiVat'
ALTER TABLE [dbo].[StawkiVat]
ADD CONSTRAINT [PK_StawkiVat]
    PRIMARY KEY CLUSTERED ([StawkaVatID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [TowarID] in table 'TowaryUslugi'
ALTER TABLE [dbo].[TowaryUslugi]
ADD CONSTRAINT [PK_TowaryUslugi]
    PRIMARY KEY CLUSTERED ([TowarID] ASC);
GO

-- Creating primary key on [UzytkownikID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [PK_Uzytkownicy]
    PRIMARY KEY CLUSTERED ([UzytkownikID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [WlascicielID] in table 'Banki'
ALTER TABLE [dbo].[Banki]
ADD CONSTRAINT [FK_Banki_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Banki_Uzytkownicy'
CREATE INDEX [IX_FK_Banki_Uzytkownicy]
ON [dbo].[Banki]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'Banki'
ALTER TABLE [dbo].[Banki]
ADD CONSTRAINT [FK_Banki_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Banki_Uzytkownicy1'
CREATE INDEX [IX_FK_Banki_Uzytkownicy1]
ON [dbo].[Banki]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Banki'
ALTER TABLE [dbo].[Banki]
ADD CONSTRAINT [FK_Banki_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Banki_Uzytkownicy2'
CREATE INDEX [IX_FK_Banki_Uzytkownicy2]
ON [dbo].[Banki]
    ([BlokujacyID]);
GO

-- Creating foreign key on [BankID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Banki]
    FOREIGN KEY ([BankID])
    REFERENCES [dbo].[Banki]
        ([BankID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Banki'
CREATE INDEX [IX_FK_DokumentySprzedazy_Banki]
ON [dbo].[DokumentySprzedazy]
    ([BankID]);
GO

-- Creating foreign key on [KodPocztowyID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [FK_DanePrzedsiebiorstwa_KodyPocztowe2]
    FOREIGN KEY ([KodPocztowyID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DanePrzedsiebiorstwa_KodyPocztowe2'
CREATE INDEX [IX_FK_DanePrzedsiebiorstwa_KodyPocztowe2]
ON [dbo].[DanePrzedsiebiorstwa]
    ([KodPocztowyID]);
GO

-- Creating foreign key on [KodPocztowyKontaktID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [FK_DanePrzedsiebiorstwa_KodyPocztowe3]
    FOREIGN KEY ([KodPocztowyKontaktID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DanePrzedsiebiorstwa_KodyPocztowe3'
CREATE INDEX [IX_FK_DanePrzedsiebiorstwa_KodyPocztowe3]
ON [dbo].[DanePrzedsiebiorstwa]
    ([KodPocztowyKontaktID]);
GO

-- Creating foreign key on [WlascicielID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy2]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DanePrzedsiebiorstwa_Uzytkownicy2'
CREATE INDEX [IX_FK_DanePrzedsiebiorstwa_Uzytkownicy2]
ON [dbo].[DanePrzedsiebiorstwa]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy3]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DanePrzedsiebiorstwa_Uzytkownicy3'
CREATE INDEX [IX_FK_DanePrzedsiebiorstwa_Uzytkownicy3]
ON [dbo].[DanePrzedsiebiorstwa]
    ([BlokujacyID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'DanePrzedsiebiorstwa'
ALTER TABLE [dbo].[DanePrzedsiebiorstwa]
ADD CONSTRAINT [FK_DanePrzedsiebiorstwa_Uzytkownicy4]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DanePrzedsiebiorstwa_Uzytkownicy4'
CREATE INDEX [IX_FK_DanePrzedsiebiorstwa_Uzytkownicy4]
ON [dbo].[DanePrzedsiebiorstwa]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [DostawcaID] in table 'DokumentyKupna'
ALTER TABLE [dbo].[DokumentyKupna]
ADD CONSTRAINT [FK_DokumentyKupna_Dostawcy]
    FOREIGN KEY ([DostawcaID])
    REFERENCES [dbo].[Dostawcy]
        ([DostawcaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentyKupna_Dostawcy'
CREATE INDEX [IX_FK_DokumentyKupna_Dostawcy]
ON [dbo].[DokumentyKupna]
    ([DostawcaID]);
GO

-- Creating foreign key on [FormaPlatnosciID] in table 'DokumentyKupna'
ALTER TABLE [dbo].[DokumentyKupna]
ADD CONSTRAINT [FK_DokumentyKupna_FormyPlatnosci]
    FOREIGN KEY ([FormaPlatnosciID])
    REFERENCES [dbo].[FormyPlatnosci]
        ([FormaPlatnosciID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentyKupna_FormyPlatnosci'
CREATE INDEX [IX_FK_DokumentyKupna_FormyPlatnosci]
ON [dbo].[DokumentyKupna]
    ([FormaPlatnosciID]);
GO

-- Creating foreign key on [WlascicielID] in table 'DokumentyKupna'
ALTER TABLE [dbo].[DokumentyKupna]
ADD CONSTRAINT [FK_DokumentyKupna_Uzytkownicy1]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentyKupna_Uzytkownicy1'
CREATE INDEX [IX_FK_DokumentyKupna_Uzytkownicy1]
ON [dbo].[DokumentyKupna]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'DokumentyKupna'
ALTER TABLE [dbo].[DokumentyKupna]
ADD CONSTRAINT [FK_DokumentyKupna_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentyKupna_Uzytkownicy2'
CREATE INDEX [IX_FK_DokumentyKupna_Uzytkownicy2]
ON [dbo].[DokumentyKupna]
    ([BlokujacyID]);
GO

-- Creating foreign key on [DokumentKupnaID] in table 'ProduktyFakturyKupna'
ALTER TABLE [dbo].[ProduktyFakturyKupna]
ADD CONSTRAINT [FK_ProduktyFakturyKupna_DokumentyKupna]
    FOREIGN KEY ([DokumentKupnaID])
    REFERENCES [dbo].[DokumentyKupna]
        ([DokumentKupnaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturyKupna_DokumentyKupna'
CREATE INDEX [IX_FK_ProduktyFakturyKupna_DokumentyKupna]
ON [dbo].[ProduktyFakturyKupna]
    ([DokumentKupnaID]);
GO

-- Creating foreign key on [DokumentKupnaID] in table 'RozliczeniaKupna'
ALTER TABLE [dbo].[RozliczeniaKupna]
ADD CONSTRAINT [FK_RozliczeniaKupna_DokumentyKupna]
    FOREIGN KEY ([DokumentKupnaID])
    REFERENCES [dbo].[DokumentyKupna]
        ([DokumentKupnaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaKupna_DokumentyKupna'
CREATE INDEX [IX_FK_RozliczeniaKupna_DokumentyKupna]
ON [dbo].[RozliczeniaKupna]
    ([DokumentKupnaID]);
GO

-- Creating foreign key on [FormaPlatnosciID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_FormyPlatnosci]
    FOREIGN KEY ([FormaPlatnosciID])
    REFERENCES [dbo].[FormyPlatnosci]
        ([FormaPlatnosciID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_FormyPlatnosci'
CREATE INDEX [IX_FK_DokumentySprzedazy_FormyPlatnosci]
ON [dbo].[DokumentySprzedazy]
    ([FormaPlatnosciID]);
GO

-- Creating foreign key on [KlientID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Klienci1]
    FOREIGN KEY ([KlientID])
    REFERENCES [dbo].[Klienci]
        ([KlientID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Klienci1'
CREATE INDEX [IX_FK_DokumentySprzedazy_Klienci1]
ON [dbo].[DokumentySprzedazy]
    ([KlientID]);
GO

-- Creating foreign key on [KrajID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Kraje]
    FOREIGN KEY ([KrajID])
    REFERENCES [dbo].[Kraje]
        ([KrajID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Kraje'
CREATE INDEX [IX_FK_DokumentySprzedazy_Kraje]
ON [dbo].[DokumentySprzedazy]
    ([KrajID]);
GO

-- Creating foreign key on [MiejscowoscID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Miejscowosci]
    FOREIGN KEY ([MiejscowoscID])
    REFERENCES [dbo].[Miejscowosci]
        ([MiejscowoscID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Miejscowosci'
CREATE INDEX [IX_FK_DokumentySprzedazy_Miejscowosci]
ON [dbo].[DokumentySprzedazy]
    ([MiejscowoscID]);
GO

-- Creating foreign key on [WlascicielID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Uzytkownicy'
CREATE INDEX [IX_FK_DokumentySprzedazy_Uzytkownicy]
ON [dbo].[DokumentySprzedazy]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'DokumentySprzedazy'
ALTER TABLE [dbo].[DokumentySprzedazy]
ADD CONSTRAINT [FK_DokumentySprzedazy_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DokumentySprzedazy_Uzytkownicy1'
CREATE INDEX [IX_FK_DokumentySprzedazy_Uzytkownicy1]
ON [dbo].[DokumentySprzedazy]
    ([BlokujacyID]);
GO

-- Creating foreign key on [DokumentSprzedazyID] in table 'ProduktyFakturySprzedazy'
ALTER TABLE [dbo].[ProduktyFakturySprzedazy]
ADD CONSTRAINT [FK_ProduktyFakturySprzedazy_DokumentySprzedazy]
    FOREIGN KEY ([DokumentSprzedazyID])
    REFERENCES [dbo].[DokumentySprzedazy]
        ([DokumentSprzedazyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturySprzedazy_DokumentySprzedazy'
CREATE INDEX [IX_FK_ProduktyFakturySprzedazy_DokumentySprzedazy]
ON [dbo].[ProduktyFakturySprzedazy]
    ([DokumentSprzedazyID]);
GO

-- Creating foreign key on [DokumentSprzedazyID] in table 'RozliczeniaSprzedazy'
ALTER TABLE [dbo].[RozliczeniaSprzedazy]
ADD CONSTRAINT [FK_RozliczeniaSprzedazy_DokumentySprzedazy]
    FOREIGN KEY ([DokumentSprzedazyID])
    REFERENCES [dbo].[DokumentySprzedazy]
        ([DokumentSprzedazyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaSprzedazy_DokumentySprzedazy'
CREATE INDEX [IX_FK_RozliczeniaSprzedazy_DokumentySprzedazy]
ON [dbo].[RozliczeniaSprzedazy]
    ([DokumentSprzedazyID]);
GO

-- Creating foreign key on [KodPocztowyID] in table 'Dostawcy'
ALTER TABLE [dbo].[Dostawcy]
ADD CONSTRAINT [FK_Dostawcy_KodyPocztowe]
    FOREIGN KEY ([KodPocztowyID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dostawcy_KodyPocztowe'
CREATE INDEX [IX_FK_Dostawcy_KodyPocztowe]
ON [dbo].[Dostawcy]
    ([KodPocztowyID]);
GO

-- Creating foreign key on [KodPocztowyKontaktID] in table 'Dostawcy'
ALTER TABLE [dbo].[Dostawcy]
ADD CONSTRAINT [FK_Dostawcy_KodyPocztoweKontakt]
    FOREIGN KEY ([KodPocztowyKontaktID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dostawcy_KodyPocztoweKontakt'
CREATE INDEX [IX_FK_Dostawcy_KodyPocztoweKontakt]
ON [dbo].[Dostawcy]
    ([KodPocztowyKontaktID]);
GO

-- Creating foreign key on [WlascicielID] in table 'Dostawcy'
ALTER TABLE [dbo].[Dostawcy]
ADD CONSTRAINT [FK_Dostawcy_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dostawcy_Uzytkownicy'
CREATE INDEX [IX_FK_Dostawcy_Uzytkownicy]
ON [dbo].[Dostawcy]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Dostawcy'
ALTER TABLE [dbo].[Dostawcy]
ADD CONSTRAINT [FK_Dostawcy_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Dostawcy_Uzytkownicy1'
CREATE INDEX [IX_FK_Dostawcy_Uzytkownicy1]
ON [dbo].[Dostawcy]
    ([BlokujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'FormyPlatnosci'
ALTER TABLE [dbo].[FormyPlatnosci]
ADD CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormyPlatnosci_Uzytkownicy'
CREATE INDEX [IX_FK_FormyPlatnosci_Uzytkownicy]
ON [dbo].[FormyPlatnosci]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'FormyPlatnosci'
ALTER TABLE [dbo].[FormyPlatnosci]
ADD CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormyPlatnosci_Uzytkownicy1'
CREATE INDEX [IX_FK_FormyPlatnosci_Uzytkownicy1]
ON [dbo].[FormyPlatnosci]
    ([BlokujacyID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'FormyPlatnosci'
ALTER TABLE [dbo].[FormyPlatnosci]
ADD CONSTRAINT [FK_FormyPlatnosci_Uzytkownicy2]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FormyPlatnosci_Uzytkownicy2'
CREATE INDEX [IX_FK_FormyPlatnosci_Uzytkownicy2]
ON [dbo].[FormyPlatnosci]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'JednostkiMiar'
ALTER TABLE [dbo].[JednostkiMiar]
ADD CONSTRAINT [FK_JednostkiMiar_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JednostkiMiar_Uzytkownicy'
CREATE INDEX [IX_FK_JednostkiMiar_Uzytkownicy]
ON [dbo].[JednostkiMiar]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'JednostkiMiar'
ALTER TABLE [dbo].[JednostkiMiar]
ADD CONSTRAINT [FK_JednostkiMiar_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JednostkiMiar_Uzytkownicy1'
CREATE INDEX [IX_FK_JednostkiMiar_Uzytkownicy1]
ON [dbo].[JednostkiMiar]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'JednostkiMiar'
ALTER TABLE [dbo].[JednostkiMiar]
ADD CONSTRAINT [FK_JednostkiMiar_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_JednostkiMiar_Uzytkownicy2'
CREATE INDEX [IX_FK_JednostkiMiar_Uzytkownicy2]
ON [dbo].[JednostkiMiar]
    ([BlokujacyID]);
GO

-- Creating foreign key on [JednostkaMiarID] in table 'TowaryUslugi'
ALTER TABLE [dbo].[TowaryUslugi]
ADD CONSTRAINT [FK_TowaryUslugi_JednostkiMiar]
    FOREIGN KEY ([JednostkaMiarID])
    REFERENCES [dbo].[JednostkiMiar]
        ([JednostkaMiarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TowaryUslugi_JednostkiMiar'
CREATE INDEX [IX_FK_TowaryUslugi_JednostkiMiar]
ON [dbo].[TowaryUslugi]
    ([JednostkaMiarID]);
GO

-- Creating foreign key on [KodPocztowyID] in table 'Klienci'
ALTER TABLE [dbo].[Klienci]
ADD CONSTRAINT [FK_Klienci_KodyPocztowe]
    FOREIGN KEY ([KodPocztowyID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Klienci_KodyPocztowe'
CREATE INDEX [IX_FK_Klienci_KodyPocztowe]
ON [dbo].[Klienci]
    ([KodPocztowyID]);
GO

-- Creating foreign key on [KodPocztowyKontaktID] in table 'Klienci'
ALTER TABLE [dbo].[Klienci]
ADD CONSTRAINT [FK_Klienci_KodyPocztoweKontakt]
    FOREIGN KEY ([KodPocztowyKontaktID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Klienci_KodyPocztoweKontakt'
CREATE INDEX [IX_FK_Klienci_KodyPocztoweKontakt]
ON [dbo].[Klienci]
    ([KodPocztowyKontaktID]);
GO

-- Creating foreign key on [WlascicielID] in table 'Klienci'
ALTER TABLE [dbo].[Klienci]
ADD CONSTRAINT [FK_Klienci_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Klienci_Uzytkownicy'
CREATE INDEX [IX_FK_Klienci_Uzytkownicy]
ON [dbo].[Klienci]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Klienci'
ALTER TABLE [dbo].[Klienci]
ADD CONSTRAINT [FK_Klienci_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Klienci_Uzytkownicy1'
CREATE INDEX [IX_FK_Klienci_Uzytkownicy1]
ON [dbo].[Klienci]
    ([BlokujacyID]);
GO

-- Creating foreign key on [MiejscowoscID] in table 'KodyPocztowe'
ALTER TABLE [dbo].[KodyPocztowe]
ADD CONSTRAINT [FK_KodyPocztowe_Miejscowosci]
    FOREIGN KEY ([MiejscowoscID])
    REFERENCES [dbo].[Miejscowosci]
        ([MiejscowoscID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KodyPocztowe_Miejscowosci'
CREATE INDEX [IX_FK_KodyPocztowe_Miejscowosci]
ON [dbo].[KodyPocztowe]
    ([MiejscowoscID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'KodyPocztowe'
ALTER TABLE [dbo].[KodyPocztowe]
ADD CONSTRAINT [FK_KodyPocztowe_UzytkownikBlokujacy]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KodyPocztowe_UzytkownikBlokujacy'
CREATE INDEX [IX_FK_KodyPocztowe_UzytkownikBlokujacy]
ON [dbo].[KodyPocztowe]
    ([BlokujacyID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'KodyPocztowe'
ALTER TABLE [dbo].[KodyPocztowe]
ADD CONSTRAINT [FK_KodyPocztowe_UzytkownikModyfikujacy]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KodyPocztowe_UzytkownikModyfikujacy'
CREATE INDEX [IX_FK_KodyPocztowe_UzytkownikModyfikujacy]
ON [dbo].[KodyPocztowe]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'KodyPocztowe'
ALTER TABLE [dbo].[KodyPocztowe]
ADD CONSTRAINT [FK_KodyPocztowe_UzytkownikWlasciciel]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_KodyPocztowe_UzytkownikWlasciciel'
CREATE INDEX [IX_FK_KodyPocztowe_UzytkownikWlasciciel]
ON [dbo].[KodyPocztowe]
    ([WlascicielID]);
GO

-- Creating foreign key on [KodPocztowyID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [FK_Uzytkownicy_KodyPocztowe]
    FOREIGN KEY ([KodPocztowyID])
    REFERENCES [dbo].[KodyPocztowe]
        ([KodPocztowyID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Uzytkownicy_KodyPocztowe'
CREATE INDEX [IX_FK_Uzytkownicy_KodyPocztowe]
ON [dbo].[Uzytkownicy]
    ([KodPocztowyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'Kraje'
ALTER TABLE [dbo].[Kraje]
ADD CONSTRAINT [FK_Kraje_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Kraje_Uzytkownicy'
CREATE INDEX [IX_FK_Kraje_Uzytkownicy]
ON [dbo].[Kraje]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'Kraje'
ALTER TABLE [dbo].[Kraje]
ADD CONSTRAINT [FK_Kraje_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Kraje_Uzytkownicy1'
CREATE INDEX [IX_FK_Kraje_Uzytkownicy1]
ON [dbo].[Kraje]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Kraje'
ALTER TABLE [dbo].[Kraje]
ADD CONSTRAINT [FK_Kraje_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Kraje_Uzytkownicy2'
CREATE INDEX [IX_FK_Kraje_Uzytkownicy2]
ON [dbo].[Kraje]
    ([BlokujacyID]);
GO

-- Creating foreign key on [KrajID] in table 'Miejscowosci'
ALTER TABLE [dbo].[Miejscowosci]
ADD CONSTRAINT [FK_Miejscowosci_Kraje]
    FOREIGN KEY ([KrajID])
    REFERENCES [dbo].[Kraje]
        ([KrajID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Miejscowosci_Kraje'
CREATE INDEX [IX_FK_Miejscowosci_Kraje]
ON [dbo].[Miejscowosci]
    ([KrajID]);
GO

-- Creating foreign key on [WlascicielID] in table 'Miejscowosci'
ALTER TABLE [dbo].[Miejscowosci]
ADD CONSTRAINT [FK_Miejscowosci_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Miejscowosci_Uzytkownicy'
CREATE INDEX [IX_FK_Miejscowosci_Uzytkownicy]
ON [dbo].[Miejscowosci]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'Miejscowosci'
ALTER TABLE [dbo].[Miejscowosci]
ADD CONSTRAINT [FK_Miejscowosci_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Miejscowosci_Uzytkownicy1'
CREATE INDEX [IX_FK_Miejscowosci_Uzytkownicy1]
ON [dbo].[Miejscowosci]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Miejscowosci'
ALTER TABLE [dbo].[Miejscowosci]
ADD CONSTRAINT [FK_Miejscowosci_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Miejscowosci_Uzytkownicy2'
CREATE INDEX [IX_FK_Miejscowosci_Uzytkownicy2]
ON [dbo].[Miejscowosci]
    ([BlokujacyID]);
GO

-- Creating foreign key on [TowarID] in table 'ProduktyFakturyKupna'
ALTER TABLE [dbo].[ProduktyFakturyKupna]
ADD CONSTRAINT [FK_ProduktyFakturyKupna_TowaryUslugi]
    FOREIGN KEY ([TowarID])
    REFERENCES [dbo].[TowaryUslugi]
        ([TowarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturyKupna_TowaryUslugi'
CREATE INDEX [IX_FK_ProduktyFakturyKupna_TowaryUslugi]
ON [dbo].[ProduktyFakturyKupna]
    ([TowarID]);
GO

-- Creating foreign key on [WlascicielID] in table 'ProduktyFakturyKupna'
ALTER TABLE [dbo].[ProduktyFakturyKupna]
ADD CONSTRAINT [FK_ProduktyFakturyKupna_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturyKupna_Uzytkownicy'
CREATE INDEX [IX_FK_ProduktyFakturyKupna_Uzytkownicy]
ON [dbo].[ProduktyFakturyKupna]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'ProduktyFakturyKupna'
ALTER TABLE [dbo].[ProduktyFakturyKupna]
ADD CONSTRAINT [FK_ProduktyFakturyKupna_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturyKupna_Uzytkownicy1'
CREATE INDEX [IX_FK_ProduktyFakturyKupna_Uzytkownicy1]
ON [dbo].[ProduktyFakturyKupna]
    ([BlokujacyID]);
GO

-- Creating foreign key on [TowarID] in table 'ProduktyFakturySprzedazy'
ALTER TABLE [dbo].[ProduktyFakturySprzedazy]
ADD CONSTRAINT [FK_ProduktyFakturySprzedazy_TowaryUslugi]
    FOREIGN KEY ([TowarID])
    REFERENCES [dbo].[TowaryUslugi]
        ([TowarID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturySprzedazy_TowaryUslugi'
CREATE INDEX [IX_FK_ProduktyFakturySprzedazy_TowaryUslugi]
ON [dbo].[ProduktyFakturySprzedazy]
    ([TowarID]);
GO

-- Creating foreign key on [WlascicielID] in table 'ProduktyFakturySprzedazy'
ALTER TABLE [dbo].[ProduktyFakturySprzedazy]
ADD CONSTRAINT [FK_ProduktyFakturySprzedazy_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturySprzedazy_Uzytkownicy'
CREATE INDEX [IX_FK_ProduktyFakturySprzedazy_Uzytkownicy]
ON [dbo].[ProduktyFakturySprzedazy]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'ProduktyFakturySprzedazy'
ALTER TABLE [dbo].[ProduktyFakturySprzedazy]
ADD CONSTRAINT [FK_ProduktyFakturySprzedazy_Uzytkownicy1]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProduktyFakturySprzedazy_Uzytkownicy1'
CREATE INDEX [IX_FK_ProduktyFakturySprzedazy_Uzytkownicy1]
ON [dbo].[ProduktyFakturySprzedazy]
    ([BlokujacyID]);
GO

-- Creating foreign key on [RolaID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [FK_Uzytkownicy_Role]
    FOREIGN KEY ([RolaID])
    REFERENCES [dbo].[Role]
        ([RolaID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Uzytkownicy_Role'
CREATE INDEX [IX_FK_Uzytkownicy_Role]
ON [dbo].[Uzytkownicy]
    ([RolaID]);
GO

-- Creating foreign key on [WlascicielID] in table 'RozliczeniaKupna'
ALTER TABLE [dbo].[RozliczeniaKupna]
ADD CONSTRAINT [FK_RozliczeniaKupna_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaKupna_Uzytkownicy'
CREATE INDEX [IX_FK_RozliczeniaKupna_Uzytkownicy]
ON [dbo].[RozliczeniaKupna]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'RozliczeniaKupna'
ALTER TABLE [dbo].[RozliczeniaKupna]
ADD CONSTRAINT [FK_RozliczeniaKupna_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaKupna_Uzytkownicy1'
CREATE INDEX [IX_FK_RozliczeniaKupna_Uzytkownicy1]
ON [dbo].[RozliczeniaKupna]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'RozliczeniaSprzedazy'
ALTER TABLE [dbo].[RozliczeniaSprzedazy]
ADD CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaSprzedazy_Uzytkownicy'
CREATE INDEX [IX_FK_RozliczeniaSprzedazy_Uzytkownicy]
ON [dbo].[RozliczeniaSprzedazy]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'RozliczeniaSprzedazy'
ALTER TABLE [dbo].[RozliczeniaSprzedazy]
ADD CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaSprzedazy_Uzytkownicy1'
CREATE INDEX [IX_FK_RozliczeniaSprzedazy_Uzytkownicy1]
ON [dbo].[RozliczeniaSprzedazy]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'RozliczeniaSprzedazy'
ALTER TABLE [dbo].[RozliczeniaSprzedazy]
ADD CONSTRAINT [FK_RozliczeniaSprzedazy_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RozliczeniaSprzedazy_Uzytkownicy2'
CREATE INDEX [IX_FK_RozliczeniaSprzedazy_Uzytkownicy2]
ON [dbo].[RozliczeniaSprzedazy]
    ([BlokujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'StawkiVat'
ALTER TABLE [dbo].[StawkiVat]
ADD CONSTRAINT [FK_StawkiVat_Uzytkownicy]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StawkiVat_Uzytkownicy'
CREATE INDEX [IX_FK_StawkiVat_Uzytkownicy]
ON [dbo].[StawkiVat]
    ([WlascicielID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'StawkiVat'
ALTER TABLE [dbo].[StawkiVat]
ADD CONSTRAINT [FK_StawkiVat_Uzytkownicy1]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StawkiVat_Uzytkownicy1'
CREATE INDEX [IX_FK_StawkiVat_Uzytkownicy1]
ON [dbo].[StawkiVat]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'StawkiVat'
ALTER TABLE [dbo].[StawkiVat]
ADD CONSTRAINT [FK_StawkiVat_Uzytkownicy2]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StawkiVat_Uzytkownicy2'
CREATE INDEX [IX_FK_StawkiVat_Uzytkownicy2]
ON [dbo].[StawkiVat]
    ([BlokujacyID]);
GO

-- Creating foreign key on [StawkaVatID] in table 'TowaryUslugi'
ALTER TABLE [dbo].[TowaryUslugi]
ADD CONSTRAINT [FK_TowaryUslugi_StawkiVat]
    FOREIGN KEY ([StawkaVatID])
    REFERENCES [dbo].[StawkiVat]
        ([StawkaVatID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TowaryUslugi_StawkiVat'
CREATE INDEX [IX_FK_TowaryUslugi_StawkiVat]
ON [dbo].[TowaryUslugi]
    ([StawkaVatID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'TowaryUslugi'
ALTER TABLE [dbo].[TowaryUslugi]
ADD CONSTRAINT [FK_TowaryUslugi_UzytkownikBlokujacy]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TowaryUslugi_UzytkownikBlokujacy'
CREATE INDEX [IX_FK_TowaryUslugi_UzytkownikBlokujacy]
ON [dbo].[TowaryUslugi]
    ([BlokujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'TowaryUslugi'
ALTER TABLE [dbo].[TowaryUslugi]
ADD CONSTRAINT [FK_TowaryUslugi_UzytkownikWlasciciel]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TowaryUslugi_UzytkownikWlasciciel'
CREATE INDEX [IX_FK_TowaryUslugi_UzytkownikWlasciciel]
ON [dbo].[TowaryUslugi]
    ([WlascicielID]);
GO

-- Creating foreign key on [BlokujacyID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [FK_Uzytkownicy_Blokujacy]
    FOREIGN KEY ([BlokujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Uzytkownicy_Blokujacy'
CREATE INDEX [IX_FK_Uzytkownicy_Blokujacy]
ON [dbo].[Uzytkownicy]
    ([BlokujacyID]);
GO

-- Creating foreign key on [ModyfikujacyID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [FK_Uzytkownicy_Modyfikujacy]
    FOREIGN KEY ([ModyfikujacyID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Uzytkownicy_Modyfikujacy'
CREATE INDEX [IX_FK_Uzytkownicy_Modyfikujacy]
ON [dbo].[Uzytkownicy]
    ([ModyfikujacyID]);
GO

-- Creating foreign key on [WlascicielID] in table 'Uzytkownicy'
ALTER TABLE [dbo].[Uzytkownicy]
ADD CONSTRAINT [FK_Uzytkownicy_Wlasciciel]
    FOREIGN KEY ([WlascicielID])
    REFERENCES [dbo].[Uzytkownicy]
        ([UzytkownikID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Uzytkownicy_Wlasciciel'
CREATE INDEX [IX_FK_Uzytkownicy_Wlasciciel]
ON [dbo].[Uzytkownicy]
    ([WlascicielID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------