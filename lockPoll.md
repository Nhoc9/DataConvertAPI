# 🔒 lockPoll

> Khóa bình chọn (ngừng nhận vote).

## Endpoint

```
POST /api/lockPoll
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả            |
| --------- | ------ | -------- | ---------------- |
| `pollId`  | string | ✅       | ID của bình chọn |
| `groupId` | string | ✅       | ID của nhóm      |

## Request Example

```json
{
  "pollId": "123456789",
  "groupId": "7890123456789012345"
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
    'pollId' => '123456789',
    'groupId' => '7890123456789012345'
];
$response = callApi('/lockPoll', $body);
```

### Python

```python
result = call_api('/lockPoll', {
    'pollId': '123456789',
    'groupId': '7890123456789012345'
})
```

### Node.js

```javascript
const result = await callApi("/lockPoll", {
  pollId: "123456789",
  groupId: "7890123456789012345",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/lockPoll' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"pollId":"123","groupId":"456"}'
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
