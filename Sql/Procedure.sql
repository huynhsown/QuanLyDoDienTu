-- 85 procedure

--Procedure Name: sp_GetDonHang
--Definition:
--================================================================================

--Procedure Name: sp_GetDonHang

--Definition:

CREATE PROCEDURE sp_GetDonHang

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaDH, NgayDatHang, TrangThaiDonHang, TriGia, MaUngDung, MaKH

    FROM DON_HANG;

END;

--================================================================================

--Procedure Name: sp_renamediagram
--Definition:
--================================================================================

--Procedure Name: sp_renamediagram

--Definition:

	CREATE PROCEDURE dbo.sp_renamediagram

	(

		@diagramname 		sysname,

		@owner_id		int	= null,

		@new_diagramname	sysname

	)

	WITH EXECUTE AS 'dbo'

	AS

	BEGIN

		set nocount on

		declare @theId 			int

		declare @IsDbo 			int

		declare @UIDFound 		int

		declare @DiagId			int

		declare @DiagIdTarg		int

		declare @u_name			sysname

		if((@diagramname is null) or (@new_diagramname is null))

		begin

			RAISERROR ('Invalid value', 16, 1);

			return -1

		end

		EXECUTE AS CALLER;

		select @theId = DATABASE_PRINCIPAL_ID();

		select @IsDbo = IS_MEMBER(N'db_owner'); 

		if(@owner_id is null)

			select @owner_id = @theId;

		REVERT;

		select @u_name = USER_NAME(@owner_id)

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 

		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))

		begin

			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)

			return -3

		end

		-- if((@u_name is not null) and (@new_diagramname = @diagramname))	-- nothing will change

		--	return 0;

		if(@u_name is null)

			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @new_diagramname

		else

			select @DiagIdTarg = diagram_id from dbo.sysdiagrams where principal_id = @owner_id and name = @new_diagramname

		if((@DiagIdTarg is not null) and  @DiagId <> @DiagIdTarg)

		begin

			RAISERROR ('The name is already used.', 16, 1);

			return -2

		end		

		if(@u_name is null)

			update dbo.sysdiagrams set [name] = @new_diagramname, principal_id = @theId where diagram_id = @DiagId

		else

			update dbo.sysdiagrams set [name] = @new_diagramname where diagram_id = @DiagId

		return 0

	END

--================================================================================

--Procedure Name: sp_GetDonNhapHang
--Definition:
--================================================================================

--Procedure Name: sp_GetDonNhapHang

--Definition:

CREATE PROCEDURE sp_GetDonNhapHang

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaDon, NgayNhap, GiaTri, SoLuong, DonGia, MaSP, MaNSX

    FROM DON_NHAP_HANG;

END;

--================================================================================

--Procedure Name: sp_alterdiagram
--Definition:
--================================================================================

--Procedure Name: sp_alterdiagram

--Definition:

	CREATE PROCEDURE dbo.sp_alterdiagram

	(

		@diagramname 	sysname,

		@owner_id	int	= null,

		@version 	int,

		@definition 	varbinary(max)

	)

	WITH EXECUTE AS 'dbo'

	AS

	BEGIN

		set nocount on

		declare @theId 			int

		declare @retval 		int

		declare @IsDbo 			int

		declare @UIDFound 		int

		declare @DiagId			int

		declare @ShouldChangeUID	int

		if(@diagramname is null)

		begin

			RAISERROR ('Invalid ARG', 16, 1)

			return -1

		end

		execute as caller;

		select @theId = DATABASE_PRINCIPAL_ID();	 

		select @IsDbo = IS_MEMBER(N'db_owner'); 

		if(@owner_id is null)

			select @owner_id = @theId;

		revert;

		select @ShouldChangeUID = 0

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 

		if(@DiagId IS NULL or (@IsDbo = 0 and @theId <> @UIDFound))

		begin

			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);

			return -3

		end

		if(@IsDbo <> 0)

		begin

			if(@UIDFound is null or USER_NAME(@UIDFound) is null) -- invalid principal_id

			begin

				select @ShouldChangeUID = 1 ;

			end

		end

		-- update dds data			

		update dbo.sysdiagrams set definition = @definition where diagram_id = @DiagId ;

		-- change owner

		if(@ShouldChangeUID = 1)

			update dbo.sysdiagrams set principal_id = @theId where diagram_id = @DiagId ;

		-- update dds version

		if(@version is not null)

			update dbo.sysdiagrams set version = @version where diagram_id = @DiagId ;

		return 0

	END

--================================================================================

--Procedure Name: sp_GetUngDung
--Definition:
--================================================================================

--Procedure Name: sp_GetUngDung

--Definition:

CREATE PROCEDURE sp_GetUngDung

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaUngDung, TenUngDung, ChietKhau

    FROM UNG_DUNG;

END;

--================================================================================

--Procedure Name: sp_dropdiagram
--Definition:
--================================================================================

--Procedure Name: sp_dropdiagram

--Definition:

	CREATE PROCEDURE dbo.sp_dropdiagram

	(

		@diagramname 	sysname,

		@owner_id	int	= null

	)

	WITH EXECUTE AS 'dbo'

	AS

	BEGIN

		set nocount on

		declare @theId 			int

		declare @IsDbo 			int

		declare @UIDFound 		int

		declare @DiagId			int

		if(@diagramname is null)

		begin

			RAISERROR ('Invalid value', 16, 1);

			return -1

		end

		EXECUTE AS CALLER;

		select @theId = DATABASE_PRINCIPAL_ID();

		select @IsDbo = IS_MEMBER(N'db_owner'); 

		if(@owner_id is null)

			select @owner_id = @theId;

		REVERT; 

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname 

		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId))

		begin

			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1)

			return -3

		end

		delete from dbo.sysdiagrams where diagram_id = @DiagId;

		return 0;

	END

--================================================================================

--Procedure Name: sp_GetNhanVien
--Definition:
--================================================================================

--Procedure Name: sp_GetNhanVien

--Definition:

CREATE PROCEDURE sp_GetNhanVien

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaNV, HoTen, NgaySinh, GioiTinh, SDT, Email, DiaChi

    FROM NHAN_VIEN;

END;

--================================================================================

--Procedure Name: sp_GetKhachHang
--Definition:
--================================================================================

--Procedure Name: sp_GetKhachHang

--Definition:

CREATE PROCEDURE sp_GetKhachHang

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaKH, HoTen, SDT, Email, DiaChi

    FROM KHACH_HANG;

END;

--================================================================================

--Procedure Name: sp_GetNhaSanXuat
--Definition:
--================================================================================

--Procedure Name: sp_GetNhaSanXuat

--Definition:

CREATE PROCEDURE sp_GetNhaSanXuat

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaNSX, TenNSX, SDT, Email

    FROM NHA_SAN_XUAT;

END;

--================================================================================

--Procedure Name: sp_GetProducts
--Definition:
--================================================================================

--Procedure Name: sp_GetProducts

--Definition:

