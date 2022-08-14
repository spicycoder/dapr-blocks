# Bindings

Dapr - `Bindings` building block

---

## Send Email

```cs
await _daprClient.InvokeBindingAsync(
                BindingName,
                Operation,
                body,
                metadata);
```

---

## SMTP Configurations

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: sendemail
spec:
  type: bindings.smtp
  version: v1
  metadata:
  - name: host
    value: localhost
  - name: port
    value: 1025
  - name: skipTLSVerify
    value: true
```

---

## Cron Configuration

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: scheduled
  namespace: default
spec:
  type: bindings.cron
  version: v1
  metadata:
  - name: schedule
    value: "@every 3s"
  - name: route
    value: /api/Bindings/send-email
```
