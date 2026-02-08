# 🔗 parseLink

> Lấy thông tin preview của một URL (thumbnail, title, description).

## Endpoint

```
POST /api/parseLink
```

## Parameters

| Tham số | Kiểu   | Bắt buộc | Mô tả         |
| ------- | ------ | -------- | ------------- |
| `link`  | string | ✅       | URL cần parse |

## Request Example

```json
{
  "link": "https://www.youtube.com/watch?v=dQw4w9WgXcQ"
}
```

## Response

```json
{
  "success": true,
  "data": {
    "thumb": "https://i.ytimg.com/vi/dQw4w9WgXcQ/hqdefault.jpg",
    "title": "Rick Astley - Never Gonna Give You Up",
    "desc": "The official video for "Never Gonna Give You Up"...",
    "src": "YouTube",
    "href": "https://www.youtube.com/watch?v=dQw4w9WgXcQ",
    "media": {
      "type": 1,
      "count": 0,
      "mediaTitle": "",
      "artist": "",
      "streamUrl": "",
      "stream_icon": ""
    }
  }
}
```

## Code Examples

### PHP

```php
$body = ['link' => 'https://google.com'];
$response = callApi('/parseLink', $body);
echo $response['data']['title'];
```

### Python

```python
result = call_api('/parseLink', {
    'link': 'https://google.com'
})
print(result['data']['title'])
```

### Node.js

```javascript
const result = await callApi("/parseLink", {
  link: "https://google.com",
});
console.log(result.data.title);
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/parseLink' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"link":"https://google.com"}'
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