CREATE PROCEDURE sp_GetProducts

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaSP, TenSP, Gia, TinhTrang

    FROM SAN_PHAM;

END;

--================================================================================

--Procedure Name: XoaNhanVien
--Definition:
--================================================================================

--Procedure Name: XoaNhanVien

--Definition:

CREATE PROCEDURE XoaNhanVien

    @MaNV INT

AS

BEGIN

    DELETE FROM NHAN_VIEN WHERE MaNV = @MaNV;

END;

--================================================================================

--Procedure Name: UpdateNhanVienWithoutJob
--Definition:
--================================================================================

--Procedure Name: UpdateNhanVienWithoutJob

--Definition:

CREATE PROCEDURE UpdateNhanVienWithoutJob

    @MaNV INT,

    @HoTen NVARCHAR(100),

    @NgaySinh DATE,

    @GioiTinh NVARCHAR(10),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100),

    @DiaChi NVARCHAR(200)

AS

BEGIN

    UPDATE NHAN_VIEN

    SET 

        HoTen = @HoTen,

        NgaySinh = @NgaySinh,

        GioiTinh = @GioiTinh,

        SDT = @SDT,

        Email = @Email,

        DiaChi = @DiaChi

    WHERE 

        MaNV = @MaNV;

END;

--================================================================================

--Procedure Name: XoaKhachHang
--Definition:
--================================================================================

--Procedure Name: XoaKhachHang

--Definition:

CREATE PROCEDURE XoaKhachHang

    @MaKH INT -- Customer ID to delete

AS

BEGIN

    BEGIN TRY

        BEGIN TRANSACTION;

        -- No need to handle orders or related records; this will be managed by the trigger

        -- Finally, delete the customer

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

--Procedure Name: spGetJobsByMaCV
--Definition:
--================================================================================

--Procedure Name: spGetJobsByMaCV

--Definition:

CREATE PROCEDURE spGetJobsByMaCV

    @MaCV INT

AS

BEGIN

    SET NOCOUNT ON;  -- Tắt thông báo số hàng bị ảnh hưởng

    -- Truy vấn lấy thông tin công việc theo mã công việc

    SELECT MaCV, TenCV, Luong

    FROM CONG_VIEC

    WHERE MaCV = @MaCV;

END

--================================================================================

--Procedure Name: SearchManufacturerByMaNSX
--Definition:
--================================================================================

--Procedure Name: SearchManufacturerByMaNSX

--Definition:

-- MaNSX

CREATE PROCEDURE SearchManufacturerByMaNSX

    @MaNSX INT

AS

BEGIN

    SELECT MaNSX, TenNSX, SDT

    FROM NHA_SAN_XUAT

    WHERE MaNSX = @MaNSX;

END

--================================================================================

--Procedure Name: SearchManufacturerByTenNSX
--Definition:
--================================================================================

--Procedure Name: SearchManufacturerByTenNSX

--Definition:

-- Ten NSX

CREATE PROCEDURE SearchManufacturerByTenNSX

    @TenNSX NVARCHAR(100)

AS

BEGIN

    SELECT MaNSX, TenNSX, SDT

    FROM NHA_SAN_XUAT

    WHERE TenNSX LIKE '%' + @TenNSX + '%';

END

--================================================================================

--Procedure Name: SearchManufacturerBySDT
--Definition:
--================================================================================

--Procedure Name: SearchManufacturerBySDT

--Definition:

-- SDT NSX

CREATE PROCEDURE SearchManufacturerBySDT

    @SDT NVARCHAR(20)

AS

BEGIN

    SELECT MaNSX, TenNSX, SDT

    FROM NHA_SAN_XUAT

    WHERE SDT LIKE '%' + @SDT + '%';

END

--================================================================================

--Procedure Name: SearchKhachHangByMaKH
--Definition:
--================================================================================

--Procedure Name: SearchKhachHangByMaKH

--Definition:

CREATE PROCEDURE SearchKhachHangByMaKH

    @MaKH INT

AS

BEGIN

    SELECT MaKH, HoTen, DiaChi, SDT, Email, MaTK

    FROM KHACH_HANG

    WHERE MaKH = @MaKH;

END;

--================================================================================

--Procedure Name: SearchKhachHangBySDT
--Definition:
--================================================================================

--Procedure Name: SearchKhachHangBySDT

--Definition:

CREATE PROCEDURE SearchKhachHangBySDT

    @SDT NVARCHAR(20)

AS

BEGIN

    SELECT MaKH, HoTen, DiaChi, SDT, Email, MaTK

    FROM KHACH_HANG

    WHERE SDT = @SDT;

END;

--================================================================================

--Procedure Name: SearchProductByMaSP
--Definition:
--================================================================================

--Procedure Name: SearchProductByMaSP

--Definition:

CREATE PROCEDURE SearchProductByMaSP

    @MaSP INT -- Parameter to receive the product ID

AS

BEGIN

    -- Select the product details based on the provided MaSP

    SELECT *

    FROM SAN_PHAM

    WHERE MaSP = @MaSP; 

END;

--================================================================================

--Procedure Name: SearchEmployeeByMaNV
--Definition:
--================================================================================

--Procedure Name: SearchEmployeeByMaNV

--Definition:

-- Ma NV

CREATE PROCEDURE SearchEmployeeByMaNV

    @MaNV INT -- Parameter to receive the employee ID

AS

BEGIN

    -- Select the employee details based on the provided MaNV

    SELECT *

    FROM NHAN_VIEN

    WHERE MaNV = @MaNV;

END;

--================================================================================

--Procedure Name: SearchEmployeeBySDT
--Definition:
--================================================================================

--Procedure Name: SearchEmployeeBySDT

--Definition:

CREATE PROCEDURE SearchEmployeeBySDT

    @SDT NVARCHAR(20) -- Parameter to receive the phone number

AS

BEGIN

    -- Select the employee details based on the provided SDT

    SELECT *

    FROM NHAN_VIEN

    WHERE SDT = @SDT;

END;

--================================================================================

--Procedure Name: SearchEmployeeByTenNV
--Definition:
--================================================================================

--Procedure Name: SearchEmployeeByTenNV

--Definition:

CREATE PROCEDURE SearchEmployeeByTenNV

    @TenNV NVARCHAR(100)

AS

BEGIN

    SELECT 

        MaNV, 

		HoTen, 

        NgaySinh, 

        GioiTinh, 

        SDT, 

        Email, 

        DiaChi, 

        MaCV

    FROM 

        NHAN_VIEN

    WHERE 

        HoTen LIKE '%' + @TenNV + '%';

END;

--================================================================================

--Procedure Name: SearchPurchaseOrdersByProductName
--Definition:
--================================================================================

--Procedure Name: SearchPurchaseOrdersByProductName

--Definition:

