
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/05/2016 03:36:25
-- Generated from EDMX file: C:\Users\Programlama\Desktop\TelefonAksesuar1 -sql\TelefonAksesuar\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TelefonAksesuar];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Sepetim_Uyeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sepetim] DROP CONSTRAINT [FK_Sepetim_Uyeler];
GO
IF OBJECT_ID(N'[dbo].[FK_Siparisler_Uyeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Siparisler] DROP CONSTRAINT [FK_Siparisler_Uyeler];
GO
IF OBJECT_ID(N'[dbo].[FK_Yorumlar_Urunler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Yorumlar] DROP CONSTRAINT [FK_Yorumlar_Urunler];
GO
IF OBJECT_ID(N'[dbo].[FK_Yorumlar_Uyeler]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Yorumlar] DROP CONSTRAINT [FK_Yorumlar_Uyeler];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Sepetim]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sepetim];
GO
IF OBJECT_ID(N'[dbo].[Siparisler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Siparisler];
GO
IF OBJECT_ID(N'[dbo].[Urunler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Urunler];
GO
IF OBJECT_ID(N'[dbo].[Uyeler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Uyeler];
GO
IF OBJECT_ID(N'[dbo].[Yetkiler]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Yetkiler];
GO
IF OBJECT_ID(N'[dbo].[Yorumlar]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Yorumlar];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Siparisler'
CREATE TABLE [dbo].[Siparisler] (
    [SiparisID] int IDENTITY(1,1) NOT NULL,
    [SiparisOzet] nvarchar(50)  NOT NULL,
    [UyeID] int  NOT NULL,
    [Tarih] nvarchar(50)  NOT NULL,
    [Adres] nvarchar(50)  NOT NULL,
    [Durum] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Urunler'
CREATE TABLE [dbo].[Urunler] (
    [UrunID] int IDENTITY(1,1) NOT NULL,
    [Kategori] nvarchar(50)  NOT NULL,
    [Marka] nvarchar(50)  NOT NULL,
    [Model] nvarchar(50)  NOT NULL,
    [Fiyat] int  NOT NULL,
    [Stok] nvarchar(50)  NOT NULL,
    [Resim] nvarchar(250)  NULL
);
GO

-- Creating table 'Uyeler'
CREATE TABLE [dbo].[Uyeler] (
    [UyeID] int IDENTITY(1,1) NOT NULL,
    [Ad] nvarchar(50)  NOT NULL,
    [Soyad] nvarchar(50)  NOT NULL,
    [EMail] nvarchar(50)  NOT NULL,
    [KullaniciAdi] nvarchar(50)  NOT NULL,
    [Sifre] nvarchar(50)  NOT NULL,
    [DogumTarihi] datetime  NOT NULL,
    [Sehir] nvarchar(50)  NOT NULL,
    [Adres] nvarchar(50)  NOT NULL,
    [Yetki] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Sepetim'
CREATE TABLE [dbo].[Sepetim] (
    [SepetNo] int IDENTITY(1,1) NOT NULL,
    [UyeID] int  NOT NULL,
    [UrunAd] nvarchar(50)  NOT NULL,
    [Adet] int  NOT NULL,
    [Fiyat] int  NOT NULL,
    [ToplamFiyat] int  NOT NULL
);
GO

-- Creating table 'Yorumlar'
CREATE TABLE [dbo].[Yorumlar] (
    [YorumNo] int IDENTITY(1,1) NOT NULL,
    [UrunID] int  NOT NULL,
    [UyeID] int  NOT NULL,
    [YorumTarih] nvarchar(50)  NOT NULL,
    [Yorum] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Yetkiler'
CREATE TABLE [dbo].[Yetkiler] (
    [YetkiID] int IDENTITY(1,1) NOT NULL,
    [Yetki] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [SiparisID] in table 'Siparisler'
ALTER TABLE [dbo].[Siparisler]
ADD CONSTRAINT [PK_Siparisler]
    PRIMARY KEY CLUSTERED ([SiparisID] ASC);
GO

-- Creating primary key on [UrunID] in table 'Urunler'
ALTER TABLE [dbo].[Urunler]
ADD CONSTRAINT [PK_Urunler]
    PRIMARY KEY CLUSTERED ([UrunID] ASC);
GO

-- Creating primary key on [UyeID] in table 'Uyeler'
ALTER TABLE [dbo].[Uyeler]
ADD CONSTRAINT [PK_Uyeler]
    PRIMARY KEY CLUSTERED ([UyeID] ASC);
GO

-- Creating primary key on [SepetNo] in table 'Sepetim'
ALTER TABLE [dbo].[Sepetim]
ADD CONSTRAINT [PK_Sepetim]
    PRIMARY KEY CLUSTERED ([SepetNo] ASC);
GO

-- Creating primary key on [YorumNo] in table 'Yorumlar'
ALTER TABLE [dbo].[Yorumlar]
ADD CONSTRAINT [PK_Yorumlar]
    PRIMARY KEY CLUSTERED ([YorumNo] ASC);
GO

-- Creating primary key on [YetkiID] in table 'Yetkiler'
ALTER TABLE [dbo].[Yetkiler]
ADD CONSTRAINT [PK_Yetkiler]
    PRIMARY KEY CLUSTERED ([YetkiID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UyeID] in table 'Siparisler'
ALTER TABLE [dbo].[Siparisler]
ADD CONSTRAINT [FK_Siparisler_Uyeler]
    FOREIGN KEY ([UyeID])
    REFERENCES [dbo].[Uyeler]
        ([UyeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Siparisler_Uyeler'
CREATE INDEX [IX_FK_Siparisler_Uyeler]
ON [dbo].[Siparisler]
    ([UyeID]);
GO

-- Creating foreign key on [UyeID] in table 'Sepetim'
ALTER TABLE [dbo].[Sepetim]
ADD CONSTRAINT [FK_Sepetim_Uyeler]
    FOREIGN KEY ([UyeID])
    REFERENCES [dbo].[Uyeler]
        ([UyeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sepetim_Uyeler'
CREATE INDEX [IX_FK_Sepetim_Uyeler]
ON [dbo].[Sepetim]
    ([UyeID]);
GO

-- Creating foreign key on [UrunID] in table 'Yorumlar'
ALTER TABLE [dbo].[Yorumlar]
ADD CONSTRAINT [FK_Yorumlar_Urunler]
    FOREIGN KEY ([UrunID])
    REFERENCES [dbo].[Urunler]
        ([UrunID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Yorumlar_Urunler'
CREATE INDEX [IX_FK_Yorumlar_Urunler]
ON [dbo].[Yorumlar]
    ([UrunID]);
GO

-- Creating foreign key on [UyeID] in table 'Yorumlar'
ALTER TABLE [dbo].[Yorumlar]
ADD CONSTRAINT [FK_Yorumlar_Uyeler]
    FOREIGN KEY ([UyeID])
    REFERENCES [dbo].[Uyeler]
        ([UyeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Yorumlar_Uyeler'
CREATE INDEX [IX_FK_Yorumlar_Uyeler]
ON [dbo].[Yorumlar]
    ([UyeID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------