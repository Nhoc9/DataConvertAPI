# 👁️ blockViewFeed

> Chặn một user xem nhật ký (feed) của bot.

## Endpoint

```
POST /api/blockViewFeed
```

## Parameters

| Tham số  | Kiểu   | Bắt buộc | Mô tả                     |
| -------- | ------ | -------- | ------------------------- |
| `userId` | string | ✅       | User ID cần chặn xem feed |

## Request Example

```json
{
  "userId": "1234567890"
}
```

## Response

```json
{
  "success": true,
  "data": ""
}
```

## Code Examples

### PHP

```php
$body = ['userId' => '1234567890'];
$response = callApi('/blockViewFeed', $body);
```

### Python

```python
result = call_api('/blockViewFeed', {'userId': '1234567890'})
```

### Node.js

```javascript
const result = await callApi("/blockViewFeed", { userId: "1234567890" });
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/blockViewFeed' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"userId":"123"}'
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
