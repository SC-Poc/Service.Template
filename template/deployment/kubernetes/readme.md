1. Copy `Service-ServiceName` and `Service-ServiceName-Worker` to the https://github.com/SC-Poc/kubernetes-swisschain/tree/master/Kubernetes/03.Pods/SwisschainProductName. 
2. Add services namespace if necessary.
3. Copy `secret.yaml` to the https://github.com/SC-Poc/kubernetes-swisschain-secret/tree/master/03.Pods/SwisschainProductName/Service-ServiceName
4. Copy `appsettings.json` to https://github.com/SC-Poc/kubernetes-swisschain/tree/master/Settings/swisschain-product-name/swisschain-service-name.json
5. Replace all the secrets in the `swisschain-service-name.json` with placeholders like `${PlaceHolderName}`. 
Use global-scoped, product-scoped, and service-scoped placeholders. If you not sure which scope particular placeholder has, ask the team.
6. Put placeholders with values to the settings blob in Azure Storage (TODO: specify the blob here)