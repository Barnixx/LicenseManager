# LicenseManager RestAPI
Simple RestAPI for License Manager written in .net Core and ASP.net Core.
Designs such as DDD, CQRS, Dispatcher were used to write the project.
API is hosted on Azure Cloud with CI/CD Azure Pipelines under the url: 

https://api-licensemanager.azurewebsites.net

Template with exemple requests:

https://github.com/Barnixx/LicenseManager/blob/master/LicenseManager.Api/LicenseManager.rest

Hosted Client written in Angular 6+
https://license-manager-client.azurewebsites.net

## Used Technologies
 - ASP.net Core
 - MS SQL (In the Docker container)
 - Entity Framework Core
 - Autofac (IoC)
 - AutoMapper
 - JSON Web Tokens (to authorize users between the API and the Client App)


