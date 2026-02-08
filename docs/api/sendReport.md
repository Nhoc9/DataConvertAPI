# 🚨 sendReport

> Báo cáo user vi phạm.

## Endpoint

```
POST /api/sendReport
```

## Parameters

| Tham số  | Kiểu   | Bắt buộc | Mô tả               |
| -------- | ------ | -------- | ------------------- |
| `userId` | string | ✅       | User ID cần báo cáo |
| `reason` | string | ✅       | Lý do báo cáo       |

## Request Example

```json
{
  "userId": "1234567890",
  "reason": "Spam tin nhắn quảng cáo"
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
$body = [
    'userId' => '1234567890',
    'reason' => 'Spam tin nhắn'
];
$response = callApi('/sendReport', $body);
```

### Python

```python
result = call_api('/sendReport', {
    'userId': '1234567890',
    'reason': 'Spam tin nhắn'
})
```

### Node.js

```javascript
const result = await callApi("/sendReport", {
  userId: "1234567890",
  reason: "Spam tin nhắn",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendReport' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"userId":"123","reason":"spam"}'
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
