# 🎯 getStickersDetail

> Lấy chi tiết sticker theo ID.

## Endpoint

```
POST /api/getStickersDetail
```

## Parameters

| Tham số      | Kiểu         | Bắt buộc | Mô tả                        |
| ------------ | ------------ | -------- | ---------------------------- |
| `stickerIds` | number/array | ✅       | ID hoặc mảng IDs của sticker |

## Request Example

### Lấy 1 sticker

```json
{
  "stickerIds": 123456
}
```

### Lấy nhiều sticker

```json
{
  "stickerIds": [123456, 234567, 345678]
}
```

## Response

```json
{
  "success": true,
  "data": [
    {
      "id": 123456,
      "cateId": 789,
      "type": 1,
      "stickerUrl": "https://zalo.vn/sticker/123456.png",
      "stickerSpriteUrl": "https://...",
      "stickerWebpUrl": null
    }
  ]
}
```

## Workflow: Tìm và Gửi Sticker

```javascript
// 1. Tìm sticker theo keyword
const search = await callApi("/getStickers", { keyword: "hello" });

// 2. Lấy chi tiết sticker đầu tiên
const details = await callApi("/getStickersDetail", {
  stickerIds: search.data[0],
});

// 3. Gửi sticker
await callApi("/sendSticker", {
  sticker: details.data[0],
  threadId: "1234567890",
});
```

## Code Examples

### PHP

```php
$body = ['stickerIds' => [123456, 234567]];
$response = callApi('/getStickersDetail', $body);
```

### Python

```python
result = call_api('/getStickersDetail', {
    'stickerIds': [123456, 234567]
})
```

### Node.js

```javascript
const result = await callApi("/getStickersDetail", {
  stickerIds: [123456, 234567],
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getStickersDetail' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"stickerIds":[123]}'
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
