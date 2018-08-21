# .NET Core build
FROM microsoft/dotnet:2.1-sdk AS net-core-build

# .NET Core build directory
WORKDIR /src

# Copy only csproj files
COPY Application/Applications/Solution.Application.Applications.csproj Application/Applications/
COPY CrossCutting/AspNetCore/Solution.CrossCutting.AspNetCore.csproj CrossCutting/AspNetCore/
COPY CrossCutting/DependencyInjection/Solution.CrossCutting.DependencyInjection.csproj CrossCutting/DependencyInjection/
COPY CrossCutting/EntityFrameworkCore/Solution.CrossCutting.EntityFrameworkCore.csproj CrossCutting/EntityFrameworkCore/
COPY CrossCutting/Logging/Solution.CrossCutting.Logging.csproj CrossCutting/Logging/
COPY CrossCutting/Mapping/Solution.CrossCutting.Mapping.csproj CrossCutting/Mapping/
COPY CrossCutting/MongoDB/Solution.CrossCutting.MongoDB.csproj CrossCutting/MongoDB/
COPY CrossCutting/Resources/Solution.CrossCutting.Resources.csproj CrossCutting/Resources/
COPY CrossCutting/Security/Solution.CrossCutting.Security.csproj CrossCutting/Security/
COPY CrossCutting/Utils/Solution.CrossCutting.Utils.csproj CrossCutting/Utils/
COPY Domain/Domains/Solution.Domain.Domains.csproj Domain/Domains/
COPY Infrastructure/Database/Solution.Infrastructure.Database.csproj Infrastructure/Database/
COPY Model/Enums/Solution.Model.Enums.csproj Model/Enums/
COPY Model/Models/Solution.Model.Models.csproj Model/Models/
COPY Model/Validators/Solution.Model.Validators.csproj Model/Validators/
COPY Web/UserInterface/Solution.Web.UserInterface.csproj Web/UserInterface/

# ASP.NET Core restore
RUN dotnet restore Web/UserInterface/Solution.Web.UserInterface.csproj

# Copy all files
COPY . .

# ASP.NET Core directory
WORKDIR /src/Web/UserInterface

# Delete ClientApp
RUN rm -rf ClientApp

# ASP.NET Core build
RUN dotnet build Solution.Web.UserInterface.csproj -c Release -o /app

# ASP.NET Core publish
FROM net-core-build AS net-core-publish
RUN dotnet publish Solution.Web.UserInterface.csproj -c Release -o /app

# Angular
FROM node:10.8.0 AS angular-build
ARG ANGULAR_ENVIRONMENT
WORKDIR /ClientApp
ENV PATH /ClientApp/node_modules/.bin:$PATH
COPY Web/UserInterface/ClientApp/package.json /ClientApp
RUN npm run restore
COPY Web/UserInterface/ClientApp /ClientApp
RUN npm run $ANGULAR_ENVIRONMENT

# ASP.NET Core runtime
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS net-core-runtime
WORKDIR /app
EXPOSE 80

# ASP.NET Core and Angular
FROM net-core-runtime AS net-core-angular
# ASP.NET Core args
ARG ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=$ASPNETCORE_ENVIRONMENT
WORKDIR /app
COPY --from=net-core-publish /app .
COPY --from=angular-build /ClientApp/dist /app/ClientApp/dist

ENTRYPOINT ["dotnet", "Solution.Web.UserInterface.dll"]
