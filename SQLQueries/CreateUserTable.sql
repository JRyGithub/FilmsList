USE FilmList;
GO

CREATE TABLE [User](
    [UserEmail] [nvarchar](255) PRIMARY KEY NOT NULL,
    [Password] [char](64) NOT NULL
)