CREATE PROCEDURE SearchPurchaseOrdersByProductName

			@tensp NVARCHAR(255) -- Tham số cho tên sản phẩm

		AS

		BEGIN

			SELECT 

				dn.MaDon, 

				dn.NgayNhap, 

				dn.GiaTri, 

				dn.SoLuong, 

				dn.DonGia, 

				sp.TenSP 

			FROM 

				DON_NHAP_HANG dn

			JOIN 

				SAN_PHAM sp ON dn.MaSP = sp.MaSP

			WHERE 

				sp.TenSP LIKE '%' + @tensp + '%'; -- Tìm kiếm tên sản phẩm

		END;

--================================================================================

--Procedure Name: sp_GetThongTinKhachHang
--Definition:
--================================================================================

--Procedure Name: sp_GetThongTinKhachHang

--Definition:

-- Procedure lấy thông tin khách hàng

CREATE PROCEDURE sp_GetThongTinKhachHang

    @MaKH INT

AS

BEGIN

    SELECT HoTen, SDT, DiaChi, Email

    FROM KHACH_HANG

    WHERE MaKH = @MaKH;

END;

--================================================================================

--Procedure Name: spGetJobsByTenCV
--Definition:
--================================================================================

--Procedure Name: spGetJobsByTenCV

--Definition:

CREATE PROCEDURE spGetJobsByTenCV

    @TenCV NVARCHAR(100)

AS

BEGIN

    SET NOCOUNT ON;

    SELECT * 

    FROM CONG_VIEC

    WHERE TenCV LIKE '%' + @TenCV + '%';

END;

--================================================================================

--Procedure Name: sp_GetAllJobs
--Definition:
--================================================================================

--Procedure Name: sp_GetAllJobs

--Definition:

CREATE PROCEDURE sp_GetAllJobs

AS

BEGIN

    SET NOCOUNT ON;

    SELECT * FROM CONG_VIEC;

END;

--================================================================================

--Procedure Name: sp_CapNhatThongTinNguoiDung
--Definition:
--================================================================================

--Procedure Name: sp_CapNhatThongTinNguoiDung

--Definition:

CREATE PROCEDURE sp_CapNhatThongTinNguoiDung

    @MaKH INT,

    @HoTen NVARCHAR(100) = NULL,

    @SDT NVARCHAR(20) = NULL,

    @DiaChi NVARCHAR(255) = NULL,

    @Email NVARCHAR(100) = NULL

AS

BEGIN

    SET NOCOUNT ON;

    UPDATE KHACH_HANG

    SET HoTen = ISNULL(@HoTen, HoTen),

        SDT = ISNULL(@SDT, SDT),

        DiaChi = ISNULL(@DiaChi, DiaChi),

        Email = ISNULL(@Email, Email)

    WHERE MaKH = @MaKH;

END;

--================================================================================

--Procedure Name: spGetJobByMaCV
--Definition:
--================================================================================

--Procedure Name: spGetJobByMaCV

--Definition:

CREATE PROCEDURE spGetJobByMaCV

    @MaCV INT

AS

BEGIN

    SELECT MaCV, TenCV, Luong 

    FROM CONG_VIEC

    WHERE MaCV = @MaCV;

END;

--================================================================================

--Procedure Name: sp_DoiMatKhau
--Definition:
--================================================================================

--Procedure Name: sp_DoiMatKhau

--Definition:

-- Procedure đổi mật khẩu 

CREATE PROCEDURE sp_DoiMatKhau

    @SDT NVARCHAR(20),

    @MatKhauHienTai NVARCHAR(50),

    @MatKhauMoi NVARCHAR(50)

AS

BEGIN

    SET NOCOUNT ON;

    -- Check if the current password is correct

    IF EXISTS (SELECT 1 FROM TAI_KHOAN WHERE SDT = @SDT AND Password = @MatKhauHienTai)

    BEGIN

        -- Update to new password

        UPDATE TAI_KHOAN

        SET Password = @MatKhauMoi

        WHERE SDT = @SDT;

    END

    ELSE

    BEGIN

        -- Raise an error if the current password is incorrect

        RAISERROR('Mật khẩu hiện tại không chính xác!', 16, 1);

    END

END;

--================================================================================

--Procedure Name: XoaUngDung
--Definition:
--================================================================================

--Procedure Name: XoaUngDung

--Definition:

CREATE PROCEDURE XoaUngDung

    @MaUD INT

AS

