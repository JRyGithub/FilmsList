USE [FilmList]
GO

CREATE TABLE [UserFilmList](
    [Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
    [UserEmail] [nvarchar](255) NOT NULL,
    [FilmId] [uniqueidentifier] NOT NULL,
    FOREIGN KEY (UserEmail) REFERENCES [User](UserEmail) ON DELETE CASCADE,
    FOREIGN KEY (FilmId) REFERENCES [Film](FilmId)
);