---
marp: true
author: SpicyCoder
header: Dapr - Building Blocks
footer: https://github.com/spicycoder/dapr-blocks
---

# Publish & Subscribe

Dapr - `Pub / Sub` building block

---

## Publish

```cs
await _daprClient.PublishEventAsync(
                PubSubName,
                TopicName,
                hero);
```

---

## Subscribe

```cs
[Topic(PubSubName, TopicName)]
[HttpPost("subscribe")]
public async Task<IActionResult> Receive([FromBody] Hero hero) { ... }
```

---

## Redis Configuration

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
spec:
  type: pubsub.redis
  version: v1
  metadata:
  - name: redisHost
    value: localhost:6500
```
