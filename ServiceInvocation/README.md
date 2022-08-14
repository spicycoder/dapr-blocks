---
marp: true
author: SpicyCoder
header: Dapr - Building Blocks
footer: https://github.com/spicycoder/dapr-blocks
---

# Service Invocation

Dapr - `Service Invocation` building block

---

## Invoke Service

```cs
var contact = await _daprClient.InvokeMethodAsync<Contact>(
                HttpMethod.Get,
                ContactsApiName,
                $"/api/Contacts/read?name={name}");
```
