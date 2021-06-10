# FilmsList
A simple web app to allow users to log in and upload films they have watched. Built with a React/Redux front end and .Net 5.0 back end.

No resources have been deployed the server was ran within a docker container.
Using microsofts sql server container found here https://hub.docker.com/_/microsoft-mssql-server . The following command will pull the latest container if Docker is installed =
    docker pull mcr.microsoft.com/mssql/server:2019-latest

SQL Server etc, will also need to be installed. I have included some useful sqlm queries that can help set this up once the database is established.

<h2>Features</h2>
-Authentication via JWT for both front and back end

-ASP.NetCore with .NetCore 5.0, CRUD implementation for backend, Swagger Docs

-Frontend built with react and redux, using react-router

<h2>TODO</h2>
-Prettify the entire project, skeleton CSS

-Refactor codebase, espiecally frontend and redundant backend code. (Ran out of time)

-Allow creation of new accounts and reseting password via frontEnd

-Implement basic tests

<h2>Hindsight</h2>
-Redux possible overkill?

-TDD should have been impleneted for basic utility tests

-deplyed to a azure server early with skeleton code, would have allowed for a full deployement near end

-Shouldn't have written down architecture diagrams etc, on paper

<h2>Images</h2>

![Swagger.png](https://github.com/JRyGithub/FilmsList/blob/main/Images/Swagger.png?raw=true)

![Table.png](https://github.com/JRyGithub/FilmsList/blob/main/Images/Table.png?raw=true)

![Login.png](https://github.com/JRyGithub/FilmsList/blob/main/Images/LogIn.png?raw=true)