---
marp: true
author: SpicyCoder
header: Dapr - Building Blocks
footer: https://github.com/spicycoder/dapr-blocks
---

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

---

## Local File Configuration

Create `local-secret-store.yaml` files in some location, with content as above. Use this location as components directory in tye configuration

> Note: When using `tye` for orchestration, `tye` can only access configuration files that are at same or subdirectory level, where `tye.yaml` is present. If you try accessing parent directory, it won't work.
