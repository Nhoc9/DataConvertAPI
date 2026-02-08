# ❤️ addReaction

> React tin nhắn với 50+ loại icon (heart, like, haha, wow...).

## Endpoint

```
POST /api/addReaction
```

## Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                                 |
| ---------- | ------ | -------- | ------------------------------------- |
| `icon`     | string | ✅       | Tên reaction (xem danh sách bên dưới) |
| `message`  | object | ✅       | Object chứa `msgId` và `cliMsgId`     |
| `threadId` | string | ✅       | ID cuộc hội thoại                     |
| `type`     | number | ❌       | `0` = User, `1` = Group               |

## Danh sách Reactions

| Icon     | Emoji | Icon           | Emoji |
| -------- | ----- | -------------- | ----- |
| `heart`  | ❤️    | `like`         | 👍    |
| `haha`   | 😄    | `wow`          | 😮    |
| `cry`    | 😢    | `angry`        | 😠    |
| `kiss`   | 😘    | `tears_of_joy` | 😂    |
| `rose`   | 🌹    | `broken_heart` | 💔    |
| `love`   | 😍    | `pray`         | 🙏    |
| `ok`     | 👌    | `peace`        | ✌️    |
| `thanks` | 🙏    | `beer`         | 🍺    |

## Request Example

```json
{
  "icon": "heart",
  "message": {
    "msgId": "1234567890123456789",
    "cliMsgId": "abc123def456"
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
    "msgIds": "1234567890123456789"
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'icon' => 'heart',
    'message' => ['msgId' => '123', 'cliMsgId' => '456'],
    'threadId' => '1234567890'
];
$response = callApi('/addReaction', $body);
```

### Python

```python
result = call_api('/addReaction', {
    'icon': 'heart',
    'message': {'msgId': '123', 'cliMsgId': '456'},
    'threadId': '1234567890'
})
```

### Node.js

```javascript
const result = await callApi("/addReaction", {
  icon: "heart",
  message: { msgId: "123", cliMsgId: "456" },
  threadId: "1234567890",
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/addReaction' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"icon":"heart","message":{},"threadId":"123"}'
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
