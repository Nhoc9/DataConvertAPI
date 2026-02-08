# 👤 getUserInfo

> Lấy thông tin chi tiết của một user.

## Endpoint

```
POST /api/getUserInfo
```

## Parameters

| Tham số  | Kiểu   | Bắt buộc | Mô tả                     |
| -------- | ------ | -------- | ------------------------- |
| `userId` | string | ✅       | User ID cần lấy thông tin |

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
  "data": {
    "userId": "1234567890",
    "displayName": "Nguyễn Văn A",
    "zaloName": "Nguyễn Văn A",
    "avatar": "https://...",
    "cover": "https://...",
    "gender": 0,
    "dob": 0,
    "status": "Hello Zalo!",
    "phoneNumber": "0912345678"
  }
}
```

## Code Examples

### PHP

```php
$body = ['userId' => '1234567890'];
$response = callApi('/getUserInfo', $body);
```

### Python

```python
result = call_api('/getUserInfo', {'userId': '1234567890'})
```

### Node.js

```javascript
const result = await callApi("/getUserInfo", { userId: "1234567890" });
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getUserInfo' \
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
