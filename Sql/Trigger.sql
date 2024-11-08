-- 17 trigger

--Trigger Name: trg_UpdateKhachHang
--Definition:
CREATE TRIGGER trg_UpdateKhachHang

ON KHACH_HANG

AFTER UPDATE

AS

BEGIN

    SET NOCOUNT ON;

    -- Kiểm tra nếu có thay đổi trong SDT hoặc Email

    IF UPDATE(SDT) OR UPDATE(Email)

    BEGIN

        DECLARE @MaKH INT;

        DECLARE @NewSDT NVARCHAR(15);

        DECLARE @NewEmail NVARCHAR(100);

        -- Lấy mã khách hàng và giá trị mới từ bảng INSERTED

        SELECT @MaKH = maKH, @NewSDT = SDT, @NewEmail = Email

        FROM INSERTED;

        -- Kiểm tra nếu SDT hoặc Email mới đã tồn tại trong bảng

        IF EXISTS (SELECT 1 FROM KHACH_HANG WHERE (SDT = @NewSDT OR Email = @NewEmail) AND maKH <> @MaKH)

        BEGIN

            -- Nếu có trùng lặp, rollback và không thực hiện cập nhật

            RAISERROR('Số điện thoại hoặc email đã tồn tại. Cập nhật không thành công.', 16, 1);

            ROLLBACK TRANSACTION;

            RETURN;

        END

    END

END;

--================================================================================

--Trigger Name: trg_CheckOverlap
--Definition:
CREATE TRIGGER trg_CheckOverlap

ON CA_LAM_VIEC

INSTEAD OF INSERT

AS

BEGIN

    DECLARE @MaNV INT,

            @ThoiGianBatDau DATETIME,

            @ThoiGianKetThuc DATETIME;

    SELECT @MaNV = MaNV, 

           @ThoiGianBatDau = ThoiGianBatDau, 

           @ThoiGianKetThuc = ThoiGianKetThuc 

    FROM inserted;

    -- Kiểm tra xem có ca làm việc trùng lặp hay không

    IF EXISTS (

        SELECT 1 

        FROM CA_LAM_VIEC

        WHERE MaNV = @MaNV 

        AND (@ThoiGianBatDau < ThoiGianKetThuc AND @ThoiGianKetThuc > ThoiGianBatDau)

    )

    BEGIN

        -- Nếu trùng lặp, thông báo và rollback

        RAISERROR('Thời gian làm việc bị trùng với ca làm việc của nhân viên khác.', 16, 1);

        ROLLBACK;

    END

    ELSE

    BEGIN

        -- Nếu không trùng lặp, thực hiện insert

        INSERT INTO CA_LAM_VIEC (MaNV, ThoiGianBatDau, ThoiGianKetThuc)

        SELECT MaNV, ThoiGianBatDau, ThoiGianKetThuc FROM inserted;

    END

END;

--================================================================================

--Trigger Name: trg_DeleteDonHang
--Definition:
--================================================================================

--Trigger Name: trg_DeleteDonHang

--Definition:

CREATE TRIGGER trg_DeleteDonHang

ON dbo.DON_HANG

INSTEAD OF DELETE

AS

BEGIN

    SET NOCOUNT ON; -- Giúp tránh thông báo số dòng bị ảnh hưởng

    DECLARE @MaDH INT;

    DECLARE @TrangThaiDonHang NVARCHAR(50);

    DECLARE @MaSP INT;

    DECLARE @SoLuong INT;

    -- Lấy mã đơn hàng bị xóa

    SELECT @MaDH = deleted.MaDH FROM deleted;

    -- Lấy trạng thái đơn hàng

    SELECT @TrangThaiDonHang = TrangThaiDonHang FROM DON_HANG WHERE MaDH = @MaDH;

    -- Kiểm tra trạng thái đơn hàng

    IF @TrangThaiDonHang <> N'Đã giao'

    BEGIN

        -- Nếu trạng thái không phải là "Đã giao", trả lại số lượng sản phẩm

        DECLARE ProductCursor CURSOR FOR

        SELECT MaSP, SoLuong FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH;

        OPEN ProductCursor;

        FETCH NEXT FROM ProductCursor INTO @MaSP, @SoLuong;

        WHILE @@FETCH_STATUS = 0

        BEGIN

            -- Cập nhật lại số lượng sản phẩm trong bảng SAN_PHAM

            UPDATE SAN_PHAM

            SET SoLuong = SoLuong + @SoLuong

            WHERE MaSP = @MaSP;

            FETCH NEXT FROM ProductCursor INTO @MaSP, @SoLuong;

        END

        CLOSE ProductCursor;

        DEALLOCATE ProductCursor;

    END

	 -- Xóa sản phẩm đã chọn trong đơn hàng

    DELETE FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH;

    -- Xóa đơn hàng

    DELETE FROM DON_HANG WHERE MaDH = @MaDH;

