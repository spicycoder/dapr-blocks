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
