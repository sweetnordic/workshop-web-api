# Workshop Web API Grundlagen

Ein Workshop über Grundlagen für Web / HTTP APIs vom Code zum App Service, als extra gibt es noch einen Teil für eine Web API welche eine Angular SPA bedient.

Vier Abschnitte:

- Web API
  - [Web API mit ASP.NET Core](#asp-net-web-api-c)
  - [Web API mit Node.js und Nest.js](#nodejs-mit-nestjs-web-api-typescript)
  - [Web API mit FastAPI](#web-api-mit-fastapi)
- Web API + App
  - [Web App mit ASP.NET Core und Angular.js](#asp-net-web-api--angularjs-web-spa)

## Azure Infrastruktur

[![Deploy To Azure](https://raw.githubusercontent.com/sweetnordic/workshop-web-api/main/.azure/images/deploytoazure.svg?sanitize=true)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fsweetnordic%2Fworkshop-web-api%2Fmain%2F.azure%2Fazuredeploy.json)
[![Visualize](https://raw.githubusercontent.com/sweetnordic/workshop-web-api/main/.azure/images/visualizebutton.svg?sanitize=true)](http://armviz.io/#/?load=https%3A%2F%2Fraw.githubusercontent.com%2Fsweetnordic%2Fworkshop-web-api%2Fmain%2F.azure%2Fazuredeploy.json)

> Alternatives Deployment

```powershell
$Name = Read-Host "Dein Kürzel (3-4 Zeichen)"
New-AzResourceGroupDeployment -ResourceGroupName "az4db-wissenstransfer" -TemplateUri "https://raw.githubusercontent.com/sweetnordic/workshop-web-api/main/.azure/azuredeploy.json" -DeploymentName "ws-$($Name)-api" -TemplateParameterObject @{ "Name" = $Name }
```

## Grundlagen

Im Bereich der Web APIs wird unterschieden in zwei Bereichen, HTTP und REST. HTTP API ist die Grundlagen und die RESTful API sollte das Ziel sein. Zu dem Thema RESTful APIs gibt es viel zu lesen unter anderem hat Microsoft ein [RESTful API Design Guide](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design) und [RESTful API Guidelines](https://github.com/Microsoft/api-guidelines/blob/vNext/Guidelines.md).

Weitere Informationen zu RESTful APIs:

- [RedHat - Was ist eine REST-API](https://www.redhat.com/de/topics/api/what-is-a-rest-api)
- [IBM - What is a REST API](https://www.ibm.com/cloud/learn/rest-apis)

Um eine API verständlicher zu machen, gibt es die Möglichkeit diese zu dokumentieren anhand der [OpenAPI Specification](https://swagger.io/specification/). Dies ist eine spezielle Form geschrieben in JSON oder YAML und kann unter anderem von [Swagger](https://swagger.io/) weiter verwendet werden.

## ASP.NET Core Web API `C#`

[Zur Abschnittsdokumentation](abschnitt-1.md)

## Node.js mit Nest.js Web API `TypeScript`

[Zur Abschnittsdokumentation](abschnitt-2.md)

## FastAPI Web API `python`

[Zur Abschnittsdokumentation](abschnitt-3.md)

## ASP.NET Core Web API + Angular.js Web SPA

[Zur Abschnittsdokumentation](abschnitt-4.md)
