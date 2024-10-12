-- Tạo cơ sở dữ liệu
CREATE DATABASE QuanLySinhVien;
GO

-- Sử dụng cơ sở dữ liệu vừa tạo
USE QuanLySinhVien;
GO

-- Tạo bảng Student
CREATE TABLE Student (
    StudentID nvarchar(20) NOT NULL PRIMARY KEY,
    FullName nvarchar(200) NOT NULL,
    AverageScore float NOT NULL,
    Gender nvarchar(10) NULL,
    FacultyID int NOT NULL
);

-- Tạo bảng Faculty
CREATE TABLE Faculty (
    FacultyID int NOT NULL PRIMARY KEY,
    FacultyName nvarchar(200) NOT NULL,
    TotalProfessor int NULL
);

-- Thêm ràng buộc khóa ngoại (Foreign Key) cho bảng Student, liên kết FacultyID với bảng Faculty
ALTER TABLE Student
ADD CONSTRAINT FK_Student_Faculty FOREIGN KEY (FacultyID)
REFERENCES Faculty(FacultyID);



-- Thêm dữ liệu vào bảng Faculty
INSERT INTO Faculty (FacultyID, FacultyName, TotalProfessor)
VALUES
(1, N'Công nghệ thông tin', 2),
(2, N'Ngôn ngữ Anh', 3),
(3, N'Khoa học môi trường', 3),
(4, N'Kỹ thuật điện tử', 1),
(5, N'Marketing', 1);

-- Thêm dữ liệu vào bảng Student
INSERT INTO Student (StudentID, FullName, AverageScore, Gender, FacultyID)
VALUES
('1611061916', N'Nguyễn Trần Hoàng Lan', 4.5, N'Female', 1),
('1711060596', N'Đàm Minh Đức', 10, N'Male', 2),
('1711061233', N'Trần Văn A', 7, N'Male', 2),
('1811061004', N'Nguyễn Quốc An', 8, N'Male', 3),
('1911060023', N'Lê Hoàng Phương', 9, N'Female', 4),
('2011061205', N'Phạm Văn Cường', 9.1, N'Male', 4);

