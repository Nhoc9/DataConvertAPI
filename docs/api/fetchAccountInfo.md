# 👤 fetchAccountInfo

> Lấy thông tin tài khoản của bot.

## Endpoint

```
POST /api/fetchAccountInfo
```

## Parameters

Không cần tham số.

## Request Example

```json
{}
```

## Response

```json
{
  "success": true,
  "data": {
    "userId": "282026114871729828",
    "displayName": "Bot Zalo",
    "zaloName": "Bot Zalo",
    "avatar": "https://...",
    "cover": "https://...",
    "gender": 0,
    "dob": 0,
    "status": "Hello Zalo!"
  }
}
```

## Code Examples

### PHP

```php
$response = callApi('/fetchAccountInfo', []);
echo $response['data']['displayName'];
```

### Python

```python
result = call_api('/fetchAccountInfo', {})
print(result['data']['displayName'])
```

### Node.js

```javascript
const result = await callApi("/fetchAccountInfo", {});
console.log(result.data.displayName);
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/fetchAccountInfo' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{}'
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
