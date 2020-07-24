1 heroku login
2 docker ps
3 heroku container:login
4 heroku container:push worker -a skeletonbot
5 heroku container:release worker -a skeletonbot
6 heroku ps:scale worker=1 -a skeletonbot

buildpack: https://github.com/noliar/dotnet-buildpack

Deixar off (manutencao)
heroku maintenance:on -a skeletonbot

Database
dotnet add package Microsoft.EntityFrameworkCore.Sqlite

dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update