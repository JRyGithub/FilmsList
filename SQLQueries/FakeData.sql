USE FilmList
GO

INSERT INTO [User](
    [UserEmail],
    [Password]) 
    VALUES
    (
        'test@test.com',
        'password'
    )
GO

INSERT INTO [Film](
    [FilmId],
    [Genre],
    [FilmName],
    [DirectorName]
) VALUES (
    'fd3ec5c5-4fcd-4908-b07f-df00d30b3158',
    'Fantasy',
    'Lord of the Rings',
    'JRR Tolkien'
)

GO

INSERT INTO [UserFilmList](
    [Id],
    [UserEmail],
    [FilmId]
) VALUES (
    '9a68dd15-1b4c-41bb-bb41-df2c207e71d7',
    'test@test.com',
    'fd3ec5c5-4fcd-4908-b07f-df00d30b3158'
)

GO