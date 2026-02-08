# 🖼️ sendImagesToUser

> Gửi nhiều ảnh đến user.

## Endpoint

```
POST /api/sendImagesToUser
```

## Parameters

| Tham số      | Kiểu   | Bắt buộc | Mô tả                   |
| ------------ | ------ | -------- | ----------------------- |
| `threadId`   | string | ✅       | User ID người nhận      |
| `imagePaths` | array  | ✅       | Mảng đường dẫn file ảnh |
| `message`    | string | ❌       | Caption đi kèm ảnh      |

## Request Example

```json
{
  "threadId": "1234567890",
  "imagePaths": [
    "./uploads/photo1.jpg",
    "./uploads/photo2.jpg",
    "./uploads/photo3.jpg"
  ],
  "message": "Đây là album ảnh"
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
    'imagePaths' => ['./photo1.jpg', './photo2.jpg'],
    'message' => 'Album ảnh'
];
$response = callApi('/sendImagesToUser', $body);
```

### Python

```python
result = call_api('/sendImagesToUser', {
    'threadId': '1234567890',
    'imagePaths': ['./photo1.jpg', './photo2.jpg'],
    'message': 'Album ảnh'
})
```

### Node.js

```javascript
const result = await callApi("/sendImagesToUser", {
  threadId: "1234567890",
  imagePaths: ["./photo1.jpg", "./photo2.jpg"],
  message: "Album ảnh",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendImagesToUser' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"threadId":"123","imagePaths":["./p1.jpg"]}'
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