BEGIN

    -- Kiểm tra xem ứng dụng có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM UNG_DUNG WHERE MaUngDung = @MaUD)

    BEGIN

        RAISERROR('Không tìm thấy ứng dụng với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa ứng dụng nếu tồn tại

    DELETE FROM UNG_DUNG WHERE MaUngDung = @MaUD;

    PRINT 'Xóa ứng dụng thành công.';

END;

--================================================================================

--Procedure Name: sp_GetSanPham
--Definition:
--================================================================================

--Procedure Name: sp_GetSanPham

--Definition:

-- Hiển thị tất cả sản phẩm 

CREATE PROCEDURE sp_GetSanPham

AS

BEGIN

    SELECT MaSP, TenSP, Gia, TinhTrang, SoLuong

    FROM SAN_PHAM;

END;

--================================================================================

--Procedure Name: XoaCongViec
--Definition:
--================================================================================

--Procedure Name: XoaCongViec

--Definition:

CREATE PROCEDURE XoaCongViec

    @MaCV INT

AS

BEGIN

    -- Kiểm tra xem công việc có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM CONG_VIEC WHERE MaCV = @MaCV)

    BEGIN

        RAISERROR('Không tìm thấy công việc với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa công việc nếu tồn tại

    DELETE FROM CONG_VIEC WHERE MaCV = @MaCV;

    PRINT 'Xóa công việc thành công.';

END

--================================================================================

--Procedure Name: XoaNhaSanXuat
--Definition:
--================================================================================

--Procedure Name: XoaNhaSanXuat

--Definition:

CREATE PROCEDURE XoaNhaSanXuat

    @MaNSX INT

AS

BEGIN

    -- Kiểm tra xem nhà sản xuất có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM NHA_SAN_XUAT WHERE MaNSX = @MaNSX)

    BEGIN

        RAISERROR('Không tìm thấy nhà sản xuất với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa nhà sản xuất nếu tồn tại

    DELETE FROM NHA_SAN_XUAT WHERE MaNSX = @MaNSX;

    PRINT 'Xóa nhà sản xuất thành công.';

END;

--================================================================================

--Procedure Name: XoaSanPham
--Definition:
--================================================================================

--Procedure Name: XoaSanPham

--Definition:

CREATE PROCEDURE XoaSanPham

    @MaSP INT

AS

BEGIN

    -- Kiểm tra xem sản phẩm có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM SAN_PHAM WHERE MaSP = @MaSP)

    BEGIN

        RAISERROR('Không tìm thấy sản phẩm với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa sản phẩm nếu tồn tại

    DELETE FROM SAN_PHAM WHERE MaSP = @MaSP;

    PRINT 'Xóa sản phẩm thành công.';

END;

--================================================================================

--Procedure Name: XoaDonNhapHang

--Definition:

--================================================================================

--Procedure Name: XoaDo

--================================================================================

--Procedure Name: sp_GetLichSuMuaHang
--Definition:
--================================================================================

--Procedure Name: sp_GetLichSuMuaHang

--Definition:

---procedure xem lịch sử mua hàng

CREATE PROCEDURE sp_GetLichSuMuaHang

    @maKH INT

AS

BEGIN

    SET NOCOUNT ON;

    SELECT MaDH, NgayDatHang, TrangThaiDonHang, TriGia

    FROM DON_HANG

    WHERE MaKH = @maKH;

END

--================================================================================

--Procedure Name: XoaDonNhapHang
--Definition:
--================================================================================

--Procedure Name: XoaDonNhapHang

--Definition:

CREATE PROCEDURE XoaDonNhapHang

    @MaDon INT

AS

BEGIN

    -- Kiểm tra xem đơn nhập hàng có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM DON_NHAP_HANG WHERE MaDon = @MaDon)

    BEGIN

        RAISERROR('Không tìm thấy đơn nhập hàng với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa đơn nhập hàng

    DELETE FROM DON_NHAP_HANG

    WHERE MaDon = @MaDon;

    PRINT 'Xóa đơn nhập hàng thành công.';

END;

--================================================================================

--Procedure Name: sp_LayChiTietDonHang
--Definition:
--================================================================================

--Procedure Name: sp_LayChiTietDonHang

--Definition:

---procedure lấy chi tiết đơn hàng

CREATE PROCEDURE sp_LayChiTietDonHang

    @MaDH INT

AS

BEGIN

    SET NOCOUNT ON;

    SELECT sp.MaSP, sp.TenSP, spd.SoLuong, spd.DonGia

    FROM SAN_PHAM_DUOC_CHON spd

    JOIN SAN_PHAM sp ON sp.MaSP = spd.MaSP

    WHERE spd.MaDH = @MaDH;

END

--================================================================================

--Procedure Name: XoaCaLamViec
--Definition:
--================================================================================

--Procedure Name: XoaCaLamViec

--Definition:

CREATE PROCEDURE XoaCaLamViec

    @MaCa INT

AS

BEGIN

    -- Kiểm tra xem ca làm việc có tồn tại không

    IF NOT EXISTS (SELECT 1 FROM CA_LAM_VIEC WHERE MaCa = @MaCa)

    BEGIN

        RAISERROR('Không tìm thấy ca làm việc với mã đã cung cấp.', 16, 1);

        RETURN;

    END

    -- Xóa ca làm việc nếu tồn tại

    DELETE FROM CA_LAM_VIEC WHERE MaCa = @MaCa;

    PRINT 'Xóa ca làm việc thành công.';

END;

--================================================================================

--Procedure Name: sp_LoadThanhToan
--Definition:
--================================================================================

--Procedure Name: sp_LoadThanhToan

--Definition:

---Xem thanh toán

CREATE PROCEDURE sp_LoadThanhToan

    @MaKH INT

AS

BEGIN

    SET NOCOUNT ON;

    SELECT 

        THANH_TOAN.MaDH,

        THANH_TOAN.DaThanhToan,

        DON_HANG.TriGia

    FROM 

        THANH_TOAN 

    JOIN 

        DON_HANG ON THANH_TOAN.MaDH = DON_HANG.MaDH

    WHERE 

        THANH_TOAN.MaKH = @MaKH;

END

--================================================================================

--Procedure Name: UpdateCaLamViec
--Definition:
--================================================================================

--Procedure Name: UpdateCaLamViec

--Definition:

CREATE PROCEDURE UpdateCaLamViec

    @maCa INT,

    @starttime DATETIME,

    @endtime DATETIME

AS

BEGIN

    UPDATE CA_LAM_VIEC

    SET ThoiGianBatDau = @starttime, ThoiGianKetThuc = @endtime

    WHERE MaCa = @maCa;

END;

--================================================================================

--Procedure Name: GetDonHang
--Definition:
--================================================================================

--Procedure Name: GetDonHang

--Definition:

CREATE PROCEDURE GetDonHang

AS

BEGIN

    SELECT * FROM DON_HANG

END

--================================================================================

--Procedure Name: InsertCaLamViec
--Definition:
--================================================================================

--Procedure Name: InsertCaLamViec

--Definition:

CREATE PROCEDURE InsertCaLamViec

    @starttime DATETIME,

    @endtime DATETIME,

    @maNV INT

AS

BEGIN

    INSERT INTO CA_LAM_VIEC (ThoiGianBatDau, ThoiGianKetThuc, MaNV)

    VALUES (@starttime, @endtime, @maNV);

END;

--================================================================================

--Procedure Name: UpdateTrangThaiDonHang
--Definition:
--================================================================================

--Procedure Name: UpdateTrangThaiDonHang

--Definition:

-- Stored Procedure để cập nhật trạng thái đơn hàng

CREATE PROCEDURE UpdateTrangThaiDonHang

    @MaDH INT,

    @TrangThaiDonHang NVARCHAR(50)

AS

BEGIN

    UPDATE DON_HANG 

    SET TrangThaiDonHang = @TrangThaiDonHang 

    WHERE MaDH = @MaDH

END

--================================================================================

--Procedure Name: sp_TaoDonHang
--Definition:
CREATE PROCEDURE sp_TaoDonHang

    @MaKH INT,

    @MaUngDung INT,

    @TrangThai NVARCHAR(50),

    @TriGia INT,

    @SanPhamDonHang SanPhamDonHangType READONLY

AS

BEGIN

    SET NOCOUNT ON;

    DECLARE @MaDH INT;

    DECLARE @NgayDatHang DATETIME = GETDATE();

    -- Bắt đầu giao dịch

    BEGIN TRANSACTION;

    BEGIN TRY

        -- 1. Tạo đơn hàng mới

        INSERT INTO DON_HANG (NgayDatHang, TrangThaiDonHang, TriGia, MaUngDung, MaKH)

        VALUES (@NgayDatHang, @TrangThai, @TriGia, @MaUngDung, @MaKH);

        -- Lấy mã đơn hàng mới nhất vừa tạo

        SET @MaDH = SCOPE_IDENTITY();

        -- 2. Thêm sản phẩm vào SAN_PHAM_DUOC_CHON và cập nhật số lượng trong SAN_PHAM

        DECLARE @MaSP INT, @SoLuong INT, @Gia INT, @ThanhTien INT;

        DECLARE cur CURSOR FOR 

            SELECT MaSP, SoLuong FROM @SanPhamDonHang;

        OPEN cur;

        FETCH NEXT FROM cur INTO @MaSP, @SoLuong;

        WHILE @@FETCH_STATUS = 0

        BEGIN

            -- Lấy giá của sản phẩm từ bảng SAN_PHAM

            SELECT @Gia = Gia FROM SAN_PHAM WHERE MaSP = @MaSP;

            -- Tính thành tiền cho số lượng đã mua

            SET @ThanhTien = @Gia * @SoLuong;

            -- Thêm sản phẩm vào SAN_PHAM_DUOC_CHON với DonGia là thành tiền

            INSERT INTO SAN_PHAM_DUOC_CHON (MaSP, MaDH, SoLuong, DonGia)

            VALUES (@MaSP, @MaDH, @SoLuong, @ThanhTien);

            -- Cập nhật số lượng tồn kho trong SAN_PHAM

            UPDATE SAN_PHAM

            SET SoLuong = SoLuong - @SoLuong

            WHERE MaSP = @MaSP;

            FETCH NEXT FROM cur INTO @MaSP, @SoLuong;

        END

        CLOSE cur;

        DEALLOCATE cur;

        -- 3. Cập nhật bảng THANH_TOAN với MaDH và MaKH, mặc định DaThanhToan là 0

        INSERT INTO THANH_TOAN (MaDH, MaKH, DaThanhToan)

        VALUES (@MaDH, @MaKH, 0);

        -- Xác nhận giao dịch

        COMMIT TRANSACTION;

        PRINT 'Đơn hàng đã được tạo thành công!';

    END TRY

    BEGIN CATCH

        -- Nếu có lỗi, rollback giao dịch

        ROLLBACK TRANSACTION;

        THROW;

    END CATCH

END

--================================================================================

--Procedure Name: UpdateNhanVien
--Definition:
--Procedure Name: UpdateNhanVien

--Definition:

CREATE PROCEDURE UpdateNhanVien

    @MaNV INT,

    @HoTen NVARCHAR(100),

    @NgaySinh DATE,

    @GioiTinh NVARCHAR(10),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100),

    @DiaChi NVARCHAR(200),

    @MaCV INT

