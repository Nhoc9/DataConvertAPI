# 📮 Hướng dẫn sử dụng Postman

> Hướng dẫn chi tiết cách sử dụng Postman để test API Zalo Multi-Bot

---

## 🔧 Cài đặt Environment

### Bước 1: Tạo Environment mới

1. Click **Environments** → **+** (Create new)
2. Đặt tên: `Zalo Multi-Bot`
3. Thêm 3 biến:

| Variable     | Initial Value               | Current Value               |
| ------------ | --------------------------- | --------------------------- |
| `base_url`   | `http://localhost:3000/api` | `http://localhost:3000/api` |
| `api_token`  | `YOUR_API_TOKEN`            | `YOUR_API_TOKEN`            |
| `api_secret` | `YOUR_API_SECRET`           | `YOUR_API_SECRET`           |

4. Click **Save**

---

## 🔐 Pre-request Script (QUAN TRỌNG!)

### Thêm vào Collection hoặc từng Request

Copy script này vào tab **Pre-request Script**:

```javascript
// ========================================
// Zalo Multi-Bot API - HMAC Authentication
// ========================================

// Lấy API secret từ environment
const apiSecret = pm.environment.get("api_secret");
const apiToken = pm.environment.get("api_token");

if (!apiSecret || !apiToken) {
  console.error(
    "❌ Chưa cấu hình api_token hoặc api_secret trong Environment!",
  );
  throw new Error("Missing api_token or api_secret in Environment");
}

// Lấy raw body từ request
const rawBody = pm.request.body.raw || "{}";

// Tính HMAC-SHA256 signature
const signature =
  "sha256=" + CryptoJS.HmacSHA256(rawBody, apiSecret).toString();

// Set headers tự động
pm.request.headers.add({
  key: "Content-Type",
  value: "application/json",
});

pm.request.headers.add({
  key: "X-Api-Token",
  value: apiToken,
});

pm.request.headers.add({
  key: "X-Signature",
  value: signature,
});

// Log để debug
console.log("✅ API Token:", apiToken.substring(0, 10) + "...");
console.log("✅ Signature:", signature.substring(0, 30) + "...");
console.log("✅ Body:", rawBody.substring(0, 100));
```

---

## 📥 Import cURL

### Cách import:

1. Click **Import** (góc trên trái)
2. Chọn tab **Raw text**
3. Paste cURL code
4. Click **Continue** → **Import**

---

## 📋 cURL Examples cho từng API

### sendMessage

```bash
curl -X POST '{{base_url}}/sendmessage' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "message": "Xin chào từ Postman!",
    "threadId": "1234567890",
    "type": 0
  }'
```

### addReaction

```bash
curl -X POST '{{base_url}}/addReaction' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "icon": "heart",
    "message": {"msgId": "123", "cliMsgId": "456"},
    "threadId": "1234567890"
  }'
```

### getAllFriends

```bash
curl -X POST '{{base_url}}/getAllFriends' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "count": 100,
    "page": 1
  }'
```

### createGroup

```bash
curl -X POST '{{base_url}}/createGroup' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "name": "Nhóm Test",
    "members": ["1234567890", "0987654321"]
  }'
```

### sendSticker

```bash
curl -X POST '{{base_url}}/sendSticker' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "stickerId": 123456,
    "threadId": "1234567890",
    "type": 0
  }'
```

### createPoll

```bash
curl -X POST '{{base_url}}/createPoll' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "groupId": "7890123456789012345",
    "question": "Bạn thích ngôn ngữ nào?",
    "options": ["Python", "JavaScript", "PHP"],
    "allowMultiChoices": true
  }'
```

---

## 🎯 Workflow Test nhanh

### 1. Test kết nối cơ bản

```bash
curl -X POST '{{base_url}}/fetchAccountInfo' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{}'
```

### 2. Test gửi tin nhắn

```bash
curl -X POST '{{base_url}}/sendmessage' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{
    "message": "Test từ Postman ✅",
    "threadId": "YOUR_THREAD_ID",
    "type": 0
  }'
```

---

## ⚠️ Troubleshooting

### Lỗi "Invalid signature"

1. Kiểm tra `api_secret` trong Environment
2. Đảm bảo Pre-request Script đã chạy (xem Console)
3. Body JSON phải đúng format (không có trailing comma)

### Lỗi "Account not found"

1. Kiểm tra `api_token` đúng chưa
2. Bot có đang online không
3. Server đã start chưa

### Lỗi "Missing ownId"

- Không cần lo! ownId được lấy tự động từ api_token
- Chỉ cần đảm bảo Pre-request Script đã set header đúng

---

## 💡 Tips

> 🔥 **Pro tip**: Thêm Pre-request Script vào **Collection level** để không phải copy vào từng request!

> 📝 **Debug**: Mở **Console** (View → Show Console) để xem log từ Pre-request Script

> 🔄 **Variables**: Dùng `{{variable}}` trong URL và Body để dễ thay đổi
