FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY ./app /app
WORKDIR /app
EXPOSE 6000
ENTRYPOINT ["dotnet", "Widge.DotNet.Grpc.Testing.dll"]