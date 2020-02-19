![.NET Core](https://github.com/SC-Poc/Service.Template/workflows/.NET%20Core/badge.svg)

# HOW TO USE TEMPLATE

### Register 
`
dotnet new --install ${path}
`

where ${path} is the **full** path to the clonned directory (where the folder .template.config placed) **without trailing slash** (e.g. `D:\SwissChainRoot\Service.Template\template`)

### Create

`
dotnet new swissservice -n {ServiceName} -o ServiceDirectory -di {docker-image-name} -p {ProjectName}
`

e.g.

`
dotnet new swissservice -n WalletWatcher -o "D:\SwissChainRoot\Service.WalletWatcher" -di "bil-wallet-watcher" -p Bil 
`

-di is a parameter for docker image in swisschains

# Features added to the template

### Load appsettings.josn from external server
You can collect settings for all services in a cluster in one place. It is can simplify to DevOps management of configuration.
Service after start can load appsettings.josn from the external server by HTTP GET request.
To activate this feature you should set in Environment variable 'RemoteSettingsUrl' URL address for getting JSON content.

### Use Serilog for structed logs
Use Serilog to improve log system for write structed logs. 
Log by default writed to console.
You can activate the feature to write logs to external log storage - [Seq](https://datalust.co/seq). Seq it is a very light tool, you can run in your local machine or into your cluster. And collect logs from all services in this single store to analyze.
To activate this feature you should set in Environment variable 'SeqUrl' URL address for Seq.

TODO: 
* Add opportunity to send log to ELK
* Add opportunity to send log to external server by GRPC

### Use GRPC and Rest
Template service by default ready to work with GRPC services and REst services. application host two ports:
* 5000 - protocol HTTP 1.1 to work with standard Rest api with aspnet and WebAPI.
* 5001 - protocol HTTP 2.0 to wotk with GRPC services.
By default application do not support SSL and HTTPS. Client for GRPS should use http ptotocol with out encription.
Example of server and client you can see in solution: 
* [MonitoringService](https://github.com/SC-Poc/Service.Template/blob/master/template/src/Service.Example/GrpcServices/MonitoringService.cs) server side
* [TestClient](https://github.com/SC-Poc/Service.Template/blob/master/template/test/Service.Example.TestClient/Program.cs) client side

Solution by default includes a project for client library: [<NAME>.Client](https://github.com/SC-Poc/Service.Template/tree/master/template/src/Service.Example.Client). You can build NuGet and use this library to simplify integration of other microservices with your application. And service and install the library in solution, register client in DI container with client interface and star use interface ... like it is an internal implementation

### Use Githib Action as CI for build and deploy docker image
Template solution includes pipelines to build, test and deploy solution artifacts.
You should only setup secret into your GitHub repository:
* DOCKER_USERNAME - user name from [hub.docker.com](https://hub.docker.com/)
* DOCKER_PASSWORD - password or API key from [hub.docker.com](https://hub.docker.com/)

TODO:
* add CI for client nuget
* add CI for build, test, without deply to docker hub
* add CI for release with version number

### Environment variables used
|Variable|Required|Value|
|-------|-------|-------|
|RemoteSettingsUrl|no|URL address for getting confg content to override appsettings.json|
|SeqUrl|yes|URL address for Seq server to keep logs|