END;

--================================================================================

--Trigger Name: TR_Not_Duplicate_Phone_Number
--Definition:
--================================================================================

--Trigger Name: TR_Not_Duplicate_Phone_Number

--Definition:

CREATE TRIGGER TR_Not_Duplicate_Phone_Number

ON dbo.TAI_KHOAN

AFTER INSERT, UPDATE

AS

BEGIN

    IF EXISTS

    (

        SELECT * 

        FROM inserted i

        WHERE EXISTS (

            SELECT * 

            FROM dbo.TAI_KHOAN TK 

            WHERE TK.SDT = i.SDT 

            AND TK.SDT <> i.SDT

        )

    ) 

    BEGIN

        RAISERROR ('Duplicate phone number is not allowed', 16, 1);

        ROLLBACK TRANSACTION;

    END

END;

--================================================================================

--Trigger Name: trg_UpdateSDT_Password
--Definition:
--================================================================================

--Trigger Name: trg_UpdateSDT_Password

--Definition:

CREATE TRIGGER trg_UpdateSDT_Password

ON dbo.TAI_KHOAN

AFTER UPDATE

AS

BEGIN

    -- Kiểm tra xem cột SDT hoặc Password có thay đổi không

    IF UPDATE(SDT) OR UPDATE(Password)

    BEGIN

        DECLARE @MaTK INT, @NewSDT NVARCHAR(20);

        -- Lấy MaTK và SDT mới sau khi cập nhật

        SELECT @MaTK = MaTK, @NewSDT = SDT

        FROM inserted;

        -- Cập nhật SDT trong bảng KHACH_HANG nếu MaTK tồn tại

        IF EXISTS (SELECT 1 FROM KHACH_HANG WHERE MaTK = @MaTK)

        BEGIN

            UPDATE KHACH_HANG

            SET SDT = @NewSDT

            WHERE MaTK = @MaTK;

        END

        -- Cập nhật SDT trong bảng NHAN_VIEN nếu MaTK tồn tại

        IF EXISTS (SELECT 1 FROM NHAN_VIEN WHERE MaTK = @MaTK)

        BEGIN

            UPDATE NHAN_VIEN

            SET SDT = @NewSDT

            WHERE MaTK = @MaTK;

        END

    END

END;

--================================================================================

--Trigger Name: trg_UpdateGiaSanPham
--Definition:
--================================================================================

--Trigger Name: trg_UpdateGiaSanPham

--Definition:

CREATE TRIGGER trg_UpdateGiaSanPham

ON SAN_PHAM

AFTER UPDATE

AS

BEGIN

    SET NOCOUNT ON; -- Giúp tránh thông báo số dòng bị ảnh hưởng

    DECLARE @MaSP INT;

    DECLARE @GiaMoi INT;

    -- Lấy thông tin từ bản ghi đã cập nhật

    SELECT @MaSP = i.MaSP,

           @GiaMoi = i.Gia

    FROM inserted i;

    -- Cập nhật lại đơn giá trong bảng SAN_PHAM_DUOC_CHON

    UPDATE SAN_PHAM_DUOC_CHON

    SET DonGia = @GiaMoi

    WHERE MaSP = @MaSP;

    -- Cập nhật lại đơn giá trong bảng DON_NHAP_HANG

    UPDATE DON_NHAP_HANG

    SET DonGia = @GiaMoi

    WHERE MaSP = @MaSP;

END;

--================================================================================

--Trigger Name: trg_AfterInsert_NHAN_VIEN
--Definition:
--================================================================================

