# 📚 Zalo Multi-Bot Integration API

> **Tài liệu tích hợp API cho hệ thống Webhook/API Zalo Multi-bot**
>
> Phiên bản: 2.0 | Cập nhật: 02/2026

---

## 📖 Giới thiệu

**Zalo Multi-Bot Integration API** cho phép bạn:

- ✅ **Nhận Webhook** từ nhiều bot Zalo về server của bạn
- ✅ **Gọi API** để điều khiển bot (gửi tin nhắn, quản lý nhóm, reaction...)
- ✅ **Bảo mật** với HMAC-SHA256 signature

> 💡 **Mục đích**: Giúp developer tích hợp Zalo bot vào hệ thống riêng, xây dựng chatbot, CRM, hoặc automation workflow.

---

## 🔐 Authentication

> ⚠️ **CỰC KỲ QUAN TRỌNG**: Mọi request đến API đều phải có signature hợp lệ!

### Cơ chế xác thực

| Thành phần     | Mô tả                         |
| -------------- | ----------------------------- |
| **Thuật toán** | HMAC-SHA256                   |
| **Header**     | `X-Api-Token` + `X-Signature` |
| **Secret**     | Mỗi bot có `api_secret` riêng |

### Cách tạo Signature

```
Signature = "sha256=" + HMAC-SHA256(request_body, api_secret)
```

**Quy trình:**

1. Lấy **raw JSON body** của request
2. Dùng `api_secret` của bot để hash
3. Thêm prefix `sha256=` vào kết quả
4. Gửi trong header `X-Signature`

---

## 📋 Headers & Parameters

### Required Headers

| Header         | Kiểu   | Bắt buộc | Mô tả                          |
| -------------- | ------ | -------- | ------------------------------ |
| `Content-Type` | string | ✅       | Phải là `application/json`     |
| `X-Api-Token`  | string | ✅       | API Token của bot (public)     |
| `X-Signature`  | string | ✅       | `sha256=` + HMAC hash của body |

### Common Parameters

| Tham số    | Kiểu   | Bắt buộc | Mô tả                                     |
| ---------- | ------ | -------- | ----------------------------------------- |
| `threadId` | string | Tùy API  | ID cuộc hội thoại (user ID hoặc group ID) |
| `type`     | number | ❌       | `0` = User, `1` = Group (mặc định: 0)     |
| `message`  | string | Tùy API  | Nội dung tin nhắn                         |

---

## 💻 Code Examples

### PHP (cURL + hash_hmac)

```php
<?php
$api_token = 'YOUR_API_TOKEN';
$api_secret = 'YOUR_API_SECRET';
$base_url = 'http://localhost:3000/api';

// Chuẩn bị body
$body = [
    'message' => 'Xin chào từ PHP!',
    'threadId' => '1234567890',
    'type' => 0
];
$json_body = json_encode($body);

// Tạo signature
$signature = 'sha256=' . hash_hmac('sha256', $json_body, $api_secret);

// Gọi API
$ch = curl_init();
curl_setopt_array($ch, [
    CURLOPT_URL => $base_url . '/sendmessage',
    CURLOPT_RETURNTRANSFER => true,
    CURLOPT_POST => true,
    CURLOPT_POSTFIELDS => $json_body,
    CURLOPT_HTTPHEADER => [
        'Content-Type: application/json',
        'X-Api-Token: ' . $api_token,
        'X-Signature: ' . $signature
    ]
]);

$response = curl_exec($ch);
$http_code = curl_getinfo($ch, CURLINFO_HTTP_CODE);
curl_close($ch);

echo "Status: $http_code\n";
echo "Response: $response\n";
?>
```

---

### Python (requests + hmac)

