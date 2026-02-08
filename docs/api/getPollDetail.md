# 📋 getPollDetail

> Lấy chi tiết bình chọn.

## Endpoint

```
POST /api/getPollDetail
```

## Parameters

| Tham số  | Kiểu   | Bắt buộc | Mô tả            |
| -------- | ------ | -------- | ---------------- |
| `pollId` | string | ✅       | ID của bình chọn |

## Request Example

```json
{
  "pollId": "123456789"
}
```

## Response

```json
{
  "success": true,
  "data": {
    "pollId": "123456789",
    "question": "Bạn thích ngôn ngữ nào?",
    "options": [
      { "id": 0, "content": "Python", "voteCount": 5 },
      { "id": 1, "content": "JavaScript", "voteCount": 3 },
      { "id": 2, "content": "PHP", "voteCount": 2 }
    ],
    "totalVote": 10,
    "isLocked": false,
    "createdTime": 1707456789000
  }
}
```

## Code Examples

### PHP

```php
$body = ['pollId' => '123456789'];
$response = callApi('/getPollDetail', $body);
```

### Python

```python
result = call_api('/getPollDetail', {'pollId': '123456789'})
```

### Node.js

```javascript
const result = await callApi("/getPollDetail", { pollId: "123456789" });
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getPollDetail' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"pollId":"123"}'
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
