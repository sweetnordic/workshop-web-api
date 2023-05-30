This project was created using [Microsoft Web Template Studio](https://github.com/Microsoft/WebTemplateStudio).

## Getting Started

The best way to launch the application is using the [Visual Studio Code Tasks](https://code.visualstudio.com/docs/editor/tasks). In the `vscode/tasks.json` file you can find all the tasks configured for this project.

To launch a task click on the menu `Terminal > Run Task` and select the task to launch (or press `Ctrl+Shift+P` and choose the `Tasks:Run Task` command).

To run the project:

1. Install dependencies using `Install dependencies` task.
2. Start development app using `Start App` task.

## File Structure
```
.
├── .vscode/ - Visual Studio Code configuration files
├── backend/ - Backend App
│ ├── Contracts/ - Interfaces for services
│ ├── Controllers/ - Handles API calls for routes
│ ├── Models/ - Data models
│ ├── Scripts/ - scripts to publish
│ ├── Services/ - Data services
│ ├── appsettings.json - Configuration data file
│ ├── Program.cs - Contains create host and run application
│ ├── Startup.cs - Register services and configure application
│ └── WebApi.csproj - Configures Port and HTTP Server
├── frontend/ - Frontend App
│ ├── public/ - public static files
│ ├── scripts/ - scripts to publish
│ ├── src/ - Vue app folder
│ │   ├── assets/ - Default images
│ │   ├── components/ - Common Vue components shared between different views
│ │   ├── router/ -  Vue routes
│ │   ├── views/ - The main pages displayed
│ │   ├── App.vue - Base Vue template
│ │   ├── constants.js - Contains constants for error messages and endpoints
│ └── └── main.js - Root Vue Component
└── README.md
```

### Frontend

The frontend is based on [Vue CLI](https://cli.vuejs.org/).

The most important scripts in the `package.json` are:
  - start: serves the frontend in development on http://localhost:3000/.
  - build: Builds the app for production to the `build` folder.
  - publish: Builds the app for production and moves the output to the `publish` folder.

To start the frontend application manually:
  1. Open a terminal and navigate to the `frontend` folder path.
  2. Use `yarn install` or `npm install` to install frontend dependencies.
  3. Use `yarn start` or `npm start` to start frontend app in development.

### Backend

The backend is based on [ASP.NET Web API](https://dotnet.microsoft.com/apps/aspnet/apis).

To start the backend application manually:
  1. Open a terminal and navigate to the `backend` folder path.
  2. Use `dotnet restore` to restore backend packages.
  3. Use `dotnet run` to start backend app in development. It is served on https://localhost:5001/

## Deployment

To deploy the application in an Azure App Service follow the deployment instructions:

- [Deployment using Web Template Studio Deploy command](https://github.com/microsoft/WebTemplateStudio/blob/dev/docs/generated-apps/deployment.md)

Consider adding authentication and securing backend API's by following [Azure App Service Security](https://docs.microsoft.com/en-us/azure/app-service/overview-security).

## Additional Documentation

- Vue - https://vuejs.org/v2/guide/
- Vue Router - https://router.vuejs.org/
- .NET - https://dotnet.microsoft.com/
- ASP.NET - https://dotnet.microsoft.com/apps/aspnet
- Bootstrap CSS - https://getbootstrap.com/
