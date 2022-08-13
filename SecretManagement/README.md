# Secret Management

Dapr - `Secret Management` building block

---

## Read Secret

```cs
var secret = await _daprClient.GetSecretAsync(
                SecretStoreName,
                key);
```

---

## Sample Configuration

Create `local-secret-store.yaml` files in some location

Use this location as components directory in tye configuration

---

## Local File Configuration

> Note: When using `tye` for orchestration, `tye` can only access configuration files that are at same or subdirectory level, where `tye.yaml` is present. If you try accessing parent directory, it won't work.

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: secretstore
  namespace: default
spec:
  type: secretstores.local.file
  version: v1
  metadata:
    - name: secretsFile
      value: ./SecretStore/secrets.json
    - name: nestedSeparator
      value: ":"

```
