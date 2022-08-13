# State Management

Dapr - `State Management` building block

## Save State

```cs
await _daprClient.SaveStateAsync<T>(
                StateStoreName,
                key,
                value);
```

## Read State

```cs
var value = await _daprClient.GetStateAsync<T>(
                StateStoreName,
                key);
```

## Sample Configuration

Create `statestore.yaml` files in some location

Use this location as components directory in tye configuration

### Redis Configuration

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: statestore
spec:
  type: state.redis
  version: v1
  metadata:
    - name: redisHost
      value: localhost:6379
    - name: redisPassword
      value: ""
    - name: actorStateStore
      value: "true"
```