--Trigger Name: trg_AfterInsert_NHAN_VIEN

--Definition:

CREATE TRIGGER [dbo].[trg_AfterInsert_NHAN_VIEN]

ON dbo.NHAN_VIEN

AFTER INSERT

AS

BEGIN

    DECLARE @ErrorMessage NVARCHAR(255);  -- Biến để lưu thông báo lỗi

    -- Kiểm tra xem số điện thoại đã tồn tại trong bảng TAI_KHOAN chưa

    IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE SDT IN (SELECT SDT FROM INSERTED))

    BEGIN

        SET @ErrorMessage = 'Số điện thoại đã tồn tại trong bảng TAI_KHOAN.';

        RAISERROR(@ErrorMessage, 16, 1);  -- Ném thông báo lỗi

        ROLLBACK TRANSACTION;  -- Hoàn tác giao dịch

        RETURN;  -- Kết thúc trigger

    END

    -- Thêm tài khoản mới vào bảng TAI_KHOAN

    INSERT INTO TAI_KHOAN (SDT, Password)

    SELECT SDT, SDT  -- Sử dụng SDT làm Password

    FROM INSERTED;

    -- Cập nhật MaTK trong bảng NHAN_VIEN

    UPDATE NHAN_VIEN

    SET MaTK = T.MaTK

    FROM NHAN_VIEN NV

    JOIN TAI_KHOAN T ON T.SDT = NV.SDT

    WHERE NV.MaNV IN (SELECT MaNV FROM INSERTED);

END;

--================================================================================

--Trigger Name: trg_DeleteSanPhamDuocChon
--Definition:
--================================================================================

--Trigger Name: trg_DeleteSanPhamDuocChon

--Definition:

CREATE TRIGGER trg_DeleteSanPhamDuocChon

ON SAN_PHAM_DUOC_CHON

INSTEAD OF DELETE

AS

BEGIN

    SET NOCOUNT ON; -- Giúp tránh thông báo số dòng bị ảnh hưởng

    DECLARE @MaDH INT;

    DECLARE @MaSP INT;

    DECLARE @SoLuong INT;

    DECLARE @TrangThaiDonHang NVARCHAR(50);

    DECLARE @TriGia INT;

    -- Lấy mã đơn hàng và mã sản phẩm bị xóa

    SELECT @MaDH = deleted.MaDH, @MaSP = deleted.MaSP, @SoLuong = deleted.SoLuong FROM deleted;

    -- Kiểm tra xem MaSP có phải NULL không

    IF @MaSP IS NULL

    BEGIN

        -- Nếu MaSP là NULL, xóa sản phẩm đã chọn mà không cần cập nhật số lượng sản phẩm

        DELETE FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH;

    END

    ELSE

    BEGIN

        -- Kiểm tra trạng thái của đơn hàng

        SELECT @TrangThaiDonHang = TrangThaiDonHang FROM DON_HANG WHERE MaDH = @MaDH;

        -- Nếu đơn hàng chưa giao, trả lại số lượng sản phẩm

        IF @TrangThaiDonHang <> N'Đã giao'

        BEGIN

            -- Cập nhật số lượng sản phẩm trong bảng SAN_PHAM

            UPDATE SAN_PHAM

            SET SoLuong = SoLuong + @SoLuong

            WHERE MaSP = @MaSP;

        END

        -- Xóa sản phẩm đã chọn duy nhất từ bảng SAN_PHAM_DUOC_CHON

        DELETE FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH AND MaSP = @MaSP;

    END

    -- Tính tổng giá trị của đơn hàng sau khi xóa sản phẩm

    SELECT @TriGia = SUM(DonGia) 

    FROM SAN_PHAM_DUOC_CHON 

    WHERE MaDH = @MaDH;

    -- Nếu @TriGia là NULL, gán giá trị là 0

    IF @TriGia IS NULL

    BEGIN

        SET @TriGia = 0;

    END

    -- Cập nhật giá trị của đơn hàng trong bảng DON_HANG

    UPDATE DON_HANG

    SET TriGia = @TriGia

    WHERE MaDH = @MaDH;

    -- Nếu tổng giá trị đơn hàng bằng 0, cập nhật trạng thái thành "Đã hủy"

    IF @TriGia = 0

    BEGIN

        UPDATE DON_HANG

        SET TrangThaiDonHang = N'Đã hủy'

        WHERE MaDH = @MaDH;

    END

