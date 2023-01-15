FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY *.sln .
COPY src/kwetter_be_user/*.csproj ./src/kwetter_be_user/
COPY test/kwetter_be_user.UnitTest/*.csproj ./test/kwetter_be_user.UnitTest/
COPY test/kwetter_be_user.ComponentTest/*.csproj ./test/kwetter_be_user.ComponentTest/
RUN dotnet restore

# copy full solution over
COPY . .
RUN dotnet build
FROM build AS testrunner
WORKDIR /app/test/kwetter_be_user.UnitTest
CMD ["dotnet", "test", "--logger:trx"]

# run the unit tests
FROM build AS test
WORKDIR /app/test/kwetter_be_user.UnitTest
RUN dotnet test --logger:trx

# # run the component tests
# FROM build AS componenttestrunner
# WORKDIR /app/test/kwetter_be_user.ComponentTest
# CMD ["dotnet", "test", "--logger:trx"]

# publish the API
FROM build AS publish
WORKDIR /app/src/kwetter_be_user
RUN dotnet publish -c Release -o out

# run the api
FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /app
COPY --from=publish /app/src/kwetter_be_user/out ./
# ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "kwetter_user.dll"]