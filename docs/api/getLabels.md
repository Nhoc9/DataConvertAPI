# 🏷️ getLabels

> Lấy danh sách nhãn (label) liên hệ.

## Endpoint

```
POST /api/getLabels
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
  "data": [
    {
      "labelId": "1",
      "name": "Khách hàng",
      "color": "#ff0000"
    },
    {
      "labelId": "2",
      "name": "Đối tác",
      "color": "#00ff00"
    }
  ]
}
```

## Code Examples

### PHP

```php
$response = callApi('/getLabels', []);
foreach ($response['data'] as $label) {
    echo $label['name'] . "\n";
}
```

### Python

```python
result = call_api('/getLabels', {})
for label in result['data']:
    print(label['name'])
```

### Node.js

```javascript
const result = await callApi("/getLabels", {});
result.data.forEach((label) => console.log(label.name));
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getLabels' \
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
