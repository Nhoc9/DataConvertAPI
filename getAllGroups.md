# 📋 getAllGroups

> Lấy danh sách tất cả các nhóm mà bot là thành viên.

## Endpoint

```
POST /api/getAllGroups
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
    "version": 1707456789,
    "gridInfoMap": {
      "7890123456789012345": {
        "groupId": "7890123456789012345",
        "name": "Nhóm A",
        "memberIds": ["1234567890"],
        "type": 0
      },
      "9876543210987654321": {
        "groupId": "9876543210987654321",
        "name": "Nhóm B",
        "memberIds": ["0987654321"],
        "type": 0
      }
    }
  }
}
```

## Code Examples

### PHP

```php
$response = callApi('/getAllGroups', []);

foreach ($response['data']['gridInfoMap'] as $groupId => $group) {
    echo $group['name'] . "\n";
}
```

### Python

```python
result = call_api('/getAllGroups', {})
for group_id, group in result['data']['gridInfoMap'].items():
    print(group['name'])
```

### Node.js

```javascript
const result = await callApi("/getAllGroups", {});
Object.values(result.data.gridInfoMap).forEach((group) => {
  console.log(group.name);
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/getAllGroups' \
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
