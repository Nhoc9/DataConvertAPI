# 🖼️ changeGroupAvatar

> Đổi avatar nhóm.

## Endpoint

```
POST /api/changeGroupAvatar
```

## Parameters

| Tham số      | Kiểu   | Bắt buộc | Mô tả                              |
| ------------ | ------ | -------- | ---------------------------------- |
| `groupId`    | string | ✅       | ID của nhóm                        |
| `avatarPath` | string | ✅       | Đường dẫn đến file ảnh trên server |

> ⚠️ **Lưu ý**: File ảnh phải tồn tại trên server. Chỉ admin hoặc owner mới có quyền đổi avatar.

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "avatarPath": "./uploads/avatar.jpg"
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
    'groupId' => '7890123456789012345',
    'avatarPath' => './uploads/avatar.jpg'
];
$response = callApi('/changeGroupAvatar', $body);
```

### Python

```python
result = call_api('/changeGroupAvatar', {
    'groupId': '7890123456789012345',
    'avatarPath': './uploads/avatar.jpg'
})
```

### Node.js

```javascript
const result = await callApi("/changeGroupAvatar", {
  groupId: "7890123456789012345",
  avatarPath: "./uploads/avatar.jpg",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/changeGroupAvatar' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","avatarPath":"./avatar.jpg"}'
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
