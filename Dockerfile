FROM microsoft/dotnet:3.0-sdk as server
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "out/SkeletonBot.dll"]


