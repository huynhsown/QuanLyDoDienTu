-- 9 View

--View Name: vw_DonHangChiTiet
--Definition:
CREATE VIEW vw_DonHangChiTiet AS

SELECT 

    DH.MaDH,

    DH.NgayDatHang,

    DH.TrangThaiDonHang,

    DH.TriGia,

    DH.MaUngDung,

    DH.MaKH,

    TT.DaThanhToan,

    CTSP.MaSPDonHang,

    CTSP.MaSP,

    CTSP.SoLuong,

    CTSP.DonGia

FROM 

    DON_HANG DH

JOIN 

    SAN_PHAM_DUOC_CHON CTSP ON DH.MaDH = CTSP.MaDH

LEFT JOIN 

    THANH_TOAN TT ON DH.MaDH = TT.MaDH;

--================================================================================

--View Name: vw_LienHe
--Definition:

CREATE VIEW vw_LienHe AS

SELECT 

    MaKH AS MaLienHe,

    HoTen AS TenLienHe,

    DiaChi,

    SDT,

    Email,

    'KhachHang' AS LoaiLienHe

FROM 

    KHACH_HANG

UNION ALL

SELECT 

    MaNSX AS MaLienHe,

    TenNSX AS TenLienHe,

    NULL AS DiaChi,

    SDT,

    Email,

    'NhaSanXuat' AS LoaiLienHe

FROM 

    NHA_SAN_XUAT;

--================================================================================

--View Name: vw_SanPhamNhapHang
--Definition:
CREATE VIEW vw_SanPhamNhapHang AS

SELECT 

    SP.MaSP,

    SP.TenSP,

    SP.Gia,

    SP.SoLuong AS SoLuongTonKho,

    SP.TinhTrang,

    DN.MaDon,

    DN.NgayNhap,

    DN.GiaTri,

    DN.SoLuong AS SoLuongNhap,

    DN.DonGia,

    DN.MaNSX

FROM 

    SAN_PHAM SP

LEFT JOIN 

    DON_NHAP_HANG DN ON SP.MaSP = DN.MaSP;

--================================================================================

--View Name: vw_NhanVienChiTiet
--Definition:

CREATE VIEW vw_NhanVienChiTiet AS

SELECT 

    NV.MaNV,

    NV.HoTen,

    NV.NgaySinh,

    NV.GioiTinh,

    NV.SDT,

    NV.Email,

    NV.DiaChi,

    CV.MaCV,

    CV.TenCV,

    CV.Luong,

    CLV.MaCa,

    CLV.ThoiGianBatDau,

    CLV.ThoiGianKetThuc

FROM 

    NHAN_VIEN NV

JOIN 

    CONG_VIEC CV ON NV.MaCV = CV.MaCV

LEFT JOIN 

    CA_LAM_VIEC CLV ON NV.MaNV = CLV.MaNV;

--================================================================================

--View Name: vw_UngDungChietKhau
--Definition:
CREATE VIEW vw_UngDungChietKhau AS

SELECT 

    MaUngDung,

    TenUngDung,

    ChietKhau

FROM 

    UNG_DUNG;

--================================================================================

--View Name: vw_DonHangByKhachHang
--Definition:
--================================================================================

--View Name: vw_DonHangByKhachHang

--Definition:

CREATE VIEW vw_DonHangByKhachHang

AS

SELECT 

    DH.MaDH, 

    DH.NgayDatHang, 

    DH.TrangThaiDonHang, 

    DH.TriGia, 

    U.MaUngDung,  

    U.TenUngDung,

    DH.MaKH

FROM 

    DON_HANG DH

JOIN 

    UNG_DUNG U ON DH.MaUngDung = U.MaUngDung;

--================================================================================

--View Name: vw_SanPhamDonHang
--Definition:
--================================================================================

--View Name: vw_SanPhamDonHang

--Definition:

CREATE VIEW vw_SanPhamDonHang

AS

SELECT 

    SPD.MaSPDonHang,

    SP.MaSP, 

    SP.TenSP, 

    (SP.Gia * SPD.SoLuong) AS Gia, 

    SPD.SoLuong,

    SPD.MaDH

FROM 

    SAN_PHAM_DUOC_CHON SPD

JOIN 

    SAN_PHAM SP ON SPD.MaSP = SP.MaSP;

--================================================================================

--View Name: vw_WorkShiftDetails
--Definition:
--================================================================================

--View Name: vw_WorkShiftDetails

--Definition:

CREATE VIEW vw_WorkShiftDetails

AS

SELECT CLV.MaCa, CLV.ThoiGianBatDau, CLV.ThoiGianKetThuc, 

       CV.TenCV AS TenCongViec, NV.MaNV 

FROM CA_LAM_VIEC CLV

JOIN NHAN_VIEN NV ON CLV.MaNV = NV.MaNV

JOIN CONG_VIEC CV ON NV.MaCV = CV.MaCV;

--================================================================================

--View Name: vw_StaffDetails
--Definition:
--================================================================================

--View Name: vw_StaffDetails

--Definition:

CREATE VIEW vw_StaffDetails AS

SELECT 

    NV.MaNV, 

    NV.HoTen, 

    FORMAT(NV.NgaySinh, 'dd/MM/yyyy') AS NgaySinh, 

    NV.GioiTinh, 

    NV.SDT, 

    NV.Email, 

    NV.DiaChi, 

    CV.TenCV 

FROM 

    NHAN_VIEN NV 

JOIN 

    CONG_VIEC CV ON NV.MaCV = CV.MaCV;

--================================================================================

