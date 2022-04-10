# Workshop Web API Grundlage

Ein Workshop über Grundlagen für Web APIs vom Code zum App Service als extra gibt es noch einen Teil für eine Web API welche eine Angular SPA bedient.

Drei Abschnitte:
- Web API
  1. [Web API mit ASP.NET Core](#aspnet-web-api-c)
  2. [Web API mit Node.js und Nestjs](#nodejs-mit-nestjs-web-api-typescript)
- Web App
  3. [Web App mit ASP.NET Core und Angular.js](#aspnet-web-api--angularjs-web-spa)

## Voraussetzungen

- `choco install dotnet-5.0-sdk`
- `choco install nodejs-lts`
- `npm install -g @nestjs/cli`

### Azure Infrastruktur

[![Deploy To Azure](https://raw.githubusercontent.com/sweetnordic/workshop-web-api/main/.azure/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fsweetnordic%2Fworkshop-web-api%2Fmain%2F.azure%2Fazuredeploy.json)
[![Visualize](https://raw.githubusercontent.com/sweetnordic/workshop-web-api/main/.azure/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fsweetnordic%2Fworkshop-web-api%2Fmain%2F.azure%2Fazuredeploy.json)

## Grundlagen



## ASP.NET Web API [C#]

`dotnet new webapi --name Workshop.WebApi --output Workshop.WebApi --language C# --framework net5.0`
https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-new-sdk-templates

## Node.js mit Nestjs Web API [TypeScript]

`nest new WorkshopNodeApi --skip-git --package-manager npm --language TS`
https://docs.nestjs.com/

`nest build --tsc`

`nest start --tsc --watch`

`https://docs.nestjs.com/recipes/prisma`

## ASP.NET Web API + Angular.js Web SPA

`dotnet new angular --name Workshop.WebApp --output Workshop.WebApp --language C# --framework net5.0`

https://angular.io/
