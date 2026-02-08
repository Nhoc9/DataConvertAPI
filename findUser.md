# 🔍 findUser

> Tìm kiếm người dùng Zalo theo số điện thoại.

## Endpoint

```
POST /api/findUser
```

## Parameters

| Tham số       | Kiểu   | Bắt buộc | Mô tả                 |
| ------------- | ------ | -------- | --------------------- |
| `phoneNumber` | string | ✅       | Số điện thoại cần tìm |

## Request Example

```json
{
  "phoneNumber": "0912345678"
}
```

## Response

```json
{
  "success": true,
  "data": {
    "userId": "1234567890",
    "displayName": "Nguyễn Văn A",
    "avatar": "https://...",
    "isFriend": false
  }
}
```

## Code Examples

### PHP

```php
$body = ['phoneNumber' => '0912345678'];
$response = callApi('/findUser', $body);
```

### Python

```python
result = call_api('/findUser', {'phoneNumber': '0912345678'})
```

### Node.js

```javascript
const result = await callApi("/findUser", { phoneNumber: "0912345678" });
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/findUser' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"phoneNumber":"0912345678"}'
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
