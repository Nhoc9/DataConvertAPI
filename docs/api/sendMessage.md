# 📤 sendMessage

> Gửi tin nhắn văn bản đến user hoặc group, hỗ trợ rich text styling.

## Endpoint

```
POST /api/sendmessage
```

## Headers

| Header       | Giá trị                 |
| ------------ | ----------------------- |
| Content-Type | `application/json`      |
| X-Api-Token  | API Token của bot       |
| X-Signature  | `sha256=` + HMAC-SHA256 |

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                                 |
| ---------- | ------ | -------- | ------------------------------------- |
| `message`  | string | ✅       | Nội dung tin nhắn                     |
| `threadId` | string | ✅       | ID người nhận hoặc group              |
| `type`     | number | ❌       | `0` = User, `1` = Group (mặc định: 0) |
| `styles`   | array  | ❌       | Định dạng rich text                   |

## Styles Format

```json
{
  "styles": [
    { "subText": "PHP", "style": "bold" },
    { "subText": "Hello", "style": "italic" },
    { "subText": "Error", "style": "color", "color": "db342e" }
  ]
}
```

**Các style hỗ trợ:**

- `bold`, `italic`, `underline`, `strikethrough`
- `red`, `orange`, `yellow`, `green` (màu preset)
- `color` + `color: "RRGGBB"` (màu tùy chỉnh)
- `small`, `big` (kích cỡ font)

## Request Example

```json
{
  "message": "Xin chào PHP! Đây là tin nhắn quan trọng",
  "threadId": "1234567890",
  "type": 0,
  "styles": [
    { "subText": "PHP", "style": "bold" },
    { "subText": "quan trọng", "style": "color", "color": "ff0000" }
  ]
}
```

## Response

### Success

```json
{
  "success": true,
  "data": {
    "message": { "msgId": 1234567890 },
    "attachment": []
  }
}
```

### Error

```json
{
  "success": false,
  "error": "Account not found"
}
```

## Code Examples

### PHP

```php
$body = [
    'message' => 'Xin chào!',
    'threadId' => '1234567890',
    'type' => 0
];
$response = callApi('/sendmessage', $body);
```

### Python

```python
result = call_api('/sendmessage', {
    'message': 'Xin chào!',
    'threadId': '1234567890',
    'type': 0
})
```

### Node.js

```javascript
const result = await callApi("/sendmessage", {
  message: "Xin chào!",
  threadId: "1234567890",
  type: 0,
});
```

### Postman

**cURL Import:**

```bash
curl -X POST 'http://localhost:3000/api/sendmessage' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"message":"Xin chào!","threadId":"1234567890","type":0}'
```

**Pre-request Script:** (Dán vào tab Pre-request Script)

```javascript
const apiSecret = pm.environment.get("api_secret");
const apiToken = pm.environment.get("api_token");
const rawBody = pm.request.body.raw || "{}";
const signature =
  "sha256=" + CryptoJS.HmacSHA256(rawBody, apiSecret).toString();

pm.request.headers.add({ key: "X-Api-Token", value: apiToken });
pm.request.headers.add({ key: "X-Signature", value: signature });
```

> 📘 Xem chi tiết: [Hướng dẫn Postman](./POSTMAN.md)
