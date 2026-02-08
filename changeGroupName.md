# ✏️ changeGroupName

> Đổi tên nhóm.

## Endpoint

```
POST /api/changeGroupName
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả            |
| --------- | ------ | -------- | ---------------- |
| `groupId` | string | ✅       | ID của nhóm      |
| `name`    | string | ✅       | Tên mới của nhóm |

> ⚠️ **Lưu ý**: Chỉ admin hoặc owner mới có quyền đổi tên nhóm.

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "name": "Tên Nhóm Mới"
}
```

## Response

```json
{
  "success": true,
  "data": {
    "status": 0
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'groupId' => '7890123456789012345',
    'name' => 'Tên Nhóm Mới'
];
$response = callApi('/changeGroupName', $body);
```

### Python

```python
result = call_api('/changeGroupName', {
    'groupId': '7890123456789012345',
    'name': 'Tên Nhóm Mới'
})
```

### Node.js

```javascript
const result = await callApi("/changeGroupName", {
  groupId: "7890123456789012345",
  name: "Tên Nhóm Mới",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/changeGroupName' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","name":"New Name"}'
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
