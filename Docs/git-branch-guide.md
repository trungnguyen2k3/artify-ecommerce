# Quy Chuẩn Đặt Tên Branch Git / GitHub

Tài liệu này hướng dẫn cách đặt tên nhánh (Branch) trên Git/GitHub theo chuẩn công nghiệp (Industry Best Practices). Đặt tên branch chuẩn giúp tăng hiệu suất làm việc nhóm, dễ dàng quản lý lịch sử code và tương thích tốt với các hệ thống CI/CD tự động.

---

## 1. Công Thức Đặt Tên Branch Chuẩn

Một tên branch chuẩn thường được xây dựng theo công thức sau:

$$\text{<category>} / \text{<ticket-id>}-\text{<short-description>}$$

Hoặc (nếu dự án không sử dụng Jira/Trello/Redmine để quản lý Task ID):

$$\text{<category>} / \text{<short-description>}$$

* **`<category>`**: Phân loại loại công việc bạn đang thực hiện trên branch này (Xem chi tiết ở mục 2).
* **`<ticket-id>`**: ID của task trên công cụ quản lý dự án (ví dụ: `ART-102`, `BUG-45`).
* **`<short-description>`**: Mô tả ngắn gọn bằng tiếng Anh, các từ cách nhau bởi dấu gạch ngang `-`.

---

## 2. Các Phân Loại Branch (Categories) Phổ Biến

Để đồng bộ với tài liệu [git-commit-guide.txt](file:///d:/project/BE/git-commit-guide.txt) hiện tại của dự án, các phân loại branch được quy định như sau:

| Phân loại (Category) | Ý nghĩa | Ví dụ thực tế |
| :--- | :--- | :--- |
| **`feature/`** (hoặc **`feat/`**) | Phát triển một tính năng mới. | `feature/auth-login-cookie`<br>`feature/ART-101-cart-page` |
| **`bugfix/`** (hoặc **`fix/`**) | Sửa một lỗi (bug) phát sinh trong quá trình dev/test. | `bugfix/fix-null-pointer-blog`<br>`bugfix/BUG-99-cors-error` |
| **`hotfix/`** | Sửa một lỗi cực kỳ khẩn cấp trên môi trường **Production**. Nhánh này thường được tạo ra trực tiếp từ `main`/`master` và merge ngược lại ngay lập tức. | `hotfix/critical-jwt-secret-leak`<br>`hotfix/payment-gateway-timeout` |
| **`refactor/`** | Tái cấu trúc, tối ưu code cũ nhưng không thay đổi logic hay thêm tính năng. | `refactor/clean-auth-service` |
| **`docs/`** | Cập nhật, viết thêm tài liệu hướng dẫn (README, API docs,...). | `docs/update-setup-guide` |
| **`chore/`** | Cập nhật các tác vụ cấu hình hệ thống, thư viện (dependencies), file `.gitignore`, setup Docker,... | `chore/update-nuget-packages` |
| **`test/`** | Thêm mới hoặc chỉnh sửa các bộ Unit Test, Integration Test. | `test/auth-service-unit-test` |

---

## 3. Quy Tắc Vàng Khi Đặt Tên Branch (Golden Rules)

> [!IMPORTANT]
> Tuân thủ các quy tắc này là bắt buộc trong mọi dự án chuyên nghiệp và là điểm cộng lớn khi đi phỏng vấn.

1. **Chỉ dùng chữ thường (Lowercase)**: Tuyệt đối không viết hoa.
   * *Sai*: `feature/Add-Google-Login`
   * *Đúng*: `feature/add-google-login`
2. **Sử dụng dấu gạch ngang (`-`) làm dấu phân tách**: Không dùng dấu cách, không dùng dấu gạch dưới (`_`).
   * *Sai*: `feature/add_google_login` hoặc `feature/add google login`
   * *Đúng*: `feature/add-google-login`
3. **Mô tả ngắn gọn, bắt đầu bằng động từ**: Hãy dùng các động từ hành động ngắn gọn (add, fix, remove, update, clean,...).
   * *Sai*: `feature/login` (quá chung chung)
   * *Đúng*: `feature/implement-jwt-cookie-login`
4. **Tránh đặt tên cá nhân vào branch**: Trừ các nhánh nháp cá nhân không đẩy lên GitHub, không nên đặt tên branch theo kiểu `nguyen/fix-bug` hoặc `trung/feature-auth`.

---

## 4. Mối Liên Hệ Giữa Branch Name Và Commit Message

Tên branch bạn đang làm việc nên có sự liên kết chặt chẽ với các Commit Message bạn tạo ra. Việc này giúp việc Review Pull Request trở nên cực kỳ dễ dàng.

* **Tên Branch**: `feature/auth-jwt-login`
* **Các Commit Messages tương ứng**:
  * `feat(auth): create login request and response dtos`
  * `feat(auth): implement token generator helper`
  * `feat(auth): write login controller with httponly cookie`

---

## 5. Các Lệnh Git Thường Dùng Khi Thao Tác Với Branch

Khi bạn bắt đầu làm việc trên một tính năng mới:

### Bước 1: Trở về nhánh chính (`main` hoặc `develop`) và cập nhật code mới nhất
```bash
git checkout main
git pull origin main
```

### Bước 2: Tạo và di chuyển sang nhánh mới
```bash
git checkout -b feature/auth-jwt-login
```

### Bước 3: Sau khi code xong và commit, đẩy nhánh mới lên GitHub lần đầu tiên
```bash
git push -u origin feature/auth-jwt-login
```
*(Cờ `-u` hoặc `--set-upstream` giúp liên kết nhánh ở máy cá nhân với nhánh trên GitHub, lần sau bạn chỉ cần gõ `git push` là đủ).*

### Bước 4: Xóa nhánh ở Local sau khi đã merge vào main thành công
```bash
git checkout main
git branch -d feature/auth-jwt-login
```
