#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
COPY ["certificate", "certificate"]

ENV ASPNETCORE_URLS="https://+;http://+"
ENV CLIENT_SECRET=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
ENV CLIENT_ID=992294165784-ujrkmtdh9hdm23r225pglsfql5773v5a.apps.googleusercontent.com

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CropSurvey.DAL/CropSurvey.DAL.csproj", "CropSurvey.DAL/"]
COPY ["CropSurvey.Model/CropSurvey.Model.csproj", "CropSurvey.Model/"]
COPY ["CropSurvey.Web/CropSurvey.Web.csproj", "CropSurvey.Web/"]
RUN dotnet restore "CropSurvey.Web/CropSurvey.Web.csproj"
COPY . .
WORKDIR "/src/CropSurvey.Web"
RUN dotnet build "CropSurvey.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CropSurvey.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CropSurvey.Web.dll"]