# 📌 pinConversations

> Ghim cuộc hội thoại lên đầu danh sách.

## Endpoint

```
POST /api/pinConversations
```

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                               |
| ---------- | ------ | -------- | ----------------------------------- |
| `threadId` | string | ✅       | ID cuộc hội thoại (user hoặc group) |

## Request Example

```json
{
  "threadId": "1234567890"
}
```

## Response

```json
{
  "success": true,
  "data": {}
}
```

## Code Examples

### PHP

```php
$body = ['threadId' => '1234567890'];
$response = callApi('/pinConversations', $body);
```

### Python

```python
result = call_api('/pinConversations', {'threadId': '1234567890'})
```

### Node.js

```javascript
const result = await callApi("/pinConversations", { threadId: "1234567890" });
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/pinConversations' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"threadId":"123"}'
```

**Pre-request Script:** (Dán vào tab Pre-request Script)
```javascript
const apiSecret = pm.environment.get('api_secret');
const apiToken = pm.environment.get('api_token');
const rawBody = pm.request.body.raw || '{}';
const signature = 'sha256=' + CryptoJS.HmacSHA256(rawBody, apiSecret).toString();

pm.request.headers.add({ key: 'X-Api-Token', value: apiToken });
pm.request.headers.add({ key: 'X-Signature', value: signature });
```

> 📘 Xem chi tiết: [Hướng dẫn Postman](./POSTMAN.md)
