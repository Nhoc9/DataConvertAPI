# 👥 getAllFriends

> Lấy danh sách bạn bè của bot (có phân trang).

## Endpoint

```
POST /api/getAllFriends
```

## Parameters

| Tham số | Kiểu   | Bắt buộc | Mô tả                              |
| ------- | ------ | -------- | ---------------------------------- |
| `count` | number | ❌       | Số lượng mỗi trang (mặc định: 500) |
| `page`  | number | ❌       | Số trang (mặc định: 1)             |

## Request Example

```json
{
  "count": 100,
  "page": 1
}
```

## Response

```json
{
  "success": true,
  "data": [
    {
      "userId": "1234567890",
      "displayName": "Nguyễn Văn A",
      "zaloName": "A Nguyen",
      "avatar": "https://...",
      "phoneNumber": "0912345678",
      "gender": 0,
      "isFr": 1,
      "isBlocked": 0
    },
    {
      "userId": "0987654321",
      "displayName": "Trần Thị B",
      "zaloName": "B Tran",
      "avatar": "https://...",
      "phoneNumber": "0987654321",
      "gender": 1,
      "isFr": 1,
      "isBlocked": 0
    }
  ]
}
```

## Code Examples

### PHP

```php
// Lấy 100 bạn bè đầu tiên
$body = ['count' => 100, 'page' => 1];
$response = callApi('/getAllFriends', $body);

foreach ($response['data'] as $friend) {
    echo $friend['displayName'] . "\n";
}
```

### Python

```python
result = call_api('/getAllFriends', {'count': 100, 'page': 1})
for friend in result['data']:
    print(friend['displayName'])
```

### Node.js

```javascript
const result = await callApi("/getAllFriends", { count: 100, page: 1 });
result.data.forEach((friend) => console.log(friend.displayName));
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getAllFriends' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"count":100,"page":1}'
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
