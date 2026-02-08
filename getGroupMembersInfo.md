# 👥 getGroupMembersInfo

> Lấy thông tin chi tiết của thành viên trong nhóm.

## Endpoint

```
POST /api/getGroupMembersInfo
```

## Parameters

| Tham số    | Kiểu         | Bắt buộc | Mô tả                      |
| ---------- | ------------ | -------- | -------------------------- |
| `memberId` | string/array | ✅       | User ID hoặc mảng User IDs |

## Request Example

### Lấy 1 thành viên

```json
{
  "memberId": "1234567890"
}
```

### Lấy nhiều thành viên

```json
{
  "memberId": ["1234567890", "0987654321"]
}
```

## Response

```json
{
  "success": true,
  "data": [
    {
      "userId": "1234567890",
      "displayName": "Nguyễn Văn A",
      "avatar": "https://...",
      "phoneNumber": "0912345678"
    }
  ]
}
```

## Code Examples

### PHP

```php
// Lấy nhiều thành viên
$body = ['memberId' => ['1234567890', '0987654321']];
$response = callApi('/getGroupMembersInfo', $body);
```

### Python

```python
result = call_api('/getGroupMembersInfo', {
    'memberId': ['1234567890', '0987654321']
})
```

### Node.js

```javascript
const result = await callApi("/getGroupMembersInfo", {
  memberId: ["1234567890", "0987654321"],
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getGroupMembersInfo' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"memberId":"123"}'
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
