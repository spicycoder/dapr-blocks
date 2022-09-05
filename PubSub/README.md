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
    value: localhost:6379
```

---

## RabbitMQ Configuration

```yaml
apiVersion: dapr.io/v1alpha1
kind: Component
metadata:
  name: pubsub
  namespace: default
spec:
  type: pubsub.rabbitmq
  version: v1
  metadata:
  - name: host
    value: "amqp://localhost:5672"
```
