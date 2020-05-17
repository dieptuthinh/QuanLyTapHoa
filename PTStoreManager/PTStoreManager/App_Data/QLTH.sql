create database QLTapHoa
go 
use QLTapHoa
go


create table NguoiDung(
	MaND varchar(10) primary key not null,
	TaiKhoan varchar(100) not null,
	MatKhau varchar(100) not null,
	ChucVu nvarchar(100) not null,
	HoTen nvarchar(300) not null, 
	SDT varchar(20) ,
	Anh nvarchar(100) not null,
	DiaChi nvarchar(max) ,
	GioiTinh bit not null,

)


create table MauHang(
	MaMH varchar(10) primary key not null,
	TenMH nvarchar(300) not null,
	DonVi nvarchar(100) not null,
	Anh nvarchar(100) not null,
	ChuThich nvarchar(max) ,
)

create table NhomHang(
	MaNH varchar(10) primary key not null,
	TenNH nvarchar(300) not null,
)

create table MauHangNhomHang(
	MaMH VARCHAR(10) NOT NULL, 
	MaNH VARCHAR(10) NOT NULL,
	PRIMARY KEY(MaMH, MaNH)
)

CREATE TABLE NhaCungCap(
	MaNCC VARCHAR(10) PRIMARY KEY not null,
	TenNCC NVARCHAR(100) NOT NULL,
	QuoGia NVARCHAR(100) NOT NULL,
	DiaChi NVARCHAR(max) NOT NULL,
	SDT VARCHAR(20) NOT NULL,
	Email VARCHAR(20) NOT NULL,
)

create table KhachHang(
	MaKH varchar(10) primary key not null,
	HoTen nvarchar(100) not null,
	Anh nvarchar(100) not null,
	DiaChi nvarchar(max) not null,
	SDT VARCHAR(20) NOT NULL,
	Email VARCHAR(20) NOT NULL,
	NgaySinh DATE not null,
	GioiTinh bit not null,
)

create table Hang(
	MaH VARCHAR(10) PRIMARY KEY not null,
	MaMH VARCHAR(10) NOT NULL,
	MaNCC VARCHAR(10) not null,
	HanSuDung DATETIME NOT NULL,
	NgayNhap DATETIME NOT NULL,
	GiaNhap money NOT NULL,
	SoLuong int NOT NULL,
	GiaBan money not null,
	--DonViTinh NVARCHAR(20) NOT NULL,

)

create table DonHangNhap(
	MaDHN VARCHAR(10) PRIMARY KEY not null,
	MaNCC VARCHAR(10) not null,
	NgayNhap DATETIME not null,
	GiamGia varchar(10),
	KieuGiamGia Nvarchar(100),
)


 
create table DonHangXuat(
	MaDHX VARCHAR(10) primary key not null,
	MaKH VARCHAR(10)  not null,
	NgayXuat DATETIME not null,
	GiamGia varchar(10),
	KieuGiamGia Nvarchar(100),
)


create table HangDonHangNhap(
	MaDHN VARCHAR(10) not null,
	MaH VARCHAR(10) not null,
	SoLuong int NOT NULL,
	PRIMARY KEY (MaDHN,MaH)
)

create table HangDonHangXuat(
	MaDHX VARCHAR(10)  not null,
	MaH VARCHAR(10) not null,
	SoLuong int NOT NULL,
	PRIMARY KEY (MaDHX,MaH)
)

--ADD CONSTRANIT FOREIGN KEY

ALTER TABLE MauHangNhomHang ADD CONSTRAINT FK_MauHang_MauHangNhomHang FOREIGN KEY (MaMH) REFERENCES MauHang(MaMH)
ALTER TABLE MauHangNhomHang ADD CONSTRAINT FK_NhomHang_MauHangNhomHang FOREIGN KEY (MaNH) REFERENCES NhomHang(MaNH)

ALTER TABLE Hang ADD CONSTRAINT FK_MauHang_Hang FOREIGN KEY (MaMH) REFERENCES MauHang(MaMH)
ALTER TABLE Hang ADD CONSTRAINT FK_NhaCungCap_Hang FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)

ALTER TABLE DonHangNhap ADD CONSTRAINT FK_NhaCungCap_DonHangNhap FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC)
ALTER TABLE DonHangXuat ADD CONSTRAINT FK_KhachHang_DonHangXuat FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)

ALTER TABLE HangDonHangNhap ADD CONSTRAINT FK_DonHangXuat_HangDonHangNhap FOREIGN KEY (MaDHN) REFERENCES DonHangNhap(MaDHN)
ALTER TABLE HangDonHangNhap ADD CONSTRAINT FK_Hang_DonHangNhap FOREIGN KEY (MaH) REFERENCES Hang(MaH)

ALTER TABLE HangDonHangXuat ADD CONSTRAINT FK_DonHangXuat_HangDonHangXuat FOREIGN KEY (MaDHX) REFERENCES DonHangXuat(MaDHX)
ALTER TABLE HangDonHangXuat ADD CONSTRAINT FK_Hang_DonHangXuat FOREIGN KEY (MaH) REFERENCES Hang(MaH)

