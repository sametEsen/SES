# SES Assignment

## Project Setup Guideline

* 1- Clone the repository to your local
* 2- Open the solution in Visual Studio, the project has been developed in Visual Studio 2022(VS)
using .NET 6. The solution consists of 5 projects in total:
* a. SES.Api (Web API) to serve requests coming from the front-end
* b. SES.Services (Class library) which contains logic for the application
* c. SES.Models (Class Library) which contains the domain models
* d. SES.UI (Angular) which is an angular project, used for the frontend
The frontend part has been mostly developed in Visual Studio Code and is based on Angular
* e. SES.Api.Test (NUnit Test Project) which contains the test classes. 
* 4- With SES.Api, set as default project, please run the solution in VS, it will run
the Web API and open a browser for you with Swagger page.
* 6- When running the project, you might face a pop up from VS that says “This project
is configured to use SSL. To avoid SSL warnings in the browser you …”, please check the
“Don’t ask me again” checkbox and click Yes.
* 7- Install Node.js if necessary, the development machine had node version 12.16.3 and npm
version 8.6.0 installed.
* 8- Open a PowerShell or Node.js command prompt as Administrator and Go to
“{SolutionDrirectory}\SES.UI\ClientApp”, now run “npm install”.
* 9- “{SolutionDrirectory}\SES.UI\ClientApp\src\app\common\app-config.ts” contains the API root access to be used for the requests, change that if necessary, you can compare it to the address you see in the Swagger window
* 10- Now run ng serve the same way stated in step 8, after a short time, a message would appear
showing the address in which you can access the software, it’s usually http://localhost:4200/
* 11- That’s it, go to the address, and get the Kata Code result.
