# 👑 changeGroupOwner

> Chuyển quyền sở hữu nhóm cho người khác.

## Endpoint

```
POST /api/changeGroupOwner
```

## Parameters

| Tham số      | Kiểu   | Bắt buộc | Mô tả                    |
| ------------ | ------ | -------- | ------------------------ |
| `groupId`    | string | ✅       | ID của nhóm              |
| `newOwnerId` | string | ✅       | User ID của chủ nhóm mới |

> ⚠️ **Lưu ý**: Chỉ có owner mới có quyền chuyển quyền. Hành động này **không thể hoàn tác**!

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "newOwnerId": "1234567890"
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
    'newOwnerId' => '1234567890'
];
$response = callApi('/changeGroupOwner', $body);
```

### Python

```python
result = call_api('/changeGroupOwner', {
    'groupId': '7890123456789012345',
    'newOwnerId': '1234567890'
})
```

### Node.js

```javascript
const result = await callApi("/changeGroupOwner", {
  groupId: "7890123456789012345",
  newOwnerId: "1234567890",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/changeGroupOwner' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","newOwnerId":"456"}'
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
