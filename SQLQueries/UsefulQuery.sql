SELECT * 
FROM Film 
WHERE EXISTS 
(SELECT FilmId, UserEmail 
FROM UserFilmList
WHERE UserFilmList.FilmId = Film.FilmId 
AND EXISTS 
(SELECT UserEmail 
FROM [User]
WHERE UserEmail = 'test@test.com' ))