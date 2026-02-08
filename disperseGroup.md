# 💣 disperseGroup

> Giải tán nhóm (xóa vĩnh viễn).

## Endpoint

```
POST /api/disperseGroup
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả                    |
| --------- | ------ | -------- | ------------------------ |
| `groupId` | string | ✅       | ID của nhóm cần giải tán |

> ⚠️ **CẢNH BÁO**: Hành động này **KHÔNG THỂ HOÀN TÁC**! Tất cả tin nhắn và dữ liệu trong nhóm sẽ bị xóa vĩnh viễn.

> 🔒 **Lưu ý**: Chỉ có owner mới có quyền giải tán nhóm.

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
  "data": {}
}
```

## Code Examples

### PHP

```php
// ⚠️ CẨN THẬN: Không thể hoàn tác!
$body = ['groupId' => '7890123456789012345'];
$response = callApi('/disperseGroup', $body);
```

### Python

```python
# ⚠️ CẨN THẬN: Không thể hoàn tác!
result = call_api('/disperseGroup', {
    'groupId': '7890123456789012345'
})
```

### Node.js

```javascript
// ⚠️ CẨN THẬN: Không thể hoàn tác!
const result = await callApi("/disperseGroup", {
  groupId: "7890123456789012345",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/disperseGroup' \
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
