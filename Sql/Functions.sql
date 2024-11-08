-- 5 Function

--Function Name: LaySanPhamSoLuongThapHon
--Definition:
CREATE FUNCTION dbo.LaySanPhamSoLuongThapHon

(

    @SoLuongNhap INT

)

RETURNS TABLE

AS

RETURN

(

    SELECT *

    FROM SAN_PHAM

    WHERE SoLuong < @SoLuongNhap

);

--================================================================================

--Function Name: fn_diagramobjects
--Definition:
--================================================================================

--Function Name: fn_diagramobjects

--Definition:

	CREATE FUNCTION dbo.fn_diagramobjects() 

	RETURNS int

	WITH EXECUTE AS N'dbo'

	AS

	BEGIN

		declare @id_upgraddiagrams		int

		declare @id_sysdiagrams			int

		declare @id_helpdiagrams		int

		declare @id_helpdiagramdefinition	int

		declare @id_creatediagram	int

		declare @id_renamediagram	int

		declare @id_alterdiagram 	int 

		declare @id_dropdiagram		int

		declare @InstalledObjects	int

		select @InstalledObjects = 0

		select 	@id_upgraddiagrams = object_id(N'dbo.sp_upgraddiagrams'),

			@id_sysdiagrams = object_id(N'dbo.sysdiagrams'),

			@id_helpdiagrams = object_id(N'dbo.sp_helpdiagrams'),

			@id_helpdiagramdefinition = object_id(N'dbo.sp_helpdiagramdefinition'),

			@id_creatediagram = object_id(N'dbo.sp_creatediagram'),

			@id_renamediagram = object_id(N'dbo.sp_renamediagram'),

			@id_alterdiagram = object_id(N'dbo.sp_alterdiagram'), 

			@id_dropdiagram = object_id(N'dbo.sp_dropdiagram')

		if @id_upgraddiagrams is not null

			select @InstalledObjects = @InstalledObjects + 1

		if @id_sysdiagrams is not null

			select @InstalledObjects = @InstalledObjects + 2

		if @id_helpdiagrams is not null

			select @InstalledObjects = @InstalledObjects + 4

		if @id_helpdiagramdefinition is not null

			select @InstalledObjects = @InstalledObjects + 8

		if @id_creatediagram is not null

			select @InstalledObjects = @InstalledObjects + 16

		if @id_renamediagram is not null

			select @InstalledObjects = @InstalledObjects + 32

		if @id_alterdiagram  is not null

			select @InstalledObjects = @InstalledObjects + 64

		if @id_dropdiagram is not null

			select @InstalledObjects = @InstalledObjects + 128

		return @InstalledObjects 

	END

--================================================================================

--Function Name: ThongKeDonHangTheoNgay
--Definition:
--================================================================================

--Function Name: ThongKeDonHangTheoNgay

--Definition:

CREATE FUNCTION dbo.ThongKeDonHangTheoNgay

(

    @TuNgay DATETIME,

    @DenNgay DATETIME

)

RETURNS TABLE

AS

RETURN

(

    SELECT 

        CAST(NgayDatHang AS DATE) AS Ngay,

        COUNT(MaDH) AS TongSoDonHang,

        SUM(TriGia) AS TongTriGia

    FROM 

        DON_HANG

    WHERE 

        NgayDatHang BETWEEN @TuNgay AND @DenNgay

    GROUP BY 

        CAST(NgayDatHang AS DATE)

);

--================================================================================

--Function Name: TinhTongDoanhThuTheoSanPham
--Definition:
--================================================================================

--Function Name: TinhTongDoanhThuTheoSanPham

--Definition:

CREATE FUNCTION dbo.TinhTongDoanhThuTheoSanPham

(

    @MaSP INT

)

RETURNS INT

AS

BEGIN

    DECLARE @TongDoanhThu INT;

    SELECT @TongDoanhThu = SUM(SoLuong * DonGia)

    FROM SAN_PHAM_DUOC_CHON

    WHERE MaSP = @MaSP;

    RETURN ISNULL(@TongDoanhThu, 0);

END;

--================================================================================

--Function Name: fn_KiemTraTaiKhoan
--Definition:
--================================================================================

--Function Name: fn_KiemTraTaiKhoan

--Definition:

CREATE FUNCTION fn_KiemTraTaiKhoan (

    @SDT NVARCHAR(20),

    @Password NVARCHAR(50)

)

RETURNS @ResultTable TABLE (Result INT, UserID INT) -- Kết quả bao gồm Result và UserID

AS

BEGIN

    DECLARE @UserID INT;

    -- Kiểm tra nếu SDT và Password có tồn tại trong bảng TAI_KHOAN

    IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE SDT = @SDT AND Password = @Password)

    BEGIN

        -- Kiểm tra nếu SDT thuộc bảng NHAN_VIEN

        IF EXISTS (SELECT 1 FROM NHAN_VIEN WHERE SDT = @SDT)

        BEGIN

            -- Lấy ID của nhân viên

            SELECT @UserID = MaNV FROM NHAN_VIEN WHERE SDT = @SDT;

            -- Kiểm tra nếu nhân viên là admin

            IF EXISTS (SELECT 1 FROM NHAN_VIEN NV

                       JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV

                       WHERE NV.SDT = @SDT AND CV.TenCV = 'admin')

            BEGIN

                INSERT INTO @ResultTable (Result, UserID) VALUES (1, @UserID); -- Trả về 1 nếu là admin

            END

            ELSE

            BEGIN

                INSERT INTO @ResultTable (Result, UserID) VALUES (2, @UserID); -- Trả về 2 nếu là nhân viên nhưng không phải admin

            END

        END

        -- Kiểm tra nếu SDT thuộc bảng KHACH_HANG

        ELSE IF EXISTS (SELECT 1 FROM KHACH_HANG WHERE SDT = @SDT)

        BEGIN

            -- Lấy ID của khách hàng

            SELECT @UserID = MaKH FROM KHACH_HANG WHERE SDT = @SDT;

            INSERT INTO @ResultTable (Result, UserID) VALUES (3, @UserID); -- Trả về 3 nếu là khách hàng

        END

        ELSE

        BEGIN

            INSERT INTO @ResultTable (Result, UserID) VALUES (-1, NULL); -- Không tìm thấy SDT trong bảng NHAN_VIEN hoặc KHACH_HANG

        END

    END

    ELSE

    BEGIN

        INSERT INTO @ResultTable (Result, UserID) VALUES (-1, NULL); -- Không tìm thấy tài khoản khớp với SDT và Password

    END

    RETURN;

END;

--================================================================================

