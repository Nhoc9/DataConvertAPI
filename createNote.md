# 📝 createNote

> Tạo ghi chú trong nhóm.

## Endpoint

```
POST /api/createNote
```

## Parameters

| Tham số   | Kiểu    | Bắt buộc | Mô tả            |
| --------- | ------- | -------- | ---------------- |
| `groupId` | string  | ✅       | ID của nhóm      |
| `title`   | string  | ✅       | Nội dung ghi chú |
| `pinAct`  | boolean | ❌       | Ghim ghi chú     |

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "title": "📌 Nội quy nhóm:\n1. Không spam\n2. Tôn trọng lẫn nhau",
  "pinAct": true
}
```

## Response

```json
{
  "success": true,
  "data": {
    "noteId": "987654321",
    "title": "📌 Nội quy nhóm...",
    "createdTime": 1707456789000
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'groupId' => '7890123456789012345',
    'title' => 'Nội quy nhóm',
    'pinAct' => true
];
$response = callApi('/createNote', $body);
```

### Python

```python
result = call_api('/createNote', {
    'groupId': '7890123456789012345',
    'title': 'Nội quy nhóm',
    'pinAct': True
})
```

### Node.js

```javascript
const result = await callApi("/createNote", {
  groupId: "7890123456789012345",
  title: "Nội quy nhóm",
  pinAct: true,
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/createNote' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","title":"Test Note"}'
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
