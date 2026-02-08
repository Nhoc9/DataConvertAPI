# 🖼️ changeAccountAvatar

> Đổi avatar của bot.

## Endpoint

```
POST /api/changeAccountAvatar
```

## Parameters

| Tham số      | Kiểu   | Bắt buộc | Mô tả                          |
| ------------ | ------ | -------- | ------------------------------ |
| `avatarPath` | string | ✅       | Đường dẫn file ảnh trên server |

## Request Example

```json
{
  "avatarPath": "./uploads/new_avatar.jpg"
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
$body = ['avatarPath' => './uploads/avatar.jpg'];
$response = callApi('/changeAccountAvatar', $body);
```

### Python

```python
result = call_api('/changeAccountAvatar', {
    'avatarPath': './uploads/avatar.jpg'
})
```

### Node.js

```javascript
const result = await callApi("/changeAccountAvatar", {
  avatarPath: "./uploads/avatar.jpg",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/changeAccountAvatar' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"avatarPath":"./avatar.jpg"}'
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
