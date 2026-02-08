# 🎨 sendSticker

> Gửi sticker đến user hoặc group.

## Endpoint

```
POST /api/sendSticker
```

## Parameters

| Tham số     | Kiểu   | Bắt buộc | Mô tả                   |
| ----------- | ------ | -------- | ----------------------- |
| `stickerId` | number | ✅\*     | ID của sticker          |
| `sticker`   | object | ✅\*     | Object sticker đầy đủ   |
| `threadId`  | string | ✅       | ID cuộc hội thoại       |
| `type`      | number | ❌       | `0` = User, `1` = Group |

> 💡 Có thể dùng `stickerId` hoặc `sticker` object. Nếu dùng `stickerId`, hệ thống sẽ tự lấy chi tiết sticker.

## Cách lấy Sticker ID

1. Gọi `/getStickers` với keyword để tìm sticker pack
2. Gọi `/getStickersDetail` để lấy chi tiết sticker
3. Sử dụng sticker ID trong `/sendSticker`

## Request Example

### Cách 1: Dùng stickerId

```json
{
  "stickerId": 123456,
  "threadId": "1234567890",
  "type": 0
}
```

### Cách 2: Dùng sticker object

```json
{
  "sticker": {
    "id": 123456,
    "cateId": 789,
    "type": 1,
    "stickerUrl": "https://...",
    "stickerSpriteUrl": "https://...",
    "stickerWebpUrl": null
  },
  "threadId": "1234567890",
  "type": 0
}
```

## Response

```json
{
  "success": true,
  "data": {
    "msgId": 1234567890
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'stickerId' => 123456,
    'threadId' => '1234567890',
    'type' => 0
];
$response = callApi('/sendSticker', $body);
```

### Python

```python
result = call_api('/sendSticker', {
    'stickerId': 123456,
    'threadId': '1234567890',
    'type': 0
})
```

### Node.js

```javascript
const result = await callApi("/sendSticker", {
  stickerId: 123456,
  threadId: "1234567890",
  type: 0,
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/sendSticker' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"stickerId":123456,"threadId":"123","type":0}'
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
