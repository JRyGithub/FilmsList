USE [FilmList]
GO

CREATE TABLE [Film](
    [FilmId] [uniqueidentifier] PRIMARY KEY NOT NULL,
    [Genre] [nvarchar](250),
    [FilmName] [nvarchar](250) NOT NULL,
    [DirectorName] [nvarchar](250) NOT NULL
)