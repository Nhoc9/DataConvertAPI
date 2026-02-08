# 📚 API Documentation - Mục lục

> Tài liệu chi tiết cho 42 API của hệ thống Zalo Multi-Bot

---

## 📖 Hướng dẫn chung

- [README - Giới thiệu & Authentication](./README.md)
- [POSTMAN - Hướng dẫn test API với Postman](./POSTMAN.md) ⭐

---

## 📨 Message & Reaction

| API                                 | Mô tả                           |
| ----------------------------------- | ------------------------------- |
| [sendMessage](./sendMessage.md)     | Gửi tin nhắn (hỗ trợ rich text) |
| [addReaction](./addReaction.md)     | React tin nhắn (50+ icons)      |
| [deleteMessage](./deleteMessage.md) | Thu hồi tin nhắn                |
| [sendSticker](./sendSticker.md)     | Gửi sticker                     |
| [sendCard](./sendCard.md)           | Gửi danh thiếp                  |
| [parseLink](./parseLink.md)         | Lấy preview link                |

---

## 👥 Friend Management

| API                                             | Mô tả                |
| ----------------------------------------------- | -------------------- |
| [findUser](./findUser.md)                       | Tìm user theo SĐT    |
| [getUserInfo](./getUserInfo.md)                 | Lấy thông tin user   |
| [sendFriendRequest](./sendFriendRequest.md)     | Gửi lời mời kết bạn  |
| [acceptFriendRequest](./acceptFriendRequest.md) | Chấp nhận kết bạn    |
| [getAllFriends](./getAllFriends.md)             | Lấy danh sách bạn bè |
| [blockUser](./blockUser.md)                     | Chặn user            |
| [blockViewFeed](./blockViewFeed.md)             | Chặn xem feed        |
| [changeFriendAlias](./changeFriendAlias.md)     | Đặt biệt danh        |

---

## 👪 Group Management

| API                                             | Mô tả                    |
| ----------------------------------------------- | ------------------------ |
| [createGroup](./createGroup.md)                 | Tạo nhóm mới             |
| [getGroupInfo](./getGroupInfo.md)               | Lấy thông tin nhóm       |
| [getAllGroups](./getAllGroups.md)               | Lấy tất cả nhóm          |
| [getGroupMembersInfo](./getGroupMembersInfo.md) | Lấy thông tin thành viên |
| [addUserToGroup](./addUserToGroup.md)           | Thêm thành viên          |
| [removeUserFromGroup](./removeUserFromGroup.md) | Xóa thành viên           |
| [changeGroupName](./changeGroupName.md)         | Đổi tên nhóm             |
| [changeGroupAvatar](./changeGroupAvatar.md)     | Đổi avatar nhóm          |
| [changeGroupOwner](./changeGroupOwner.md)       | Chuyển quyền sở hữu      |
| [addGroupDeputy](./addGroupDeputy.md)           | Thêm phó nhóm            |
| [removeGroupDeputy](./removeGroupDeputy.md)     | Xóa phó nhóm             |
| [disperseGroup](./disperseGroup.md)             | Giải tán nhóm            |
| [pinConversations](./pinConversations.md)       | Ghim hội thoại           |

---

## 📊 Poll & Note

| API                                 | Mô tả             |
| ----------------------------------- | ----------------- |
| [createPoll](./createPoll.md)       | Tạo bình chọn     |
| [getPollDetail](./getPollDetail.md) | Lấy chi tiết poll |
| [lockPoll](./lockPoll.md)           | Khóa poll         |
| [createNote](./createNote.md)       | Tạo ghi chú       |
| [editNote](./editNote.md)           | Sửa ghi chú       |

---

## 🖼️ Media

| API                                         | Mô tả                   |
| ------------------------------------------- | ----------------------- |
| [sendImageToUser](./sendImageToUser.md)     | Gửi ảnh đến user        |
| [sendImagesToUser](./sendImagesToUser.md)   | Gửi nhiều ảnh đến user  |
| [sendImageToGroup](./sendImageToGroup.md)   | Gửi ảnh đến group       |
| [sendImagesToGroup](./sendImagesToGroup.md) | Gửi nhiều ảnh đến group |

---

## 🎨 Stickers

| API                                         | Mô tả                    |
| ------------------------------------------- | ------------------------ |
| [getStickers](./getStickers.md)             | Tìm sticker theo keyword |
| [getStickersDetail](./getStickersDetail.md) | Lấy chi tiết sticker     |

---

## 👤 Account

| API                                             | Mô tả              |
| ----------------------------------------------- | ------------------ |
| [fetchAccountInfo](./fetchAccountInfo.md)       | Lấy thông tin bot  |
| [changeAccountAvatar](./changeAccountAvatar.md) | Đổi avatar bot     |
| [getLabels](./getLabels.md)                     | Lấy danh sách nhãn |
| [sendReport](./sendReport.md)                   | Báo cáo user       |

---

## 📊 Thống kê

- **Tổng số API**: 42
- **Message & Reaction**: 6
- **Friend Management**: 8
- **Group Management**: 13
- **Poll & Note**: 5
- **Media**: 4
- **Stickers**: 2
- **Account**: 4
