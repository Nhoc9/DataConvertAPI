# 🔍 getStickers

> Tìm kiếm sticker theo từ khóa.

## Endpoint

```
POST /api/getStickers
```

## Parameters

| Tham số   | Kiểu   | Bắt buộc | Mô tả            |
| --------- | ------ | -------- | ---------------- |
| `keyword` | string | ✅       | Từ khóa tìm kiếm |

## Request Example

```json
{
  "keyword": "hello"
}
```

## Response

```json
{
  "success": true,
  "data": [123456, 234567, 345678, 456789]
}
```

> 💡 Kết quả trả về là mảng các sticker ID. Sử dụng `/getStickersDetail` để lấy chi tiết.

## Code Examples

### PHP

```php
$body = ['keyword' => 'hello'];
$response = callApi('/getStickers', $body);
// Kết quả: [123456, 234567, ...]
```

### Python

```python
result = call_api('/getStickers', {'keyword': 'hello'})
sticker_ids = result['data']
```

### Node.js

```javascript
const result = await callApi("/getStickers", { keyword: "hello" });
const stickerIds = result.data;
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getStickers' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"keyword":"hello"}'
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
