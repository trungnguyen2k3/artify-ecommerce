# CẨM NANG TOÀN TẬP: LẬP TRÌNH C# & TRUY VẤN DỮ LIỆU CỐT LÕI

> Tài liệu này tổng hợp toàn bộ kiến thức lập trình C# hiện đại, cơ chế bất đồng bộ (Async/Await) và công cụ truy vấn dữ liệu LINQ dùng trong dự án ASP.NET Core.

---

## 📅 MỤC LỤC
1. [Chủ đề 1: Cú pháp & Cấu trúc dữ liệu C# hay gặp](#chủ-đề-1-cú-pháp--cấu-trúc-dữ-liệu-c-hay-gặp)
2. [Chủ đề 2: Lập trình bất đồng bộ (Async / Await)](#chủ-đề-2-lập-trình-bất-đồng-bộ-async--await)
3. [Chủ đề 3: Làm chủ LINQ trong C# & EF Core](#chủ-đề-3-làm-chủ-linq-trong-c--ef-core)

---

## CHỦ ĐỀ 1: CÚ PHÁP & CẤU TRÚC DỮ LIỆU C# HAY GẶP

### 1. Từ khóa `var` (Khai báo biến suy luận tự động)
Thay vì viết kiểu dữ liệu dài dòng ở cả 2 vế, từ khóa `var` giúp C# tự động nhận diện kiểu dữ liệu của biến dựa vào giá trị gán cho nó ở vế bên phải.
*   *Lưu ý:* `var` không phải là kiểu dữ liệu động (như `let` trong JS). Một khi biến `var` đã được gán kiểu, bạn không thể gán giá trị kiểu khác cho nó.
```csharp
var name = "Artify";  // Tự động hiểu là string
var score = 99;       // Tự động hiểu là int
```

### 2. Lớp ẩn danh (Anonymous Object - `new { ... }`)
Khi bạn cần đóng gói nhanh một vài thông tin để trả về dạng JSON mà không muốn tốn công tạo một class DTO mới, hãy sử dụng đối tượng nặc danh:
```csharp
var responseData = new
{
    Id = 1,
    Title = "Bài viết mới",
    CreatedAt = DateTime.Now
};
```

### 3. Bộ dữ liệu tạm thời Tuple
Khi một phương thức cần trả về **nhiều hơn 1 giá trị**, ta bọc các giá trị đó bằng dấu ngoặc đơn `( )` mà không cần dựng Class phụ.
*   **Khai báo và trả về Tuple (ở Service):**
    ```csharp
    public async Task<(List<ProductDto> Items, int TotalCount)> GetProductsAsync()
    {
        var list = new List<ProductDto>();
        int total = 42;
        return (list, total);
    }
    ```
*   **Hứng dữ liệu từ Tuple (ở Controller):**
    ```csharp
    var (products, count) = await GetProductsAsync();
    Console.WriteLine(products.Count);
    Console.WriteLine(count);
    ```

### 4. Danh sách động `List<T>`
`List<T>` lưu trữ danh sách các phần tử có **cùng kiểu dữ liệu `T`**, có thể co giãn kích thước động.
*   `Add(item)`: Thêm một phần tử vào cuối danh sách.
*   `AddRange(collection)`: Thêm cả một tập hợp phần tử.
*   `Remove(item)`: Xóa phần tử cụ thể.
*   `Count`: Lấy ra tổng số lượng phần tử hiện tại.

### 5. Từ điển tra cứu nhanh `Dictionary<TKey, TValue>`
`Dictionary` lưu trữ dữ liệu dưới dạng cặp **Key - Value**. Dùng để tra cứu nhanh thông tin thông qua một Key duy nhất.
```csharp
var stock = new Dictionary<string, int>();
stock.Add("IPHONE15", 50);

// Tra cứu nhanh bằng Key
int iphoneStock = stock["IPHONE15"]; // Kết quả: 50

// Lấy dữ liệu an toàn
if (stock.TryGetValue("IPHONE15", out int quantity)) {
    Console.WriteLine($"Số lượng: {quantity}");
}
```

---

## CHỦ ĐỀ 2: LẬP TRÌNH BẤT ĐỒNG BỘ (ASYNC / AWAIT)

Lập trình bất đồng bộ (Asynchronous) giúp hệ thống không bị nghẽn luồng xử lý khi thực hiện các tác vụ tốn thời gian (đọc DB, gọi API ngoài, đọc file).

### 1. Ẩn dụ "Thẻ rung trà sữa"
*   **Đồng bộ (Sync):** Bạn gọi món xong và phải **đứng im xếp hàng tại quầy**, không được đi đâu cho đến khi nhận nước. Lúc này, luồng xử lý (Thread) bị khóa cứng (blocked) không làm được việc khác.
*   **Bất đồng bộ (Async):** Bạn gọi món xong, nhân viên đưa bạn cái **Thẻ rung (`Task`)**. Bạn thoải mái lướt điện thoại, tìm bàn ngồi (Thread được giải phóng). Khi nước xong, thẻ rung lên (`await`), bạn ra nhận nước.

### 2. Ý nghĩa của các kiểu khai báo `Task`
*   `Task`: Công việc chạy ngầm **không trả về dữ liệu** gì cả.
*   `Task<T>`: Công việc chạy ngầm và **hứa hẹn trả về kết quả kiểu `T`** khi hoàn thành.

### 3. Quy tắc vàng khi dùng `async` và `await`
*   **`async`**: Đặt trước kiểu trả về của hàm để báo hiệu hàm chứa xử lý bất đồng bộ.
*   **`await`**: Đặt trước một Task để ra lệnh chờ đợi Task đó hoàn thành rồi mới chạy tiếp dòng code bên dưới.
*   **Tránh dùng `.Result` hoặc `.Wait()`** vì chúng sẽ khóa cứng Thread hiện tại, dễ gây ra lỗi treo ứng dụng (Deadlock).
*   **Tránh dùng `async void`** (ngoại trừ Event Handler) vì khi xảy ra Exception sẽ làm crash sập toàn bộ ứng dụng mà không bắt lỗi được.

---

## CHỦ ĐỀ 3: LÀM CHỦ LINQ TRONG C# & EF CORE (CHI TIẾT & TRỰC QUAN)

**LINQ (Language Integrated Query)** thực chất là một cách viết giúp bạn "hỏi" dữ liệu thay vì phải tự tay viết thuật toán để đi tìm dữ liệu đó.

---

### 1. Lambda Expression (`x => x.Property`) Là Gì?
Khi viết LINQ, bạn sẽ luôn bắt gặp ký tự `=>` (gọi là Lambda). Đây là cách viết tắt của một **hàm nặc danh (anonymous function)**.

*   Hãy đọc biểu thức: `blogProduct => blogProduct.IsActive` là:
    *   **Vế trái (`blogProduct`)**: Đầu vào — Đại diện cho **một phần tử đơn lẻ** trong danh sách khi duyệt qua. Bạn có thể đặt tên là bất kỳ chữ gì (ví dụ: `x`, `p`, `item`).
    *   **Ký tự `=>`**: Đọc là "sao cho" hoặc "trỏ đến".
    *   **Vế phải (`blogProduct.IsActive`)**: Kết quả kiểm tra hoặc giá trị đầu ra của phần tử đó.

```csharp
// Viết tường minh (hàm bình thường):
bool CheckActive(BlogProduct p)
{
    return p.IsActive;
}

// Viết tắt bằng Lambda:
p => p.IsActive
```

---

### 2. So Sánh Trước & Sau (Tại sao LINQ lại mạnh mẽ?)
Giả sử bạn có danh sách sản phẩm và yêu cầu: *"Lọc ra các sản phẩm Active, sắp xếp theo giá từ cao xuống thấp và lấy ra Tên của chúng"*.

#### 🔴 Cách truyền thống (Không dùng LINQ):
Bạn phải viết vòng lặp `foreach`, so sánh `if`, tạo danh sách phụ để chứa, rồi viết thuật toán sắp xếp rất phức tạp.
```csharp
// 1. Tạo danh sách phụ chứa kết quả lọc
List<BlogProduct> filteredList = new List<BlogProduct>();
foreach (var p in products)
{
    if (p.IsActive == true) {
        filteredList.Add(p);
    }
}

// 2. Viết thuật toán sắp xếp giảm dần (ví dụ Bubble Sort)
for (int i = 0; i < filteredList.Count - 1; i++) {
    for (int j = i + 1; j < filteredList.Count; j++) {
        if (filteredList[i].Price < filteredList[j].Price) {
            var temp = filteredList[i];
            filteredList[i] = filteredList[j];
            filteredList[j] = temp;
        }
    }
}

// 3. Tạo danh sách chứa Tên sản phẩm
List<string> names = new List<string>();
foreach (var p in filteredList) {
    names.Add(p.Name);
}
```

####  Cách dùng LINQ (Method Syntax):
Bạn chỉ cần kết nối các phương thức lại với nhau như một chuỗi dây chuyền:
```csharp
var names = products
    .Where(p => p.IsActive)                 // 1. Lọc sản phẩm Active
    .OrderByDescending(p => p.Price)        // 2. Sắp xếp theo giá giảm dần
    .Select(p => p.Name)                     // 3. Chỉ lấy cột Tên
    .ToList();                              // 4. Đóng gói thành List<string>
```

---

### 3. Mổ Xẻ Chi Tiết Các Hàm LINQ Hay Dùng

#### 🔹 Hàm `Where(condition)` — Bộ lọc
*   **Cách hiểu:** Đi qua từng phần tử, chỉ giữ lại phần tử nào làm cho `condition` trả về `true`.
*   **Ví dụ:** `products.Where(p => p.Price > 100)` (Lấy các sản phẩm có giá trên 100).

#### 🔹 Hàm `Select(mapping)` — Máy biến đổi
*   **Cách hiểu:** Biến đổi phần tử cũ thành một hình dạng mới (chọn cột, mapping sang DTO, tính toán trường mới).
*   **Ví dụ (Chỉ lấy cột Id):** `products.Select(p => p.Id)` -> Kết quả trả về là một danh sách số nguyên `List<int>`.
*   **Ví dụ (Map sang DTO):**
    ```csharp
    products.Select(p => new BlogProductDto {
        Id = p.Id,
        Name = p.Name
    })
    ```

#### 🔹 Hàm `FirstOrDefault(condition)` — Tìm phần tử đầu tiên
*   **Cách hiểu:** Duyệt qua danh sách, thấy phần tử nào khớp điều kiện đầu tiên là lấy ngay và dừng lại. Nếu duyệt hết danh sách không thấy ai, trả về `null`.
*   **Ví dụ:** `products.FirstOrDefault(p => p.Sku == "SKU01")` (Tìm sản phẩm theo mã Sku).

#### 🔹 Hàm `Any(condition)` — Kiểm tra sự tồn tại
*   **Cách hiểu:** Chỉ cần tìm thấy **ít nhất 1** phần tử khớp điều kiện là trả về `true` và dừng ngay lập tức (không cần chạy hết bảng). Rất nhanh và tối ưu.
*   **Ví dụ:** `products.Any(p => p.Sku == "SKU01")` -> Trả về `true`/`false`.

#### 🔹 Cặp bài trùng Phân Trang: `Skip(n).Take(m)`
*   **`Skip(n)`**: Đi từ đầu danh sách, đếm qua `n` phần tử và vứt đi, bắt đầu lấy từ phần tử thứ `n + 1`.
*   **`Take(m)`**: Lấy đúng `m` phần tử kế tiếp rồi dừng lại.
*   **Công thức phân trang:**
    ```csharp
    int skipCount = (pageNumber - 1) * pageSize;
    var result = products.Skip(skipCount).Take(pageSize).ToList();
    ```

---

### 4. Cơ Chế EF Core Dịch LINQ Thành SQL (IQueryable vs IEnumerable)

Khi bạn viết LINQ với `_context.BlogProducts` (tức là làm việc với **`IQueryable`**):
*   Entity Framework Core **chưa hề** gọi xuống Database. Nó chỉ lưu lại câu hỏi của bạn dưới dạng phác thảo.
*   Chỉ khi bạn gọi hàm kết thúc có chữ **`Async`** (như `ToListAsync()`, `CountAsync()`), EF Core mới dịch toàn bộ chuỗi LINQ đó thành 1 câu lệnh SQL Server hoàn chỉnh và gửi đi.

#### Hãy xem cách dịch:
```csharp
// Code C# LINQ của bạn:
var items = await _context.BlogProducts
    .AsNoTracking()
    .OrderBy(p => p.Id)
    .Skip(10)
    .Take(5)
    .ToListAsync();
```

```sql
-- SQL Server nhận được và thực thi:
SELECT [Id], [Name], [Description], [Photo], [CategoryId], [IsActive], [Sku]
FROM [BlogProducts]
ORDER BY [Id]
OFFSET 10 ROWS
FETCH NEXT 5 ROWS ONLY;
```

#### 🛑 Sai lầm kinh điển làm sập hiệu năng (Gọi `.ToList()` quá sớm):
```csharp
// 🛑 SAI: Gọi ToList() ở đây bắt đầu tải toàn bộ bảng (ví dụ 1 triệu dòng) về RAM của Web Server.
var query = _context.BlogProducts.ToList(); 

// Dòng này lọc trên RAM của Web Server chứ không phải SQL Server nữa -> Chậm khủng khiếp!
var result = query.Skip(10).Take(5).ToList();
```
*   **Quy tắc:** Hãy luôn thực hiện các lệnh `Where`, `OrderBy`, `Skip`, `Take`, `Select` trước, rồi mới gọi `ToListAsync()` ở cuối cùng.

---

### 5. Cách Tự Học LINQ Hiệu Quả:
Mỗi khi viết một câu lệnh LINQ, bạn hãy nhẩm trong đầu theo luồng logic sau:
1.  *"Dữ liệu đầu vào của tôi là bảng/danh sách nào?"* (`_context.BlogProducts`)
2.  *"Tôi muốn lọc những dòng nào?"* (Dùng `.Where(p => ... )`)
3.  *"Tôi muốn sắp xếp như thế nào?"* (Dùng `.OrderBy(p => ... )`)
4.  *"Tôi muốn bỏ qua bao nhiêu cái và lấy bao nhiêu cái?"* (Dùng `.Skip().Take()`)
5.  *"Tôi muốn lấy những cột thông tin nào?"* (Dùng `.Select(p => new Dto { ... })`)
6.  *"Tôi muốn lấy ra danh sách hay chỉ 1 cái?"* (Dùng `.ToListAsync()` hoặc `.FirstOrDefaultAsync()`)
