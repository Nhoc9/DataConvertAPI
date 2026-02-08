# ⭐ addGroupDeputy

> Thêm phó nhóm (admin).

## Endpoint

```
POST /api/addGroupDeputy
```

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                          |
| ---------- | ------ | -------- | ------------------------------ |
| `groupId`  | string | ✅       | ID của nhóm                    |
| `memberId` | string | ✅       | User ID cần bổ nhiệm làm admin |

> ⚠️ **Lưu ý**: Chỉ có owner mới có quyền thêm phó nhóm.

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
$response = callApi('/addGroupDeputy', $body);
```

### Python

```python
result = call_api('/addGroupDeputy', {
    'groupId': '7890123456789012345',
    'memberId': '1234567890'
})
```

### Node.js

```javascript
const result = await callApi("/addGroupDeputy", {
  groupId: "7890123456789012345",
  memberId: "1234567890",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/addGroupDeputy' \
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
