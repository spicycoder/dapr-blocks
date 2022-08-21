# Deployment

Create State Store by following <https://docs.dapr.io/getting-started/tutorials/configure-state-pubsub/>

---
## Install `Redis` State Store

Install `Redis` to the cluster

```ps1
helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo update
helm install redis bitnami/redis --set image.tag=6.2
```

Create file `redis-state.yaml` with content as below

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
  namespace: default
spec:
  type: state.redis
  version: v1
  metadata:
  - name: redisHost
    value: redis-master.default.svc.cluster.local:6379
  - name: redisPassword
    secretKeyRef:
      name: redis
      key: redis-password
```

Apply the configuration

```ps1
kubectl apply -f ./deployment/redis-state.yaml
```
