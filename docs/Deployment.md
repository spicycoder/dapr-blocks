# Deployment

## Initialize `Dapr` on `Kubernetes`

Initialize with `mTLS` disabled

```ps1
dapr init -k --enable-mtls=false
```

Verify with

```ps1
kubectl get all -n dapr-system
```

---