END;

--================================================================================

--Trigger Name: trg_XoaNhanVien
--Definition:
--================================================================================

--Trigger Name: trg_XoaNhanVien

--Definition:

CREATE TRIGGER trg_XoaNhanVien

ON dbo.NHAN_VIEN

AFTER DELETE

AS

BEGIN

    -- Xóa các ca làm việc của nhân viên bị xóa

    DELETE FROM CA_LAM_VIEC

    WHERE MaNV IN (SELECT MaNV FROM DELETED);

    -- Xóa tài khoản dựa trên SDT của nhân viên bị xóa

    DELETE FROM TAI_KHOAN

    WHERE SDT IN (SELECT SDT FROM DELETED);

END;

--================================================================================

--Trigger Name: trg_XoaCongViec
--Definition:
--================================================================================

--Trigger Name: trg_XoaCongViec

--Definition:

CREATE TRIGGER trg_XoaCongViec

ON CONG_VIEC

INSTEAD OF DELETE

AS

BEGIN

    DECLARE @NgayXoa DATE = CAST(GETDATE() AS DATE); -- Lấy ngày xóa hiện tại

    -- Kiểm tra mã nhân viên có liên quan

    DECLARE @MaNV NVARCHAR(MAX);

    SELECT @MaNV = STRING_AGG(CAST(MaNV AS NVARCHAR), ', ') -- Tạo danh sách mã nhân viên

    FROM NHAN_VIEN 

    WHERE MaCV IN (SELECT MaCV FROM DELETED);

    PRINT 'Mã nhân viên bị ảnh hưởng: ' + ISNULL(@MaNV, 'Không có');

    -- Xóa các ca làm việc của nhân viên có công việc vừa bị xóa

    DELETE FROM CA_LAM_VIEC

    WHERE MaNV IN (

        SELECT MaNV 

        FROM NHAN_VIEN 

        WHERE MaCV IN (SELECT MaCV FROM DELETED)

    )

    AND CAST(ThoiGianBatDau AS DATE) >= @NgayXoa; -- So sánh với ngày

    PRINT 'Số ca làm việc đã bị xóa: ' + CAST(@@ROWCOUNT AS NVARCHAR);

    -- Sau khi xóa ca làm việc, xóa công việc trong bảng CONG_VIEC

    DELETE FROM CONG_VIEC

    WHERE MaCV IN (SELECT MaCV FROM DELETED);

END;

--================================================================================

--Trigger Name: TRG_UpdateSDTNhanVien
--Definition:
--================================================================================

--Trigger Name: TRG_UpdateSDTNhanVien

--Definition:

CREATE TRIGGER TRG_UpdateSDTNhanVien

ON NHAN_VIEN

AFTER UPDATE

AS

BEGIN

    -- Kiểm tra xem SDT có bị thay đổi không

    IF UPDATE(SDT)

    BEGIN

        -- Cập nhật số điện thoại trong bảng TAI_KHOAN nếu SDT đã thay đổi

        UPDATE TAI_KHOAN

        SET SDT = i.SDT

        FROM TAI_KHOAN tk

        JOIN inserted i ON tk.MaTK = i.MaTK

        JOIN deleted d ON d.MaTK = i.MaTK

        WHERE i.SDT <> d.SDT;  -- Chỉ cập nhật nếu giá trị SDT mới khác giá trị cũ

    END

END;

--================================================================================

--Trigger Name: trg_AfterInsertSanPhamDuocChon
--Definition:
--================================================================================

--Trigger Name: trg_AfterInsertSanPhamDuocChon

--Definition:

CREATE TRIGGER trg_AfterInsertSanPhamDuocChon

ON SAN_PHAM_DUOC_CHON

INSTEAD OF INSERT

AS

