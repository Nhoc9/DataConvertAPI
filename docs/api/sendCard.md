# 📇 sendCard

> Gửi danh thiếp liên hệ đến user hoặc group.

## Endpoint

```
POST /api/sendCard
```

## Parameters

| Tham số       | Kiểu   | Bắt buộc | Mô tả                          |
| ------------- | ------ | -------- | ------------------------------ |
| `userId`      | string | ✅       | User ID của người được chia sẻ |
| `phoneNumber` | string | ❌       | Số điện thoại                  |
| `threadId`    | string | ✅       | ID cuộc hội thoại              |
| `type`        | number | ❌       | `0` = User, `1` = Group        |
| `ttl`         | number | ❌       | Time to live (ms)              |

## Request Example

```json
{
  "userId": "148956260533496244",
  "phoneNumber": "0912345678",
  "threadId": "1234567890",
  "type": 0
}
```

## Response

```json
{
  "success": true,
  "data": {
    "msgId": 1234567890
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'userId' => '148956260533496244',
    'threadId' => '1234567890',
    'type' => 0
];
$response = callApi('/sendCard', $body);
```

### Python

```python
result = call_api('/sendCard', {
    'userId': '148956260533496244',
    'threadId': '1234567890',
    'type': 0
})
```

### Node.js

```javascript
const result = await callApi("/sendCard", {
  userId: "148956260533496244",
  threadId: "1234567890",
  type: 0,
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendCard' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"userId":"123","threadId":"123","type":0}'
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