INSERT INTO NguoiDung VALUES
	('ND111','Codau8tuoi','246810',N'Admin',N'Võ Hữu Huy','0905700699','Huy.jpg',N'Vũng Tàu','1'),
	('ND112','Codau9tuoi','cobanthan',N'Quản Lý',N'Võ Hữu Thuận','0905700699','Thuan.jpg',N'Đà Lạt','1'),
	('ND113','Codau10tuoi','caychoidot',N'Nhân Viên',N'Võ Hữu Vang','0905700699','Vang.jpg',N'Hà Tĩnh','1'),
	('ND114','Codau11tuoi','cailaptop',N'Admin',N'Võ Hữu Lương','0905700699','Lương.jpg',N'Hồ Chí Minh','1'),
	('ND115','Codau12tuoi','caimaytinh',N'Admin',N'Võ Hữu Nghi','0905700699','Nghi.jpg',N'Cà Mau','1')

INSERT INTO MauHang VALUES
	('MH111',N'Mẫu Hàng 1',N'Đơn Vị 1',N'Anh1.jpg',N'Khong chu thich'),
	('MH112',N'Mẫu Hàng 2',N'Đơn Vị 2',N'Anh2.jpg',N'Khong chu thich'),
	('MH113',N'Mẫu Hàng 3',N'Đơn Vị 3',N'Anh3.jpg',N'Khong chu thich'),
	('MH114',N'Mẫu Hàng 4',N'Đơn Vị 4',N'Anh5.jpg',N'Khong chu thich'),
	('MH115',N'Mẫu Hàng 5',N'Đơn Vị 5',N'Anh6.jpg',N'Khong chu thich')


Insert into NhomHang Values
	('NH111',N'Nhóm Hàng 1'),
	('NH112',N'Nhóm Hàng 2'),
	('NH113',N'Nhóm Hàng 3'),
	('NH114',N'Nhóm Hàng 4'),
	('NH115',N'Nhóm Hàng 5')



Insert into MauHangNhomHang values
	('MH111','NH111'),
	('MH112','NH112'),
	('MH113','NH113'),
	('MH114','NH114'),
	('MH115','NH115')


insert into NhaCungCap values
	('NCC111',N'Nhà cung cấp 1',N'Việt Nam',N'Nha Trang,Khánh Hòa','77779999','Ncc1@gmail.com'),
	('NCC112',N'Nhà cung cấp 2',N'Thái Lan',N'Bang koc','77779999','Ncc2@gmail.com'),
	('NCC113',N'Nhà cung cấp 3',N'Mexico',N'Urafe','77779999','Ncc3@gmail.com'),
	('NCC114',N'Nhà cung cấp 4',N'Lào',N'LeLeLe','77779999','Ncc3@gmail.com'),
	('NCC115',N'Nhà cung cấp 5',N'Việt Nam',N'Nha Trang,Khánh Hòa','77779999','Ncc5@gmail.com')


insert into KhachHang values
	('KH111',N'Ngô Nguyễn Tường Nghi',N'Nghi.jpg',N'Diên Khánh, Khánh Hòa','12121212','Nghi@gmail.com','1999/3/2','1'),
	('KH112',N'Ngô Bá Khá',N'Khá.jpg',N'Nha Trang, Khánh Hòa','12121213','Kha@gmail.com','1998/3/12','1'),
	('KH113',N'Ngô Uyên Ương',N'Ương.jpg',N'Đà lạt','12121214','Uong@gmail.com','1997/12/2','0'),
	('KH114',N'Ngô Văn Giàu',N'Giàu.jpg',N'Cà Mau','12121215','Giau@gmail.com','1999/6/6','0'),
	('KH115',N'Ngô Nguyễn Cát Tường',N'Tuong.jpg',N'Hà Nội','12121216','Tuong@gmail.com','1999/3/2','1')


insert into Hang values
	('H111','MH111','NCC111','2020/12/12','2020/5/8','12000000','10','13000000'),
	('H112','MH112','NCC112','2020/12/12','2020/5/8','2000000','10','3000000'),
	('H113','MH113','NCC113','2020/12/12','2020/5/8','10000000','10','12000000'),
	('H114','MH114','NCC114','2020/12/12','2020/5/8','12000000','10','13000000'),
	('H115','MH115','NCC115','2020/12/12','2020/5/8','12000000','10','13000000')


insert into DonHangNhap values 
	('DHN111','NCC111','2020/8/12','15%',N'Kiểu giảm giá 1'),
	('DHN112','NCC112','2020/8/12','15%',N'Kiểu giảm giá 2'),
	('DHN113','NCC113','2020/8/12','15%',N'Kiểu giảm giá 2'),
	('DHN114','NCC114','2020/8/12','15%',N'Kiểu giảm giá 1'),
	('DHN115','NCC115','2020/8/12','15%',N'Kiểu giảm giá 1')


insert into DonHangXuat values 
	('DHX111','KH111','2020/11/11','10%',N'Kiểu giảm giá 1'),
	('DHX112','KH112','2020/11/11','0%',N'Kiểu giảm giá 2'),
	('DHX113','KH113','2020/11/11','10%',N'Kiểu giảm giá 1'),
	('DHX114','KH114','2020/11/11','10%',N'Kiểu giảm giá 1'),
	('DHX115','KH115','2020/11/11','10%',N'Kiểu giảm giá 1')

insert into HangDonHangNhap values
	('DHN111','H111','10'),
	('DHN112','H112','10'),
	('DHN113','H113','10'),
	('DHN114','H114','10'),
	('DHN115','H115','10')

insert into HangDonHangXuat values
	('DHX111','H111','5'),
	('DHX112','H111','6'),
	('DHX113','H111','7'),
	('DHX114','H111','8'),
	('DHX115','H111','9')