BEGIN

    DECLARE @productPrice INT;

    DECLARE @currentQuantity INT;

    DECLARE @MaSP INT;

    DECLARE @SoLuong INT;

    DECLARE @MaDH INT;

    DECLARE @TriGia INT;

    DECLARE @existingQuantity INT;

    -- Lấy thông tin từ bảng mới

    SELECT @MaSP = MaSP, @SoLuong = SoLuong, @MaDH = MaDH FROM INSERTED;

    -- Lấy giá sản phẩm từ bảng SAN_PHAM

    SELECT @productPrice = Gia, @currentQuantity = SoLuong

    FROM SAN_PHAM

    WHERE MaSP = @MaSP;

    -- Kiểm tra số lượng có đủ không

    IF @SoLuong > @currentQuantity

    BEGIN

        RAISERROR('Khong du so luong san pham!', 16, 1);

        RETURN;

    END

    -- Kiểm tra xem sản phẩm đã tồn tại trong SAN_PHAM_DUOC_CHON chưa

    IF EXISTS (SELECT 1 FROM SAN_PHAM_DUOC_CHON WHERE MaSP = @MaSP AND MaDH = @MaDH)

    BEGIN

        -- Nếu có, lấy số lượng hiện tại trong SAN_PHAM_DUOC_CHON

        SELECT @existingQuantity = SoLuong FROM SAN_PHAM_DUOC_CHON WHERE MaSP = @MaSP AND MaDH = @MaDH;

        -- Cập nhật số lượng và giá trị

        UPDATE SAN_PHAM_DUOC_CHON

        SET SoLuong = @existingQuantity + @SoLuong,

            DonGia = (@existingQuantity + @SoLuong) * @productPrice

        WHERE MaSP = @MaSP AND MaDH = @MaDH;

        -- Trừ số lượng sản phẩm trong bảng SAN_PHAM

        UPDATE SAN_PHAM

        SET SoLuong = SoLuong - @SoLuong

        WHERE MaSP = @MaSP;

    END

    ELSE

    BEGIN

        -- Nếu không có, trừ số lượng sản phẩm trong bảng SAN_PHAM

        UPDATE SAN_PHAM

        SET SoLuong = SoLuong - @SoLuong

        WHERE MaSP = @MaSP;

        -- Chèn dòng mới vào bảng SAN_PHAM_DUOC_CHON

        INSERT INTO SAN_PHAM_DUOC_CHON (SoLuong, DonGia, MaSP, MaDH)

        VALUES (@SoLuong, @SoLuong * @productPrice, @MaSP, @MaDH);

    END

    -- Tính tổng giá trị của tất cả sản phẩm được chọn trong đơn hàng

    SELECT @TriGia = SUM(DonGia)

    FROM SAN_PHAM_DUOC_CHON

    WHERE MaDH = @MaDH;

    -- Cập nhật giá trị của đơn hàng trong bảng DON_HANG

    UPDATE DON_HANG

    SET TriGia = @TriGia

    WHERE MaDH = @MaDH;

END;

--================================================================================

--Trigger Name: trg_AfterInsert_KHACH_HANG
--Definition:
--================================================================================

--Trigger Name: trg_AfterInsert_KHACH_HANG

--Definition:

CREATE TRIGGER [dbo].[trg_AfterInsert_KHACH_HANG]

ON [dbo].[KHACH_HANG]

AFTER INSERT

AS

BEGIN

    DECLARE @ErrorMessage NVARCHAR(255);  -- Biến để lưu thông báo lỗi

    -- Kiểm tra xem số điện thoại đã tồn tại trong bảng TAI_KHOAN chưa

    IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE SDT IN (SELECT SDT FROM INSERTED))

    BEGIN

        SET @ErrorMessage = 'Số điện thoại đã tồn tại trong bảng TAI_KHOAN.';

        RAISERROR(@ErrorMessage, 16, 1);  -- Ném thông báo lỗi

        ROLLBACK TRANSACTION;  -- Hoàn tác giao dịch

        RETURN;  -- Kết thúc trigger

    END

    -- Thêm tài khoản mới vào bảng TAI_KHOAN

    INSERT INTO TAI_KHOAN (SDT, Password)

    SELECT SDT, SDT  -- Sử dụng SDT làm Password

    FROM INSERTED;

    -- Cập nhật MaTK trong bảng KHACH_HANG

    UPDATE KHACH_HANG

    SET MaTK = T.MaTK

    FROM KHACH_HANG KH

    JOIN TAI_KHOAN T ON T.SDT = KH.SDT

    WHERE KH.MaKH IN (SELECT MaKH FROM INSERTED);

