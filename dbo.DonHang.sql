CREATE TABLE [dbo].[DonHang] (
    [maDonHang]   INT             IDENTITY (1, 1) NOT NULL,
    [maKhachHang] INT             NULL,
    [maNhanVien]  INT             NULL,
    [ngayDat]     DATE        DEFAULT (getdate()) NULL,
    [tongTien]    DECIMAL (18, 2) NOT NULL,
    [trangThai]   NVARCHAR (50)   NOT NULL,
    PRIMARY KEY CLUSTERED ([maDonHang] ASC),
    FOREIGN KEY ([maKhachHang]) REFERENCES [dbo].[KhachHang] ([maKhachHang]),
    FOREIGN KEY ([maNhanVien]) REFERENCES [dbo].[NhanVien] ([maNhanVien])
);

