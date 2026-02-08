# 🖼️ sendImageToGroup

> Gửi một ảnh đến group.

## Endpoint

```
POST /api/sendImageToGroup
```

## Parameters

| Tham số     | Kiểu   | Bắt buộc | Mô tả                          |
| ----------- | ------ | -------- | ------------------------------ |
| `groupId`   | string | ✅       | Group ID                       |
| `imagePath` | string | ✅       | Đường dẫn file ảnh trên server |
| `message`   | string | ❌       | Caption đi kèm ảnh             |

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "imagePath": "./uploads/photo.jpg",
  "message": "Ảnh gửi vào nhóm"
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
    'imagePath' => './uploads/photo.jpg',
    'message' => 'Caption ảnh'
];
$response = callApi('/sendImageToGroup', $body);
```

### Python

```python
result = call_api('/sendImageToGroup', {
    'groupId': '7890123456789012345',
    'imagePath': './uploads/photo.jpg',
    'message': 'Caption ảnh'
})
```

### Node.js

```javascript
const result = await callApi("/sendImageToGroup", {
  groupId: "7890123456789012345",
  imagePath: "./uploads/photo.jpg",
  message: "Caption ảnh",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendImageToGroup' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","imagePath":"./photo.jpg"}'
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