AS

BEGIN

    UPDATE NHAN_VIEN

    SET 

        HoTen = @HoTen,

        NgaySinh = @NgaySinh,

        GioiTinh = @GioiTinh,

        SDT = @SDT,

        Email = @Email,

        DiaChi = @DiaChi,

        MaCV = @MaCV

    WHERE 

        MaNV = @MaNV;

END;

--================================================================================

--Procedure Name: GetChiTietSanPhamDonHang
--Definition:
--================================================================================

--Procedure Name: GetChiTietSanPhamDonHang

--Definition:

-- Stored Procedure để lấy chi tiết sản phẩm của một đơn hàng

CREATE PROCEDURE GetChiTietSanPhamDonHang

    @MaDH INT

AS

BEGIN

    SELECT * FROM CHI_TIET_SAN_PHAM_DON_HANG 

    WHERE MaDH = @MaDH

END

--================================================================================

--Procedure Name: InsertNhanVien
--Definition:
--================================================================================

--Procedure Name: InsertNhanVien

--Definition:

CREATE PROCEDURE InsertNhanVien

    @HoTen NVARCHAR(100),

    @NgaySinh DATE,

    @GioiTinh NVARCHAR(10),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100),

    @DiaChi NVARCHAR(200),

    @MaCV INT

AS

BEGIN

    INSERT INTO NHAN_VIEN (HoTen, NgaySinh, GioiTinh, SDT, Email, DiaChi, MaCV) 

    VALUES (@HoTen, @NgaySinh, @GioiTinh, @SDT, @Email, @DiaChi, @MaCV);

END;

--================================================================================

--Procedure Name: GetKhachHangInfo
--Definition:
--================================================================================

--Procedure Name: GetKhachHangInfo

--Definition:

CREATE PROCEDURE GetKhachHangInfo
    @SDT VARCHAR(15) -- Khai báo biến đầu vào là SDT
AS
BEGIN
    -- Truy vấn lấy thông tin khách hàng theo số điện thoại
    SELECT MaKH, HoTen, SDT, DiaChi
    FROM KHACH_HANG
    WHERE SDT = @SDT;
END
GO

--================================================================================

--Procedure Name: UpdateDonNhapHang
--Definition:
--================================================================================

--Procedure Name: UpdateDonNhapHang

--Definition:

CREATE PROCEDURE UpdateDonNhapHang

    @MaDon INT,

    @NgayNhap DATETIME,

    @SoLuong INT,

    @MaSP INT,

    @MaNSX INT

AS

BEGIN

    UPDATE DON_NHAP_HANG

    SET NgayNhap = @NgayNhap,

        SoLuong = @SoLuong,

        MaSP = @MaSP,

        MaNSX = @MaNSX

    WHERE MaDon = @MaDon;

END;

--================================================================================

--Procedure Name: DeleteKhachHang
--Definition:
--================================================================================

--Procedure Name: DeleteKhachHang

--Definition:

--Stored Procedure xóa thông tin Khách hàng

CREATE PROCEDURE DeleteKhachHang

    @MaKH INT -- Khai báo biến đầu vào

AS

BEGIN

    -- Lệnh xóa khách hàng

    DELETE FROM KHACH_HANG WHERE maKH = @MaKH;

END

--================================================================================

--Procedure Name: sp_TimKiemSanPham
--Definition:
CREATE PROCEDURE sp_TimKiemSanPham
    @TenSP NVARCHAR(100) = NULL,
    @TinhTrang NVARCHAR(50) = NULL,
    @GiaTu INT = NULL,
    @GiaDen INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT MaSP,TenSP, Gia, TinhTrang, SoLuong
    FROM SAN_PHAM
    WHERE (@TenSP IS NULL OR TenSP LIKE '%' + @TenSP + '%')
      AND (@TinhTrang IS NULL OR TinhTrang = @TinhTrang)
      AND (@GiaTu IS NULL OR Gia >= @GiaTu)
      AND (@GiaDen IS NULL OR Gia <= @GiaDen);
END;

--================================================================================

--Procedure Name: InsertDonNhapHang
--Definition:
--================================================================================

--Procedure Name: InsertDonNhapHang

--Definition:

CREATE PROCEDURE InsertDonNhapHang

    @NgayNhap DATETIME,

    @GiaTri INT,

    @SoLuong INT,

    @DonGia INT,

    @MaSP INT,

    @MaNSX INT

AS

BEGIN

    INSERT INTO DON_NHAP_HANG (NgayNhap, GiaTri, SoLuong, DonGia, MaSP, MaNSX)

    VALUES (@NgayNhap, @GiaTri, @SoLuong, @DonGia, @MaSP, @MaNSX);

END;

--================================================================================

--Procedure Name: GetLichLamData
--Definition:
--================================================================================

--Procedure Name: GetLichLamData

--Definition:

--Stored Procedure lấy thông tin các làm việc

CREATE PROCEDURE GetLichLamData

AS

BEGIN

    SET NOCOUNT ON;

    SELECT * FROM CA_LAM_VIEC;

END

--================================================================================

--Procedure Name: UpdateSanPham
--Definition:
--================================================================================

--Procedure Name: UpdateSanPham

--Definition:

CREATE PROCEDURE UpdateSanPham

    @MaSP INT,

    @TenSP NVARCHAR(100),

    @Gia INT,

    @SoLuong INT,

    @TinhTrang NVARCHAR(50)

