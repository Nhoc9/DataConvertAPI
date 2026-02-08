# ℹ️ getGroupInfo

> Lấy thông tin chi tiết của một nhóm.

## Endpoint

```
POST /api/getGroupInfo
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả       |
| --------- | ------ | -------- | ----------- |
| `groupId` | string | ✅       | ID của nhóm |

## Request Example

```json
{
  "groupId": "7890123456789012345"
}
```

## Response

```json
{
  "success": true,
  "data": {
    "groupId": "7890123456789012345",
    "name": "Nhóm Test",
    "desc": "Mô tả nhóm",
    "type": 0,
    "creatorId": "282026114871729828",
    "createTime": 1707456789000,
    "avt": "https://...",
    "memberIds": ["282026114871729828", "1234567890"],
    "admins": ["282026114871729828"],
    "totalMember": 2
  }
}
```

## Code Examples

### PHP

```php
$body = ['groupId' => '7890123456789012345'];
$response = callApi('/getGroupInfo', $body);
```

### Python

```python
result = call_api('/getGroupInfo', {'groupId': '7890123456789012345'})
```

### Node.js

```javascript
const result = await callApi("/getGroupInfo", {
  groupId: "7890123456789012345",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getGroupInfo' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123"}'
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
