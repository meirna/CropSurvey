#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS="https://+;http://+"
ENV CLIENT_SECRET=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
ENV CLIENT_ID=989384966026-p4t3gman0v2j8klpuv3oqb0k8gn2otar.apps.googleusercontent.com

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