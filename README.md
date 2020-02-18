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