```python
import json
import hmac
import hashlib
import requests

API_TOKEN = 'YOUR_API_TOKEN'
API_SECRET = 'YOUR_API_SECRET'
BASE_URL = 'http://localhost:3000/api'

def call_api(endpoint, data):
    # Chuẩn bị body
    json_body = json.dumps(data, separators=(',', ':'))

    # Tạo signature
    signature = 'sha256=' + hmac.new(
        API_SECRET.encode('utf-8'),
        json_body.encode('utf-8'),
        hashlib.sha256
    ).hexdigest()

    # Gọi API
    response = requests.post(
        f'{BASE_URL}{endpoint}',
        data=json_body,
        headers={
            'Content-Type': 'application/json',
            'X-Api-Token': API_TOKEN,
            'X-Signature': signature
        }
    )

    return response.json()

# Ví dụ: Gửi tin nhắn
result = call_api('/sendmessage', {
    'message': 'Xin chào từ Python!',
    'threadId': '1234567890',
    'type': 0
})
print(result)

# Ví dụ: Lấy danh sách bạn bè
friends = call_api('/getAllFriends', {'count': 100, 'page': 1})
print(friends)
```

---

### Node.js (axios + crypto)

```javascript
const axios = require("axios");
const crypto = require("crypto");

const API_TOKEN = "YOUR_API_TOKEN";
const API_SECRET = "YOUR_API_SECRET";
const BASE_URL = "http://localhost:3000/api";

async function callApi(endpoint, data) {
  // Chuẩn bị body
  const jsonBody = JSON.stringify(data);

  // Tạo signature
  const signature =
    "sha256=" +
    crypto
      .createHmac("sha256", API_SECRET)
      .update(jsonBody, "utf8")
      .digest("hex");

  // Gọi API
  const response = await axios.post(`${BASE_URL}${endpoint}`, data, {
    headers: {
      "Content-Type": "application/json",
      "X-Api-Token": API_TOKEN,
      "X-Signature": signature,
    },
  });

  return response.data;
}

// Ví dụ: Gửi tin nhắn
callApi("/sendmessage", {
  message: "Xin chào từ Node.js!",
  threadId: "1234567890",
  type: 0,
})
  .then(console.log)
  .catch(console.error);

// Ví dụ: React tin nhắn
callApi("/addReaction", {
  icon: "heart",
  message: { msgId: "123", cliMsgId: "456" },
  threadId: "1234567890",
})
  .then(console.log)
  .catch(console.error);
```

---

### Postman

#### Cách 1: Import cURL

```bash
curl -X POST 'http://localhost:3000/api/sendmessage' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: YOUR_API_TOKEN' \
  -H 'X-Signature: sha256=YOUR_CALCULATED_SIGNATURE' \
  -d '{"message":"Hello","threadId":"1234567890","type":0}'
```

#### Cách 2: Pre-request Script (Tự động tính HMAC)

**Bước 1:** Tạo Environment với 2 biến:

- `api_token`: Token của bot
- `api_secret`: Secret của bot

**Bước 2:** Thêm Pre-request Script vào Collection:

```javascript
// Pre-request Script - Tự động tính HMAC Signature
const apiSecret = pm.environment.get("api_secret");

// Lấy raw body
const rawBody = pm.request.body.raw;

// Tính HMAC-SHA256
const signature =
  "sha256=" + CryptoJS.HmacSHA256(rawBody, apiSecret).toString();

// Set header
pm.request.headers.add({
  key: "X-Api-Token",
  value: pm.environment.get("api_token"),
});

pm.request.headers.add({
  key: "X-Signature",
  value: signature,
});

console.log("✅ Signature generated:", signature);
```

**Bước 3:** Chỉ cần điền Body JSON, Postman sẽ tự tính signature!

---

## 📨 Webhook Data Structure

Khi có sự kiện từ Zalo, hệ thống sẽ gửi POST request đến Webhook URL của bạn:

### Message Webhook

```json
{
  "type": "message",
  "data": {
    "msgId": "1234567890123456789",
    "cliMsgId": "abc123def456",
    "uidFrom": "282026114871729828",
    "idTo": "148956260533496244",
    "dName": "Nguyễn Văn A",
    "content": "Nội dung tin nhắn",
    "ts": "1707456789000",
    "msgType": "chat",
    "ttl": 0
  },
  "threadId": "148956260533496244",
  "threadType": 0,
  "isSelf": false,
  "botId": "282026114871729828"
}
```

### Reaction Webhook

```json
{
  "type": "reaction",
  "data": {
    "msgId": "1234567890123456789",
    "uidFrom": "148956260533496244",
    "icon": "/-heart",
    "rType": 1
  },
  "threadId": "282026114871729828",
  "isSelf": false,
  "botId": "282026114871729828"
}
```

