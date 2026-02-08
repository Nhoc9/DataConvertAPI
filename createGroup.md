# 👥 createGroup

> Tạo nhóm chat mới.

## Endpoint

```
POST /api/createGroup
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả                          |
| --------- | ------ | -------- | ------------------------------ |
| `name`    | string | ✅       | Tên nhóm                       |
| `members` | array  | ✅       | Mảng các user ID (tối thiểu 2) |

## Request Example

```json
{
  "name": "Nhóm Test",
  "members": ["1234567890", "0987654321"]
}
```

## Response

```json
{
  "success": true,
  "data": {
    "groupId": "7890123456789012345",
    "groupName": "Nhóm Test"
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'name' => 'Nhóm Test',
    'members' => ['1234567890', '0987654321']
];
$response = callApi('/createGroup', $body);
```

### Python

```python
result = call_api('/createGroup', {
    'name': 'Nhóm Test',
    'members': ['1234567890', '0987654321']
})
```

### Node.js

```javascript
const result = await callApi("/createGroup", {
  name: "Nhóm Test",
  members: ["1234567890", "0987654321"],
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/createGroup' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"name":"Test Group","members":["123","456"]}'
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
