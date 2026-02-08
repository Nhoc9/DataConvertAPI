# 🖼️ sendImagesToGroup

> Gửi nhiều ảnh đến group.

## Endpoint

```
POST /api/sendImagesToGroup
```

## Parameters

| Tham số      | Kiểu   | Bắt buộc | Mô tả                   |
| ------------ | ------ | -------- | ----------------------- |
| `groupId`    | string | ✅       | Group ID                |
| `imagePaths` | array  | ✅       | Mảng đường dẫn file ảnh |
| `message`    | string | ❌       | Caption đi kèm ảnh      |

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "imagePaths": ["./uploads/photo1.jpg", "./uploads/photo2.jpg"],
  "message": "Album ảnh nhóm"
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
    'groupId' => '7890123456789012345',
    'imagePaths' => ['./photo1.jpg', './photo2.jpg'],
    'message' => 'Album ảnh'
];
$response = callApi('/sendImagesToGroup', $body);
```

### Python

```python
result = call_api('/sendImagesToGroup', {
    'groupId': '7890123456789012345',
    'imagePaths': ['./photo1.jpg', './photo2.jpg'],
    'message': 'Album ảnh'
})
```

### Node.js

```javascript
const result = await callApi("/sendImagesToGroup", {
  groupId: "7890123456789012345",
  imagePaths: ["./photo1.jpg", "./photo2.jpg"],
  message: "Album ảnh",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendImagesToGroup' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","imagePaths":["./p1.jpg"]}'
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
