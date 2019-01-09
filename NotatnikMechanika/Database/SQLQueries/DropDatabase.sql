-- Script Date: 20.12.2018 20:50  - ErikEJ.SqlCeScripting version 3.5.2.75
DROP TABLE if exists [Cars];
CREATE TABLE [Cars] (
  [Id] int  NOT NULL PRIMARY KEY
, [Brand] nvarchar(50)  NOT NULL
, [Model] nvarchar(50)  NOT NULL
, [RegistrationNumber] nvarchar(20)  NOT NULL
, [Engine] nvarchar(10)  NOT NULL
, [Power] nvarchar(10)  NOT NULL
, [Course] nvarchar(10)  NOT NULL
, [ProductionYear] nvarchar(5)  NOT NULL
);


DROP TABLE if exists [Customers];
CREATE TABLE [Customers] (
  [Id] int  NOT NULL PRIMARY KEY
, [FirstName] nvarchar(50)  NOT NULL
, [LastName] nvarchar(50)  NOT NULL
, [CompanyName] nvarchar(150)  NOT NULL
, [Nip] nvarchar(14)  NOT NULL
, [PhoneNumber] nvarchar(12)  NOT NULL
, [Address] nvarchar(30)  NOT NULL
);


DROP TABLE if exists [Goods];
CREATE TABLE [Goods] (
  [Id] int  NOT NULL PRIMARY KEY
, [Name] nvarchar(50)  NOT NULL
, [Details] text NOT NULL
, [Price] float NOT NULL
, [Symbol] nvarchar(50)  NOT NULL
);

DROP TABLE if exists [Orders];
CREATE TABLE [Orders] (
  [Id] int  NOT NULL PRIMARY KEY
, [CustomerId] int  NOT NULL
, [CarId] int  NOT NULL
, [Details] text NULL
, [StartOrderDate] date NOT NULL
, [FinishOrderDate] date NOT NULL
, [Archived] tinyint NOT NULL
);


DROP TABLE if exists [OrdersToGoods];
CREATE TABLE [OrdersToGoods] (
  [Id] int  NOT NULL PRIMARY KEY
, [OrderId] int  NOT NULL
, [GoodId] int  NOT NULL
);

DROP TABLE if exists [OrdersToServices];
CREATE TABLE [OrdersToServices] (
  [Id] int  NOT NULL PRIMARY KEY
, [OrderId] int  NOT NULL
, [ServiceId] int  NOT NULL
);

DROP TABLE if exists [Services];
CREATE TABLE [Services] (
  [Id] int  NOT NULL PRIMARY KEY
, [Name] nvarchar(30)  NOT NULL
, [Description] text NOT NULL
, [Price] float NOT NULL
);
