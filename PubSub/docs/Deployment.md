# Deployment

Create Redis PubSub by following <https://docs.dapr.io/getting-started/tutorials/configure-state-pubsub/>

---

## Install `Redis` PubSub

Install `Redis` to the cluster

```ps1
helm repo add bitnami https://charts.bitnami.com/bitnami
helm repo update
helm install redis bitnami/redis --set image.tag=6.2
```

Create file `redis-pubsub.yaml` with content as below

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: default
spec:
  type: pubsub.redis
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
kubectl apply -f ./deployment/redis-pubsub.yaml
```
