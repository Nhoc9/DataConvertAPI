# ➕ addUserToGroup

> Thêm thành viên vào nhóm.

## Endpoint

```
POST /api/addUserToGroup
```

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                |
| ---------- | ------ | -------- | -------------------- |
| `groupId`  | string | ✅       | ID của nhóm          |
| `memberId` | string | ✅       | User ID cần thêm vào |

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "memberId": "1234567890"
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
    'memberId' => '1234567890'
];
$response = callApi('/addUserToGroup', $body);
```

### Python

```python
result = call_api('/addUserToGroup', {
    'groupId': '7890123456789012345',
    'memberId': '1234567890'
})
```

### Node.js

```javascript
const result = await callApi("/addUserToGroup", {
  groupId: "7890123456789012345",
  memberId: "1234567890",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/addUserToGroup' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","memberId":"456"}'
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