AS

BEGIN

    UPDATE SAN_PHAM

    SET 

        TenSP = @TenSP,

        Gia = @Gia,

        SoLuong = @SoLuong,

        TinhTrang = @TinhTrang

    WHERE 

        MaSP = @MaSP;

END;

--================================================================================

--Procedure Name: GetKhachHangContactInfo
--Definition:
--================================================================================

--Procedure Name: GetKhachHangContactInfo

--Definition:

CREATE PROCEDURE GetKhachHangContactInfo

    @MaKH INT

AS

BEGIN

    SET NOCOUNT ON;

    SELECT SDT, Email

    FROM KhachHang

    WHERE MaKH = @MaKH;

END

--================================================================================

--Procedure Name: UpdateNhaSanXuat
--Definition:
--================================================================================

--Procedure Name: UpdateNhaSanXuat

--Definition:

CREATE PROCEDURE UpdateNhaSanXuat

    @MaNSX INT,

    @TenNSX NVARCHAR(100),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100)

AS

BEGIN

    -- Cập nhật thông tin nhà sản xuất

    UPDATE NHA_SAN_XUAT

    SET 

        TenNSX = @TenNSX,

        SDT = @SDT,

        Email = @Email

    WHERE 

        MaNSX = @MaNSX;

END;

--================================================================================

--Procedure Name: InsertNhaSanXuat
--Definition:
--================================================================================

--Procedure Name: InsertNhaSanXuat

--Definition:

CREATE PROCEDURE InsertNhaSanXuat

    @TenNSX NVARCHAR(100),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100)

AS

BEGIN

    -- Chèn nhà sản xuất mới vào bảng NHA_SAN_XUAT

    INSERT INTO NHA_SAN_XUAT (TenNSX, SDT, Email)

    VALUES (@TenNSX, @SDT, @Email);

END;

--================================================================================

--Procedure Name: sp_LayDonHangTheoTrangThaiThanhToan
--Definition:
--================================================================================

--Procedure Name: sp_LayDonHangTheoTrangThaiThanhToan

--Definition:

CREATE PROCEDURE sp_LayDonHangTheoTrangThaiThanhToan

    @DaThanhToan BIT

AS

BEGIN

    SELECT DH.MaDH, DH.NgayDatHang, DH.TrangThaiDonHang, DH.TriGia, 

           CASE WHEN TT.DaThanhToan = 1 THEN N'?ã thanh toán' ELSE N'Ch?a thanh toán' END AS TrangThaiThanhToan

    FROM DON_HANG DH

    LEFT JOIN THANH_TOAN TT ON DH.MaDH = TT.MaDH

    WHERE TT.DaThanhToan = @DaThanhToan OR TT.DaThanhToan IS NULL;

END

--================================================================================

--Procedure Name: UpdateCongViec
--Definition:
--================================================================================

--Procedure Name: UpdateCongViec

--Definition:

CREATE PROCEDURE UpdateCongViec

    @MaCV INT,

    @TenCV NVARCHAR(100),

    @Luong INT

AS

BEGIN

    -- Chỉnh sửa thông tin công việc

    UPDATE CONG_VIEC

    SET 

        TenCV = @TenCV,

        Luong = @Luong

    WHERE 

        MaCV = @MaCV;

END;

--================================================================================

--Procedure Name: UpdateChietKhau
--Definition:
--================================================================================

--Procedure Name: UpdateChietKhau

--Definition:

CREATE PROCEDURE UpdateChietKhau

    @MaUngDung INT,

    @ChietKhau DECIMAL(5, 2)

AS

BEGIN

    UPDATE UNG_DUNG

    SET ChietKhau = @ChietKhau

    WHERE MaUngDung = @MaUngDung;

END;

--================================================================================

--Procedure Name: InsertCongViec
--Definition:
--================================================================================

--Procedure Name: InsertCongViec

--Definition:

CREATE PROCEDURE InsertCongViec

    @TenCV NVARCHAR(100),

    @Luong INT

AS

BEGIN

    -- Chèn công việc mới vào bảng CONG_VIEC

    INSERT INTO CONG_VIEC (TenCV, Luong)

    VALUES (@TenCV, @Luong);

END;

--================================================================================

--Procedure Name: UpdateKhachHang
--Definition:
--================================================================================

--Procedure Name: UpdateKhachHang

--Definition:

CREATE PROCEDURE UpdateKhachHang

    @MaKH INT,

    @HoTen NVARCHAR(100),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100),

    @DiaChi NVARCHAR(200)

AS

BEGIN

    UPDATE KHACH_HANG

    SET 

        HoTen = @HoTen,

        SDT = @SDT,

        Email = @Email,

        DiaChi = @DiaChi

    WHERE 

        MaKH = @MaKH;

END;

--================================================================================

--Procedure Name: InsertKhachHang
--Definition:
--================================================================================

--Procedure Name: InsertKhachHang

--Definition:

CREATE PROCEDURE InsertKhachHang

    @HoTen NVARCHAR(100),

    @DiaChi NVARCHAR(200),

    @SDT NVARCHAR(15),

    @Email NVARCHAR(100)

AS

BEGIN

    INSERT INTO KHACH_HANG (HoTen, DiaChi, SDT, Email)

    VALUES (@HoTen, @DiaChi, @SDT, @Email);

END;

--================================================================================

--Procedure Name: UpdateUngDung
--Definition:
--================================================================================

--Procedure Name: UpdateUngDung

--Definition:

CREATE PROCEDURE UpdateUngDung

    @MaUngDung INT,

    @TenUngDung NVARCHAR(100),

    @ChietKhau INT

AS

BEGIN

    UPDATE UNG_DUNG

    SET TenUngDung = @TenUngDung,

        ChietKhau = @ChietKhau

    WHERE MaUngDung = @MaUngDung;

END;

--================================================================================

--Procedure Name: InsertUngDung
--Definition:
--================================================================================

--Procedure Name: InsertUngDung

--Definition:

CREATE PROCEDURE InsertUngDung

    @TenUngDung NVARCHAR(100),

    @ChietKhau INT

AS

BEGIN

    INSERT INTO UNG_DUNG (TenUngDung, ChietKhau)

    VALUES (@TenUngDung, @ChietKhau);

END;

--================================================================================

--Procedure Name: CapNhatSoLuongSanPham
--Definition:
--================================================================================

--Procedure Name: CapNhatSoLuongSanPham

--Definition:

CREATE PROCEDURE CapNhatSoLuongSanPham

    @MaSPDonHang INT, -- ID của sản phẩm trong đơn hàng

    @SoLuong INT      -- Số lượng mới cần cập nhật

AS

BEGIN

    UPDATE SAN_PHAM_DUOC_CHON

    SET 

        SoLuong = @SoLuong

    WHERE 

        MaSPDonHang = @MaSPDonHang;

END;

--================================================================================

--Procedure Name: sp_GetWorkShiftByMaCa
--Definition:
--================================================================================

