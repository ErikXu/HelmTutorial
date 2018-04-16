FROM microsoft/aspnetcore:2.0
COPY . /app
WORKDIR /app

EXPOSE 5000/tcp
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "HelloTest.dll"]