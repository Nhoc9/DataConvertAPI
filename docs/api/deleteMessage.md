# 🗑️ deleteMessage

> Thu hồi/xóa tin nhắn đã gửi.

## Endpoint

```
POST /api/deleteMessage
```

## Parameters

| Tham số    | Kiểu    | Bắt buộc | Mô tả                                         |
| ---------- | ------- | -------- | --------------------------------------------- |
| `cliMsgId` | string  | ✅       | Client message ID                             |
| `msgId`    | string  | ✅       | Server message ID                             |
| `uidFrom`  | string  | ✅       | User ID của người gửi                         |
| `threadId` | string  | ✅       | ID cuộc hội thoại                             |
| `type`     | number  | ❌       | `0` = User, `1` = Group                       |
| `onlyMe`   | boolean | ❌       | `true` = chỉ xóa phía mình, `false` = thu hồi |

> ⚠️ **Lưu ý**: Chỉ có thể thu hồi tin nhắn trong vòng 24h. Sau 24h chỉ có thể xóa phía mình (`onlyMe: true`).

## Request Example

```json
{
  "cliMsgId": "abc123def456",
  "msgId": "1234567890123456789",
  "uidFrom": "282026114871729828",
  "threadId": "1234567890",
  "type": 0,
  "onlyMe": false
}
```

## Response

```json
{
  "success": true,
  "data": {
    "status": 0
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'cliMsgId' => 'abc123',
    'msgId' => '123456789',
    'uidFrom' => '282026114871729828',
    'threadId' => '1234567890',
    'onlyMe' => false
];
$response = callApi('/deleteMessage', $body);
```

### Python

```python
result = call_api('/deleteMessage', {
    'cliMsgId': 'abc123',
    'msgId': '123456789',
    'uidFrom': '282026114871729828',
    'threadId': '1234567890',
    'onlyMe': False
})
```

### Node.js

```javascript
const result = await callApi("/deleteMessage", {
  cliMsgId: "abc123",
  msgId: "123456789",
  uidFrom: "282026114871729828",
  threadId: "1234567890",
  onlyMe: false,
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/deleteMessage' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"cliMsgId":"abc","msgId":"123","uidFrom":"123","threadId":"123"}'
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
