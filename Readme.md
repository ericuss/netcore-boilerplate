
## Run application

### Running in docker compose
execute sh _build.sh

### Running in Visual Studio
You need de DB, change the connection string and set as Startup project the ./Src/Clients/Lanre.Clients.Host/

## Run documentation

execute sh _build-docs.sh

## Run tests

execute sh _build-tests.sh


# K8s

source: https://github.com/kubernetes/dashboard
kubectl proxy
http://localhost:8001/api/v1/namespaces/kube-system/services/https:kubernetes-dashboard:/proxy/#!/login
kubectl -n kubernetes-dashboard describe secret $(kubectl -n kubernetes-dashboard get secret | grep admin-user | awk '{print $1}')


kubectl config set-context --current --namespace=lanrens