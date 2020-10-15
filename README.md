# Electric System Demo
An  demo CRUD by using Net core and mongo db.
## Run The Project
You will need the following tools:

* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/)
* [.Net Core 3.1 or later](https://dotnet.microsoft.com/download/dotnet-core/3.1)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. At the root directory which include **docker-compose.yml** files, run below command:
```csharp
docker-compose -f docker-compose.yml -f docker-compose.override.yml up –d
```
3. Wait for docker compose all services.

4. You can **launch application** as below urls:
* **API  -> http://localhost:8501/swagger/index.html**
* **Web UI -> http://localhost:8502/**
5. Launch http://localhost:8502/** in your browser to view the Web UI.
6. Some Pictures About Web UI
![Image of democmc](https://github.com/hoangbau/CMCDemo/blob/master/demo-1.PNG)

### About architecture design and techlonogies used
1. Client: MVC,HTML/CSS/Jquery
2. Server: WebApi,MongoDB
3. Design Pattern: Repository, CQRS, DI , SOLID, Clean Architecture Design
3. Deloyment: Docker Compose
### Next Release
1. Apply Intergration Test
2. Implement Logging/Mornitoring System
3. Intergration of Message Bus(RabbitMQ)