### Group Event Webhook

```json
{
  "type": "group_event",
  "data": {
    "groupId": "7890123456789012345",
    "groupName": "Nhóm Test",
    "updateMembers": {
      "addedMembers": ["111222333444"],
      "removedMembers": []
    }
  },
  "botId": "282026114871729828"
}
```

---

## 🔴 Error Codes

| Code  | Tên             | Mô tả                                    |
| ----- | --------------- | ---------------------------------------- |
| `200` | ✅ Success      | Request thành công                       |
| `400` | ❌ Bad Request  | Thiếu tham số bắt buộc hoặc sai format   |
| `401` | 🔒 Unauthorized | Signature không hợp lệ hoặc thiếu header |
| `404` | 🔍 Not Found    | Endpoint không tồn tại                   |
| `500` | ⚠️ Server Error | Lỗi server hoặc Zalo API                 |

### Ví dụ Response Error

```json
{
  "success": false,
  "error": "Missing required params: threadId"
}
```

```json
{
  "success": false,
  "error": "Invalid signature"
}
```

---

## 📚 API Endpoints Reference

### Message & Reaction

| Endpoint              | Mô tả                        |
| --------------------- | ---------------------------- |
| `POST /sendmessage`   | Gửi tin nhắn (hỗ trợ styles) |
| `POST /addReaction`   | React tin nhắn               |
| `POST /deleteMessage` | Thu hồi tin nhắn             |
| `POST /sendSticker`   | Gửi sticker                  |
| `POST /sendCard`      | Gửi danh thiếp               |
| `POST /parseLink`     | Lấy preview link             |

### Friend Management

| Endpoint                    | Mô tả                |
| --------------------------- | -------------------- |
| `POST /findUser`            | Tìm user theo SĐT    |
| `POST /getUserInfo`         | Lấy thông tin user   |
| `POST /sendFriendRequest`   | Gửi lời mời kết bạn  |
| `POST /acceptFriendRequest` | Chấp nhận kết bạn    |
| `POST /getAllFriends`       | Lấy danh sách bạn bè |
| `POST /blockUser`           | Chặn user            |
| `POST /changeFriendAlias`   | Đặt biệt danh        |

### Group Management

| Endpoint                    | Mô tả              |
| --------------------------- | ------------------ |
| `POST /createGroup`         | Tạo nhóm mới       |
| `POST /getGroupInfo`        | Lấy thông tin nhóm |
| `POST /getAllGroups`        | Lấy tất cả nhóm    |
| `POST /addUserToGroup`      | Thêm thành viên    |
| `POST /removeUserFromGroup` | Xóa thành viên     |
| `POST /changeGroupName`     | Đổi tên nhóm       |
| `POST /addGroupDeputy`      | Thêm phó nhóm      |
| `POST /disperseGroup`       | Giải tán nhóm      |

### Poll & Note

| Endpoint              | Mô tả             |
| --------------------- | ----------------- |
| `POST /createPoll`    | Tạo bình chọn     |
| `POST /getPollDetail` | Lấy chi tiết poll |
| `POST /lockPoll`      | Khóa poll         |
| `POST /createNote`    | Tạo ghi chú       |
| `POST /editNote`      | Sửa ghi chú       |

### Stickers

| Endpoint                  | Mô tả                |
| ------------------------- | -------------------- |
| `POST /getStickers`       | Tìm sticker          |
| `POST /getStickersDetail` | Lấy chi tiết sticker |
| `POST /sendSticker`       | Gửi sticker          |

---

## 💡 Tips & Best Practices

> 🔒 **Bảo mật**: Không bao giờ lộ `api_secret` ra frontend!

> 🔄 **Retry**: Implement retry logic với exponential backoff khi gặp lỗi 500

> 📝 **Logging**: Log tất cả request/response để debug

> ⏱️ **Timeout**: Set timeout 30s cho các request

---

## 📞 Hỗ trợ

Nếu gặp vấn đề, vui lòng kiểm tra:

1. ✓ API Token và Secret có đúng không?
2. ✓ Signature được tính đúng cách?
3. ✓ Body JSON có đúng format?
4. ✓ Bot có đang online không?

---

_Tài liệu này được tạo tự động bởi MultiZLogin System_
