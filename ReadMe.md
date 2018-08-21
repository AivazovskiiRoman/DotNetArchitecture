# DotNetArchitecture

Solution to apply and share new knowledge and technologies and to serve as architecture for new projects.

## Tools, Practices and Technologies

* Cross-Platform (Windows, Linux, macOS)
* Docker
* Visual Studio 2017
* Visual Studio Code
* .NET Core 2.1.1
* ASP.NET Core 2.1.1
* Entity Framework Core 2.1.2
* SQL Server 2017
* MongoDB
* C# 7.3
* SPA (Single Page Application)
* Angular 6.1.3
* Typescript 2.9.2
* HTML5
* CSS3
* SASS (Syntactically Awesome Style Sheets)
* DDD (Domain-Driven Design)
* SOLID Principles
* Dependency Injection
* Unit Test
* JWT (Json Web Token)
* Code Analysis (Ruleset for C# and TSLint for Typescript)

## Build

[![Build Status](https://ci.appveyor.com/api/projects/status/17lg6pt9kf55cr1y?svg=true)](https://ci.appveyor.com/project/rafaelfgx/dotnetarchitecture)

## Code Analysis

[![Codacy](https://api.codacy.com/project/badge/Grade/6eef5f26173c4b80824a2eeb0b4f9ab9)](https://www.codacy.com/app/rafaelfgx/DotNetArchitecture?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=rafaelfgx/DotNetArchitecture&amp;utm_campaign=Badge_Grade)

## Layers

![Screenshot](Screenshots/0.png)

**Web:** This layer contains the user interface, responsible for interaction with the user to obtain and display data.

**Application:** This layer is the main entry point of the application.

**Domain:** This layer contains the requirements and the business logic, is the core of the application.

**Infrastructure:** This layer isolates and abstracts the logic required for data persistence.

**Model:** This layer is responsible for modeling the domain classes according with the business context.

**CrossCutting:** This layer provides generic features for the other layers.

**Tests:** It is responsible for testing individual units of the code, which can be a class, a method, an integration, a business rule, among others.

## Projects

![Screenshot](Screenshots/1.png)

## Application

![Screenshot](Screenshots/2.png)

## Domain

![Screenshot](Screenshots/3.png)

## Repository

![Screenshot](Screenshots/4.png)

## Unit Test

![Screenshot](Screenshots/5.png)

## ASP.NET Core + Angular

![Screenshot](Screenshots/6.png)

## ASP.NET Core Startup

![Screenshot](Screenshots/7.png)

## ASP.NET Core Controller

![Screenshot](Screenshots/8.png)

## Angular Guard

![Screenshot](Screenshots/9.png)

## Angular Error Handler

![Screenshot](Screenshots/10.png)

## Angular HTTP Interceptor

![Screenshot](Screenshots/11.png)

## Angular Service

![Screenshot](Screenshots/12.png)

## Angular Component

![Screenshot](Screenshots/13.png)

## ASP.NET Core + Angular + Entity Framework Core + SQL Server Performance

![Screenshot](Screenshots/14.png)

**Specifications:**

**Processor:** Intel Core I7 8700K Coffee Lake 8th-generation.

**Memory:** 16GB 2400Mhz DDR4.

**Storage:** Samsung Evo 960 SSD M2 250gb.

**OS:** Windows 10 Pro 64 bits.

**Web Server:** IIS 10.

**Database:** SQL Server 2017 Developer Edition.

## Run Visual Studio Code

1. Install [.NET Core SDK](https://aka.ms/dotnet-download).

2. Install [C# Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode.csharp).

3. Open **solution folder**.

4. Press **F5**.

## Run Docker

1. Execute **docker-compose up -d** in **solution folder**.

2. Open <http://localhost:8080>.

## Host and Deploy

[Microsoft host and deploy ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/index?view=aspnetcore-2.1&tabs=aspnetcore2x)

## Visual Studio Extensions

[CodeMaid](https://marketplace.visualstudio.com/items?itemName=SteveCadwallader.CodeMaid)

[Roslynator](https://marketplace.visualstudio.com/items?itemName=josefpihrt.Roslynator2017)

[SonarLint](https://marketplace.visualstudio.com/items?itemName=SonarSource.SonarLintforVisualStudio2017)

[TSLint](https://marketplace.visualstudio.com/items?itemName=vladeck.TSLint)