--Procedure Name: sp_GetWorkShiftByMaCa

--Definition:

CREATE PROCEDURE sp_GetWorkShiftByMaCa

    @maCa INT

AS

BEGIN

    SELECT * 

    FROM CA_LAM_VIEC 

    WHERE MaCa = @maCa

END

--================================================================================

--Procedure Name: sp_SearchManufacturerByName
--Definition:
--================================================================================

--Procedure Name: sp_SearchManufacturerByName

--Definition:

CREATE PROCEDURE sp_SearchManufacturerByName

    @TenNSX NVARCHAR(100)

AS

BEGIN

    SELECT 

        MaNSX, 

        TenNSX, 

        SDT, 

        Email

    FROM 

        NHA_SAN_XUAT

    WHERE 

        TenNSX LIKE '%' + @TenNSX + '%';

END;

--================================================================================

--Procedure Name: sp_SearchProductByName
--Definition:
--================================================================================

--Procedure Name: sp_SearchProductByTenSP

--Definition:

CREATE PROCEDURE sp_SearchProductByName

    @TenSP NVARCHAR(100)

AS

BEGIN

    SELECT 

        MaSP, 

        TenSP, 

        Gia, 

        SoLuong, 

        TinhTrang

    FROM 

        SAN_PHAM

    WHERE 

        TenSP LIKE '%' + @TenSP + '%';

END;

--================================================================================

--Procedure Name: SearchKhachHangByName
--Definition:
--================================================================================

--Procedure Name: SearchKhachHangByTenKH

--Definition:

CREATE PROCEDURE SearchKhachHangByName

    @HoTen NVARCHAR(100)

AS

BEGIN

    SELECT 

        MaKH, 

        HoTen, 

        DiaChi, 

        SDT, 

        Email

    FROM 

        KHACH_HANG

    WHERE 

        HoTen LIKE '%' + @HoTen + '%';

END;

--================================================================================

--Procedure Name: sp_SearchEmployeeByTenNV
--Definition:
--================================================================================

--Procedure Name: sp_SearchEmployeeByTenNV

--Definition:

CREATE PROCEDURE sp_SearchEmployeeByTenNV

    @HoTen NVARCHAR(100)

AS

BEGIN

    SELECT 

        MaNV, 

        HoTen, 

        NgaySinh, 

        GioiTinh, 

        SDT, 

        Email, 

        DiaChi, 

        MaCV

    FROM 

        NHAN_VIEN

    WHERE 

        HoTen LIKE '%' + @HoTen + '%';

END;

--================================================================================

--Procedure Name: GetPurchaseOrders
--Definition:
--================================================================================

--Procedure Name: GetPurchaseOrders

--Definition:

CREATE PROCEDURE GetPurchaseOrders

AS

BEGIN

    SELECT 

        DN.MaDon,

        DN.NgayNhap,

        DN.GiaTri,

        DN.SoLuong,

        DN.DonGia,

        SP.TenSP,

        NSX.TenNSX

    FROM 

        DON_NHAP_HANG DN

    JOIN 

        SAN_PHAM SP ON DN.MaSP = SP.MaSP

    LEFT JOIN 

        NHA_SAN_XUAT NSX ON DN.MaNSX = NSX.MaNSX;

END;

--================================================================================

--Procedure Name: sp_GetAllProducts
--Definition:
--================================================================================

--Procedure Name: sp_GetAllProducts

--Definition:

CREATE PROCEDURE sp_GetAllProducts

AS

BEGIN

    SELECT * FROM SAN_PHAM;

END;

--================================================================================

--Procedure Name: GetAllKhachHang
--Definition:
--================================================================================

--Procedure Name: GetAllKhachHang

--Definition:

CREATE PROCEDURE GetAllKhachHang

AS

BEGIN

    SELECT * FROM KHACH_HANG;

END;

--================================================================================

--Procedure Name: sp_upgraddiagrams
--Definition:
--================================================================================

--Procedure Name: sp_upgraddiagrams

--Definition:

	CREATE PROCEDURE dbo.sp_upgraddiagrams

	AS

	BEGIN

		IF OBJECT_ID(N'dbo.sysdiagrams') IS NOT NULL

			return 0;

		CREATE TABLE dbo.sysdiagrams

		(

			name sysname NOT NULL,

			principal_id int NOT NULL,	-- we may change it to varbinary(85)

			diagram_id int PRIMARY KEY IDENTITY,

			version int,

			definition varbinary(max)

			CONSTRAINT UK_principal_name UNIQUE

			(

				principal_id,

				name

			)

		);

		/* Add this if we need to have some form of extended properties for diagrams */

		/*

		IF OBJECT_ID(N'dbo.sysdiagram_properties') IS NULL

		BEGIN

			CREATE TABLE dbo.sysdiagram_properties

			(

				diagram_id int,

				name sysname,

				value varbinary(max) NOT NULL

			)

		END

		*/

		IF OBJECT_ID(N'dbo.dtproperties') IS NOT NULL

		begin

			insert into dbo.sysdiagrams

			(

				[name],

				[principal_id],

				[version],

				[definition]

			)

			select	 

				convert(sysname, dgnm.[uvalue]),

				DATABASE_PRINCIPAL_ID(N'dbo'),			-- will change to the sid of sa

				0,							-- zero for old format, dgdef.[version],

				dgdef.[lvalue]

			from dbo.[dtproperties] dgnm

				inner join dbo.[dtproperties] dggd on dggd.[property] = 'DtgSchemaGUID' and dggd.[objectid] = dgnm.[objectid]	

				inner join dbo.[dtproperties] dgdef on dgdef.[property] = 'DtgSchemaDATA' and dgdef.[objectid] = dgnm.[objectid]

			where dgnm.[property] = 'DtgSchemaNAME' and dggd.[uvalue] like N'_EA3E6268-D998-11CE-9454-00AA00A3F36E_' 

			return 2;

		end

		return 1;

	END

--================================================================================

--Procedure Name: InsertSanPham
--Definition:
--================================================================================

--Procedure Name: InsertSanPham

--Definition:

CREATE PROCEDURE InsertSanPham

    @TenSP NVARCHAR(100),

    @Gia INT,

    @TinhTrang NVARCHAR(50)

AS

BEGIN

    SET NOCOUNT ON; -- Giúp tránh thông báo số dòng bị ảnh hưởng

    -- Chèn sản phẩm mới vào bảng SAN_PHAM với SoLuong mặc định là 0

    INSERT INTO SAN_PHAM (TenSP, Gia, SoLuong, TinhTrang)

    VALUES (@TenSP, @Gia, 0, @TinhTrang);

END;

--================================================================================

--Procedure Name: GetSanPhamDuocChonByMaDH
--Definition:
--================================================================================

--Procedure Name: GetSanPhamDuocChonByMaDH

--Definition:

CREATE PROCEDURE GetSanPhamDuocChonByMaDH

    @MaDH INT

AS

