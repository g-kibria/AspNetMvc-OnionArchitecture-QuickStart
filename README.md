# AspNetMvc-OnionArchitecture-QuickStart
ASP.NET MVC 5 Onion Architecture QuickStart (with AutoFac as the DI container, AutoMapper for type mappings and log4net for logging). Unit tests are written using xUnit.



## Solution Structure
### QuickStart.Domain
Contains the DB models, mappings, contexts and repositories.
### QuickStart.Services
Contains the services.
### QuickStart.Presentation
Contains the controllers, view models, views and other presentation related assets (i.e. scripts, styles, fonts and images). This projects also contains the AutoFac dependency registrations, AutoMapper mapping profile and logging related static utility methods.
### QuickStart.Tests
Contains the unit and integration tests (currently unit tests are available) written using xUnit.
