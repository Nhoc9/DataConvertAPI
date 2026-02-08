# ✏️ changeFriendAlias

> Đặt biệt danh cho bạn bè.

## Endpoint

```
POST /api/changeFriendAlias
```

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả              |
| ---------- | ------ | -------- | ------------------ |
| `friendId` | string | ✅       | User ID của bạn bè |
| `alias`    | string | ✅       | Biệt danh mới      |

## Request Example

```json
{
  "friendId": "1234567890",
  "alias": "Anh Tèo"
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
$body = [
    'friendId' => '1234567890',
    'alias' => 'Anh Tèo'
];
$response = callApi('/changeFriendAlias', $body);
```

### Python

```python
result = call_api('/changeFriendAlias', {
    'friendId': '1234567890',
    'alias': 'Anh Tèo'
})
```

### Node.js

```javascript
const result = await callApi("/changeFriendAlias", {
  friendId: "1234567890",
  alias: "Anh Tèo",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/changeFriendAlias' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"friendId":"123","alias":"Test"}'
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
