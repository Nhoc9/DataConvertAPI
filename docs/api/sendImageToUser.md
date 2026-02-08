# 🖼️ sendImageToUser

> Gửi một ảnh đến user.

## Endpoint

```
POST /api/sendImageToUser
```

## Parameters

| Tham số     | Kiểu   | Bắt buộc | Mô tả                          |
| ----------- | ------ | -------- | ------------------------------ |
| `threadId`  | string | ✅       | User ID người nhận             |
| `imagePath` | string | ✅       | Đường dẫn file ảnh trên server |
| `message`   | string | ❌       | Caption đi kèm ảnh             |

## Request Example

```json
{
  "threadId": "1234567890",
  "imagePath": "./uploads/photo.jpg",
  "message": "Đây là ảnh mẫu"
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
    'threadId' => '1234567890',
    'imagePath' => './uploads/photo.jpg',
    'message' => 'Caption ảnh'
];
$response = callApi('/sendImageToUser', $body);
```

### Python

```python
result = call_api('/sendImageToUser', {
    'threadId': '1234567890',
    'imagePath': './uploads/photo.jpg',
    'message': 'Caption ảnh'
})
```

### Node.js

```javascript
const result = await callApi("/sendImageToUser", {
  threadId: "1234567890",
  imagePath: "./uploads/photo.jpg",
  message: "Caption ảnh",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendImageToUser' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"threadId":"123","imagePath":"./photo.jpg"}'
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