BEGIN

    SET NOCOUNT ON;

    SELECT 

        SPD.MaSPDonHang,

        SPD.MaSP, 

        CASE 

            WHEN SPD.MaSP IS NULL THEN 'Sản phẩm đã bị xóa' 

            ELSE SP.TenSP 

        END AS TenSP, 

        (COALESCE(SP.Gia, 0) * SPD.SoLuong) AS Gia, 

        SPD.SoLuong

    FROM 

        SAN_PHAM_DUOC_CHON SPD

    LEFT JOIN 

        SAN_PHAM SP ON SPD.MaSP = SP.MaSP

    WHERE 

        SPD.MaDH = @MaDH;

END;

--================================================================================

--Procedure Name: TaoDonHang
--Definition:
--================================================================================

--Procedure Name: TaoDonHang

--Definition:

CREATE PROCEDURE TaoDonHang

    @NgayDatHang DATETIME,

    @TrangThaiDonHang NVARCHAR(50),

    @TriGia INT,

    @MaUngDung INT,

    @MaKH INT,

    @MaDH INT OUTPUT -- Tham số OUTPUT để trả về MaDH

AS

BEGIN

    SET NOCOUNT ON;

    -- Thêm đơn hàng mới vào bảng DON_HANG

    INSERT INTO DON_HANG (NgayDatHang, TrangThaiDonHang, TriGia, MaUngDung, MaKH)

    VALUES (@NgayDatHang, @TrangThaiDonHang, @TriGia, @MaUngDung, @MaKH);

    -- Lấy MaDH của đơn hàng vừa được tạo (sử dụng SCOPE_IDENTITY)

    SET @MaDH = SCOPE_IDENTITY();

END;

--================================================================================

--Procedure Name: sp_GetAllApplications
--Definition:
--================================================================================

--Procedure Name: sp_GetAllApplications

--Definition:

CREATE PROCEDURE sp_GetAllApplications

AS

BEGIN

    -- Lấy tất cả các ứng dụng từ bảng UNG_DUNG

    SELECT * 

    FROM UNG_DUNG;

END

--================================================================================

--Procedure Name: sp_helpdiagrams
--Definition:
--================================================================================

--Procedure Name: sp_helpdiagrams

--Definition:

	CREATE PROCEDURE dbo.sp_helpdiagrams

	(

		@diagramname sysname = NULL,

		@owner_id int = NULL

	)

	WITH EXECUTE AS N'dbo'

	AS

	BEGIN

		DECLARE @user sysname

		DECLARE @dboLogin bit

		EXECUTE AS CALLER;

			SET @user = USER_NAME();

			SET @dboLogin = CONVERT(bit,IS_MEMBER('db_owner'));

		REVERT;

		SELECT

			[Database] = DB_NAME(),

			[Name] = name,

			[ID] = diagram_id,

			[Owner] = USER_NAME(principal_id),

			[OwnerID] = principal_id

		FROM

			sysdiagrams

		WHERE

			(@dboLogin = 1 OR USER_NAME(principal_id) = @user) AND

			(@diagramname IS NULL OR name = @diagramname) AND

			(@owner_id IS NULL OR principal_id = @owner_id)

		ORDER BY

			4, 5, 1

	END

--================================================================================

--Procedure Name: sp_SearchApplicationByName
--Definition:
--================================================================================

--Procedure Name: sp_SearchApplicationByName

--Definition:

CREATE PROCEDURE sp_SearchApplicationByName

    @TenUD NVARCHAR(255)

AS

BEGIN

    -- Tìm kiếm ứng dụng theo tên

    SELECT * 

    FROM UNG_DUNG

    WHERE TenUngDung LIKE '%' + @TenUD + '%';

END

--================================================================================

--Procedure Name: sp_helpdiagramdefinition
--Definition:
--================================================================================

--Procedure Name: sp_helpdiagramdefinition

--Definition:

	CREATE PROCEDURE dbo.sp_helpdiagramdefinition

	(

		@diagramname 	sysname,

		@owner_id	int	= null 		

	)

	WITH EXECUTE AS N'dbo'

	AS

	BEGIN

		set nocount on

		declare @theId 		int

		declare @IsDbo 		int

		declare @DiagId		int

		declare @UIDFound	int

		if(@diagramname is null)

		begin

			RAISERROR (N'E_INVALIDARG', 16, 1);

			return -1

		end

		execute as caller;

		select @theId = DATABASE_PRINCIPAL_ID();

		select @IsDbo = IS_MEMBER(N'db_owner');

		if(@owner_id is null)

			select @owner_id = @theId;

		revert; 

		select @DiagId = diagram_id, @UIDFound = principal_id from dbo.sysdiagrams where principal_id = @owner_id and name = @diagramname;

		if(@DiagId IS NULL or (@IsDbo = 0 and @UIDFound <> @theId ))

		begin

			RAISERROR ('Diagram does not exist or you do not have permission.', 16, 1);

			return -3

		end

		select version, definition FROM dbo.sysdiagrams where diagram_id = @DiagId ; 

		return 0

	END

--================================================================================

--Procedure Name: sp_GetAllManufacturers
--Definition:
--================================================================================

--Procedure Name: sp_GetAllManufacturers

--Definition:

CREATE PROCEDURE sp_GetAllManufacturers

AS

BEGIN

    -- Lấy tất cả các nhà sản xuất từ bảng NHA_SAN_XUAT

    SELECT * 

    FROM NHA_SAN_XUAT;

END

--================================================================================

--Procedure Name: sp_creatediagram
--Definition:
--================================================================================

--Procedure Name: sp_creatediagram

--Definition:

	CREATE PROCEDURE dbo.sp_creatediagram

	(

		@diagramname 	sysname,

		@owner_id		int	= null, 	

		@version 		int,

		@definition 	varbinary(max)

	)

	WITH EXECUTE AS 'dbo'

	AS

	BEGIN

		set nocount on

		declare @theId int

		declare @retval int

		declare @IsDbo	int

		declare @userName sysname

		if(@version is null or @diagramname is null)

		begin

			RAISERROR (N'E_INVALIDARG', 16, 1);

			return -1

		end

		execute as caller;

		select @theId = DATABASE_PRINCIPAL_ID(); 

		select @IsDbo = IS_MEMBER(N'db_owner');

		revert; 

		if @owner_id is null

		begin

			select @owner_id = @theId;

		end

		else

		begin

			if @theId <> @owner_id

			begin

				if @IsDbo = 0

				begin

					RAISERROR (N'E_INVALIDARG', 16, 1);

					return -1

				end

				select @theId = @owner_id

			end

		end

		-- next 2 line only for test, will be removed after define name unique

		if EXISTS(select diagram_id from dbo.sysdiagrams where principal_id = @theId and name = @diagramname)

		begin

			RAISERROR ('The name is already used.', 16, 1);

			return -2

		end

		insert into dbo.sysdiagrams(name, principal_id , version, definition)

				VALUES(@diagramname, @theId, @version, @definition) ;

		select @retval = @@IDENTITY 

		return @retval

	END

--================================================================================