END;

--================================================================================

--Trigger Name: trg_UpdateSanPhamAfterUpdate
--Definition:
--================================================================================

--Trigger Name: trg_UpdateSanPhamAfterUpdate

--Definition:

CREATE TRIGGER trg_UpdateSanPhamAfterUpdate

ON DON_NHAP_HANG

AFTER UPDATE

AS

BEGIN

    SET NOCOUNT ON;

    -- Đặt cờ kiểm tra để tránh kích hoạt lại chính trigger này

    DECLARE @context VARBINARY(128) = CAST(1 AS VARBINARY(128));

    IF CONTEXT_INFO() = @context RETURN;

    -- Đặt cờ kiểm tra

    SET CONTEXT_INFO @context;

    DECLARE @MaSP INT, @SoLuongCu INT, @SoLuongMoi INT, @DonGia INT, @GiaTri INT;

    -- Lấy thông tin từ bản ghi đã cập nhật

    SELECT @MaSP = i.MaSP, 

           @SoLuongCu = d.SoLuong, 

           @SoLuongMoi = i.SoLuong,

           @DonGia = i.DonGia  

    FROM inserted i

    INNER JOIN deleted d ON i.MaDon = d.MaDon;

    -- Kiểm tra và cập nhật số lượng sản phẩm

    IF @SoLuongMoi > @SoLuongCu

    BEGIN

        UPDATE SAN_PHAM

        SET SoLuong = SoLuong + (@SoLuongMoi - @SoLuongCu)

        WHERE MaSP = @MaSP;

    END

    ELSE

    BEGIN

        DECLARE @SoLuongHienTai INT;

        SELECT @SoLuongHienTai = SoLuong FROM SAN_PHAM WHERE MaSP = @MaSP;

        IF @SoLuongHienTai >= (@SoLuongCu - @SoLuongMoi)

        BEGIN

            UPDATE SAN_PHAM

            SET SoLuong = SoLuong - (@SoLuongCu - @SoLuongMoi)

            WHERE MaSP = @MaSP;

        END

        ELSE

        BEGIN

            RAISERROR('Không đủ số lượng sản phẩm để trừ.', 16, 1);

            RETURN;

        END

    END

    -- Cập nhật lại giá trị đơn hàng

    SET @GiaTri = @SoLuongMoi * @DonGia;

    UPDATE DON_NHAP_HANG

    SET GiaTri = @GiaTri

    WHERE MaSP = @MaSP AND MaDon IN (SELECT MaDon FROM inserted);

    -- Xóa cờ kiểm tra

    SET CONTEXT_INFO 0x0;

END;

--================================================================================

--Trigger Name: TRG_UpdateSDTKhachHang
--Definition:
--================================================================================

--Trigger Name: TRG_UpdateSDTKhachHang

--Definition:

CREATE TRIGGER TRG_UpdateSDTKhachHang

ON KHACH_HANG

AFTER UPDATE

AS

BEGIN

    -- Kiểm tra xem SDT có bị thay đổi không

    IF UPDATE(SDT)

    BEGIN

        -- Cập nhật số điện thoại trong bảng TAI_KHOAN nếu SDT đã thay đổi

        UPDATE TAI_KHOAN

        SET SDT = i.SDT

        FROM TAI_KHOAN tk

        JOIN inserted i ON tk.MaTK = i.MaTK

        JOIN deleted d ON d.MaTK = i.MaTK

        WHERE i.SDT <> d.SDT;  -- Chỉ cập nhật nếu giá trị SDT mới khác giá trị cũ

    END

END;

--================================================================================

--Trigger Name: trg_InsertDonNhapHang
--Definition:
--================================================================================

--Trigger Name: trg_InsertDonNhapHang

--Definition:

CREATE TRIGGER trg_InsertDonNhapHang

ON DON_NHAP_HANG

AFTER INSERT

AS

