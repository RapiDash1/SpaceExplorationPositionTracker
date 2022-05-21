FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

COPY ./ ./

RUN dotnet dev-certs https --clean

RUN dotnet dev-certs https -t

CMD ["/bin/bash", "-c", "dotnet restore && dotnet run --project WebApi/WebApi.csproj"]