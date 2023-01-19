# TopiWork Test Web API
![NET version](https://img.shields.io/badge/NET%20version-7-green)
![Docker](https://img.shields.io/badge/-Docker-blue)
![GIT](https://img.shields.io/badge/-GIT-orange)
## Installation
If you start the program without Docker, use "cd twtAPI\src\TWT.API" to open "appsettings.Development.json" and rewrite the Connection String to your own server parameters.

```json
"ConnectionStrings": {
    "CarStore": "Server=localhost, 5555;Database=CarStore;User Id = SA; Password=P@ssword1;encrypt=false"
  },
```

Docker:
1. If you don't have Docker Desktop you need to download
2. Run Docker Desktop
3. ```docker-compose -f docker-compose.override.yml -f docker-compose.yml up -d```

You can watch the whole Documentation here: http://localhost:5000/swagger/index.html

.Net:
1. Download SQL Server and setup
2. Run SQL Server
3. If you don't have .NET 7 you need to download it
4. ```cd twtAPI\src\TWT.API```
5. ```dotnet run ```

## Documentation
I've created a swagger page for the api documentation within the project which can only be accessed in "development" mode at {applicationUrl}/swagger/index.html

## Task

Plan and implement a simple server application (API), that stores and handles cars.
The application is able to create, update and delete(CRUD) cars. 

A car have the following attributes:
- Licence plate number
- Owner's name
- Power (in HP(Horsepower))

We should be able to get the cars(data) from the API, but to create or update an
authentication is required. (For example a secret key)
You can decide which programming language (and framework) you would like to use.
Upload the project to a private GitHub repository and share it with the following user(s):
https://github.com/BitRiderzRecruitment

#### Evaluation criteria:
- Functionality
- Code quality and readability
- Git workflow
- Documentation (must be in english)
- Installation (instructions)

#### Bonus point during evaluation:
- Tests (Unit test lvl. only)
- Docker
- Go (As the selected language)
- Kubernetes resource
- Terraform module for deployment

The deadline of the task is in 2 days (18:00 CET), if you have any questions let us know.
General tip for the project is to: Keep It Simple :)