BEGIN

    SET NOCOUNT ON;

    -- Đặt cờ kiểm tra để tránh kích hoạt lại chính trigger này

    DECLARE @context VARBINARY(128) = CAST(1 AS VARBINARY(128));

    IF CONTEXT_INFO() = @context RETURN;

    -- Đặt cờ để không lặp

    SET CONTEXT_INFO @context;

    -- Cập nhật DonGia và GiaTri cho các bản ghi mới chèn vào DON_NHAP_HANG

    UPDATE DN

    SET DN.DonGia = SP.Gia,

        DN.GiaTri = DN.SoLuong * SP.Gia

    FROM DON_NHAP_HANG DN

    INNER JOIN INSERTED I ON DN.MaDon = I.MaDon

    INNER JOIN SAN_PHAM SP ON I.MaSP = SP.MaSP;

    -- Cập nhật số lượng sản phẩm trong bảng SAN_PHAM

    UPDATE SP

    SET SP.SoLuong = SP.SoLuong + I.SoLuong

    FROM SAN_PHAM SP

    INNER JOIN INSERTED I ON SP.MaSP = I.MaSP;

    -- Xóa cờ kiểm tra sau khi trigger hoàn thành

    SET CONTEXT_INFO 0x0;

END;

--================================================================================

--Trigger Name: trg_XoaKhachHang
--Definition:
--================================================================================

--Trigger Name: trg_XoaKhachHang

--Definition:

CREATE TRIGGER trg_XoaKhachHang

ON KHACH_HANG

INSTEAD OF DELETE

AS

BEGIN

    SET NOCOUNT ON;

    BEGIN TRY

        BEGIN TRANSACTION;

        DECLARE @MaKH INT;

        -- Get the customer ID from the deleted row

        SELECT @MaKH = MaKH FROM DELETED;

        DECLARE @MaDH INT;

        -- Cursor to iterate through the orders of the customer

        DECLARE OrderCursor CURSOR FOR

        SELECT MaDH FROM DON_HANG WHERE MaKH = @MaKH;

        OPEN OrderCursor;

        FETCH NEXT FROM OrderCursor INTO @MaDH;

        WHILE @@FETCH_STATUS = 0

        BEGIN

            DECLARE @TrangThaiDonHang VARCHAR(50);

            DECLARE @MaSP INT;

            DECLARE @SoLuong INT;

            -- Get the order status

            SELECT @TrangThaiDonHang = TrangThaiDonHang FROM DON_HANG WHERE MaDH = @MaDH;

            IF @TrangThaiDonHang <> N'Đã giao'

            BEGIN

                -- Get the products selected in the order

                DECLARE ProductCursor CURSOR FOR

                SELECT MaSP, SoLuong FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH;

                OPEN ProductCursor;

                FETCH NEXT FROM ProductCursor INTO @MaSP, @SoLuong;

                WHILE @@FETCH_STATUS = 0

                BEGIN

                    -- Update product quantity in SAN_PHAM

                    UPDATE SAN_PHAM

                    SET SoLuong = SoLuong + @SoLuong

                    WHERE MaSP = @MaSP;

                    FETCH NEXT FROM ProductCursor INTO @MaSP, @SoLuong;

                END

                CLOSE ProductCursor;

                DEALLOCATE ProductCursor;

            END

            -- Delete selected products from SAN_PHAM_DUOC_CHON

            DELETE FROM SAN_PHAM_DUOC_CHON WHERE MaDH = @MaDH;

            -- Delete the order from DON_HANG

            DELETE FROM DON_HANG WHERE MaDH = @MaDH;

            -- Delete the payment record from THANH_TOAN

            DELETE FROM THANH_TOAN WHERE MaDH = @MaDH AND MaKH = @MaKH;

            FETCH NEXT FROM OrderCursor INTO @MaDH;

        END

        CLOSE OrderCursor;

        DEALLOCATE OrderCursor;

        -- No need to delete the customer here as it's the trigger for when a customer is deleted.

		 DELETE FROM KHACH_HANG WHERE MaKH = @MaKH;

        COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

        ROLLBACK TRANSACTION;

        -- Handle the error (you can log it or return an error message)

        DECLARE @ErrorMessage NVARCHAR(4000);

        DECLARE @ErrorSeverity INT;

        DECLARE @ErrorState INT;

        SELECT 

            @ErrorMessage = ERROR_MESSAGE(),

            @ErrorSeverity = ERROR_SEVERITY(),

            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);

    END CATCH;

END;

--================================================================================

