# Clean Architecture With .NET 8 And CQRS

How To Approach Clean Architecture Folder Structure

It's a layered architecture that splits the project into four layers:
Domain
Application
Infrastructure
Presentation
Each of the layers is typically one project in your solution.

Domain Layer
The Domain layer sits at the core of the Clean Architecture. Here we define things like: entities, value objects, aggregates, domain events, exceptions, repository interfaces, etc.

Application Layer
The Application layer sits right above the Domain layer. It acts as an orchestrator for the Domain layer, containing the most important use cases in your application.
You can structure your use cases using services or using commands and queries.
I'm a big fan of the CQRS pattern, so I like to use the command and query approach.

Infrastructure Layer
The Infrastructure layer contains implementations for external-facing services.
What would fall into this category?
Databases - PostgreSQL, MongoDB
Identity providers - Auth0, Keycloak
Emails providers
Storage services - AWS S3, Azure Blob Storage
Message queues - Rabbit MQ

Presentation Layer
The Presentation layer is the entry point to our system. Typically, you would implement this as a Web API project.
The most important part of the Presentation layer is the Controllers, which define the API endpoints in our system.
