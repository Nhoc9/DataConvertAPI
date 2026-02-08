# ✏️ editNote

> Sửa ghi chú trong nhóm.

## Endpoint

```
POST /api/editNote
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả          |
| --------- | ------ | -------- | -------------- |
| `noteId`  | string | ✅       | ID của ghi chú |
| `title`   | string | ✅       | Nội dung mới   |
| `groupId` | string | ❌       | ID của nhóm    |

## Request Example

```json
{
  "noteId": "987654321",
  "title": "📌 Nội quy nhóm (cập nhật):\n1. Không spam\n2. Tôn trọng lẫn nhau\n3. Không quảng cáo"
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
    'noteId' => '987654321',
    'title' => 'Nội dung mới'
];
$response = callApi('/editNote', $body);
```

### Python

```python
result = call_api('/editNote', {
    'noteId': '987654321',
    'title': 'Nội dung mới'
})
```

### Node.js

```javascript
const result = await callApi("/editNote", {
  noteId: "987654321",
  title: "Nội dung mới",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/editNote' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"noteId":"123","title":"Updated Note"}'
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
