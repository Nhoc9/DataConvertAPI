# ➕ sendFriendRequest

> Gửi lời mời kết bạn đến một user.

## Endpoint

```
POST /api/sendFriendRequest
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả                     |
| --------- | ------ | -------- | ------------------------- |
| `userId`  | string | ✅       | User ID cần kết bạn       |
| `message` | string | ❌       | Tin nhắn kèm theo lời mời |

## Request Example

```json
{
  "userId": "1234567890",
  "message": "Xin chào, mình muốn kết bạn!"
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
    'message' => 'Xin chào!'
];
$response = callApi('/sendFriendRequest', $body);
```

### Python

```python
result = call_api('/sendFriendRequest', {
    'userId': '1234567890',
    'message': 'Xin chào!'
})
```

### Node.js

```javascript
const result = await callApi("/sendFriendRequest", {
  userId: "1234567890",
  message: "Xin chào!",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendFriendRequest' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"userId":"123","message":"Hi"}'
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
