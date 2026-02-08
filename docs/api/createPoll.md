# 📊 createPoll

> Tạo bình chọn trong nhóm.

## Endpoint

```
POST /api/createPoll
```

## Parameters

| Tham số             | Kiểu    | Bắt buộc | Mô tả                                     |
| ------------------- | ------- | -------- | ----------------------------------------- |
| `groupId`           | string  | ✅       | ID của nhóm                               |
| `question`          | string  | ✅       | Câu hỏi bình chọn                         |
| `options`           | array   | ✅       | Mảng các lựa chọn                         |
| `expiredTime`       | number  | ❌       | Thời gian hết hạn (ms, 0 = không hết hạn) |
| `pinAct`            | boolean | ❌       | Ghim bình chọn                            |
| `allowMultiChoices` | boolean | ❌       | Cho phép chọn nhiều đáp án                |
| `allowAddNewOption` | boolean | ❌       | Cho phép thêm lựa chọn mới                |
| `hideVotePreview`   | boolean | ❌       | Ẩn kết quả trước khi vote                 |
| `isAnonymous`       | boolean | ❌       | Bình chọn ẩn danh                         |

## Request Example

```json
{
  "groupId": "7890123456789012345",
  "question": "Bạn thích ngôn ngữ lập trình nào?",
  "options": ["Python", "JavaScript", "PHP", "Go"],
  "allowMultiChoices": true,
  "isAnonymous": false,
  "expiredTime": 0
}
```

## Response

```json
{
  "success": true,
  "data": {
    "pollId": "123456789",
    "question": "Bạn thích ngôn ngữ lập trình nào?",
    "options": [
      { "id": 0, "content": "Python" },
      { "id": 1, "content": "JavaScript" },
      { "id": 2, "content": "PHP" },
      { "id": 3, "content": "Go" }
    ]
  }
}
```

## Code Examples

### PHP

```php
$body = [
    'groupId' => '7890123456789012345',
    'question' => 'Thích ngôn ngữ nào?',
    'options' => ['Python', 'JavaScript', 'PHP'],
    'allowMultiChoices' => true
];
$response = callApi('/createPoll', $body);
```

### Python

```python
result = call_api('/createPoll', {
    'groupId': '7890123456789012345',
    'question': 'Thích ngôn ngữ nào?',
    'options': ['Python', 'JavaScript', 'PHP'],
    'allowMultiChoices': True
})
```

### Node.js

```javascript
const result = await callApi("/createPoll", {
  groupId: "7890123456789012345",
  question: "Thích ngôn ngữ nào?",
  options: ["Python", "JavaScript", "PHP"],
  allowMultiChoices: true,
});
```

### Postman

**cURL Import:**
```bash
curl -X POST 'http://localhost:3000/api/createPoll' \
  -H 'Content-Type: application/json' \
  -H 'X-Api-Token: {{api_token}}' \
  -H 'X-Signature: {{signature}}' \
  -d '{"groupId":"123","question":"Test?","options":["A","B"]}'
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
