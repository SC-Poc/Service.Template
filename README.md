![.NET Core](https://github.com/swisschain/Service.Template/workflows/.NET%20Core/badge.svg)

# HOW TO USE TEMPLATE

### Register 
`
dotnet new --install ${path}
`

where ${path} is the **full** path to the clonned directory (where the folder .template.config placed) **without trailing slash** (e.g. `D:\SwissChainRoot\Service.Template\template`)

### Create

`
dotnet new swissservice -n {ServiceName} -o {ServiceDirectory} -snk {service-name-kebab-case} -pnk {proudct-name-kebab-case} -pnc {ProductNameCamelCase}
`

e.g.

`
dotnet new swissservice -n Wallet -o Service.Sirius.Wallet -snk wallet -pnk sirius -pnc Sirius
`
# Features added to the template

### Swischain.Sdk

It is recomended to read [Swisschain.Sdk.Server readme](https://github.com/swisschain/Swisschain.Sdk.Server/blob/master/README.md) as well

### Load appsettings.josn from external server
You can collect settings for all services in a cluster in one place. It is can simplify to DevOps management of configuration.
Service after start can load appsettings.josn from the external server by HTTP GET request.
To activate this feature you should set in Environment variable 'RemoteSettingsUrl' URL address for getting JSON content.

Confie example you can see in []().
To run project locally please copy [format.appsettings.json](https://github.com/swisschain/Service.Template/blob/master/template/format.appsettings.json) to [project foulder](https://github.com/swisschain/Service.Template/tree/master/template/src/Example), rename to `appsettings.json` and fill params

### Use Serilog for structed logs
Use Serilog to improve log system for write structed logs. 
Log by default writed to console.
You can activate the feature to write logs to external log storage - [Seq](https://datalust.co/seq). Seq it is a very light tool, you can run in your local machine or into your cluster. And collect logs from all services in this single store to analyze.
To activate this feature you should set configuration variable 'SeqUrl' URL address for Seq.

#### Use SEQ locally
To collect and read logs locally you can run Seq locally by docker:
`
docker run -it -p 5341:5341 -p 8080:80 -e ACCEPT_EULA=Y datalust/seq
`
Add envoronment variable to project (or to operation system)
`
SeqUrl = http://localhost:5341
`
User interface you can see at http://localhost:8080

If you want persist log database then use:

`
docker volume create seq
`

`
docker run -it -p 5341:5341 -p 8080:80 -e ACCEPT_EULA=Y --mount source=seq,target=/data datalust/seq
`

TODO: 
* Add opportunity to send log to ELK
* Add opportunity to send log to external server by GRPC

### Use GRPC and Rest
Template service by default ready to work with GRPC services and REst services. application host two ports:
* 5000 - protocol HTTP 1.1 to work with standard Rest api with aspnet and WebAPI.
* 5001 - protocol HTTP 2.0 to wotk with GRPC services.

By default application do not support SSL and HTTPS. Client for GRPS should use http ptotocol with out encription.
Example of server and client you can see in solution: 
* [MonitoringService](https://github.com/swisschain/Service.Template/blob/master/template/src/Example/GrpcServices/MonitoringService.cs) server side
* [Client](https://github.com/swisschain/Service.Template/blob/master/template/src/Example.Client/ExampleClient.cs) client side
* [Console app](https://github.com/swisschain/Service.Template/blob/master/template/tests/Example.TestClient/Program.cs) usage example

Solution by default includes a project for client library: [NAME.Client](https://github.com/swisschain/Service.Template/blob/master/template/src/Example.Client/). You can build NuGet and use this library to simplify integration of other microservices with your application. Client Service install the library in solution, register client in DI container with client interface and star use interface ... like it is an internal implementation

### Use Githib Action as CI for build and deploy docker image
Template solution includes pipelines to build, test and deploy solution artifacts.
You should only setup secret into your GitHub repository:
* DOCKER_USERNAME - user name from [hub.docker.com](https://hub.docker.com/)
* DOCKER_PASSWORD - password or API key from [hub.docker.com](https://hub.docker.com/)
* NUGET_TOCKEN - access token to [nuget.org](https://www.nuget.org/) account

* add CI for build, test, without deply to docker hub

* Use `client-x.y.z` release version pattern to release the API Client nuget
* Use `messages-x.y.z` release version pattern to release the Messaging contract nuget
* Use `service-x.y.z` release version pattern to release service dockers

### Environment variables used
|Variable|Description|Required|Default value|
|-------|-------|-------|-------|
|RemoteSettingsUrl__N|Array of URL addresses for getting confg content which can be overriden by `appsettings.json`. N is index in the array, it should be started from 0. You can specify as many URLs as you need. URLs will be applied in the order as they are specified in the array|no|null|
|SeqUrl|URL address for Seq server to keep logs|no|`null`|
|HttpPort|HTTP port|no|5000|
|GrpcPort|gRpc port|no|5001|
|HOSTNAME|Will be used as the `host-name` key in the logs. If not specified, the OS user name will be used instaed|no|`null`|

### Config variables used
|Variable|Description|Required|Default value|
|-------|-------|-------|-------|
|SeqUrl|URL address for Seq server to keep logs|no|`null`|

### Deployment
Instruction: [readme](https://github.com/swisschain/Service.Template/blob/master/template/deployment/kubernetes/readme.md)

