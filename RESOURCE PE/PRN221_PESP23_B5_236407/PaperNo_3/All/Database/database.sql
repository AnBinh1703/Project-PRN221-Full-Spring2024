
create database PE_PRN_Spr23_B5
go
USE PE_PRN_Spr23_B5
go
create table [Department] (
[DepartmentId] [int] identity,
[DepartmentName] [nvarchar] (100));
go
set identity_insert [Department] on;
go
insert [Department] ([DepartmentId],[DepartmentName])
select 1,N'Computing Fundamental' UNION ALL
select 2,N'Software Engineering' UNION ALL
select 3,N'Softskill' UNION ALL
select 4,N'English' UNION ALL
select 5,N'Japanese';
go
set identity_insert [Department] off;
go
create table [Major] (
[MajorCode] [varchar] (2),
[MajorName] [varchar] (50));
go
insert [Major] ([MajorCode],[MajorName])
select 'AI','Artificial Intelligence' UNION ALL
select 'GD','Graphic Design' UNION ALL
select 'IA','Information Assurance' UNION ALL
select 'SE','Software Engineering';
go
create table [Instructor] (
[InstructorId] [int] identity,
[Fullname] [nvarchar] (200),
[ContractDate] [date],
[IsFulltime] [bit],
[Department] [int]);
go
set identity_insert [Instructor] on;
go
insert [Instructor] ([InstructorId],[Fullname],[ContractDate],[IsFulltime],[Department])
select 1,N'Le Bao Trung','2007-10-12',1,1 UNION ALL
select 2,N'Nguyen Gia Hieu','2008-09-15',1,1 UNION ALL
select 3,N'Hoang Viet Cuong','2010-07-06',0,1 UNION ALL
select 4,N'Do Thien Long','2020-02-15',0,2 UNION ALL
select 5,N'Hoang Viet Long','2021-02-16',1,2 UNION ALL
select 6,N'Le Thi Thu Trang','2019-10-20',1,3 UNION ALL
select 7,N'Do Bao Ngoc','2019-12-16',0,4 UNION ALL
select 10,N'Dinh Gia Bao','2018-05-15',1,5 UNION ALL
select 11,N'Duong Thien Nga','2017-03-09',0,5 UNION ALL
select 12,N'Hoang Bao Chau','2020-12-16',1,5 UNION ALL
select 13,N'Vu Ngoc Binh','2021-01-01',0,1 UNION ALL
select 1002,N'Bui Dinh Chien','2019-09-01',0,2;
go
set identity_insert [Instructor] off;
go
create table [Student] (
[StudentId] [int] identity,
[FullName] [nvarchar] (200),
[Male] [bit] NULL,
[Dob] [date],
[Major] [varchar] (2));
go
set identity_insert [Student] on;
go
insert [Student] ([StudentId],[FullName],[Male],[Dob],[Major])
select 1,N'Dinh Bao Ngoc',0,'2000-10-12','SE' UNION ALL
select 2,N'Do Thi Huong Giang',0,'2001-09-10','GD' UNION ALL
select 3,N'Duong Phuong Thao',0,'2001-10-06','GD' UNION ALL
select 4,N'Tran Duc Binh',1,'2000-01-12','SE' UNION ALL
select 5,N'Vu Hoang Long',1,'2002-07-07','SE' UNION ALL
select 6,N'Do Thi Thu Trang',0,'2000-10-01','IA' UNION ALL
select 7,N'Ha Khuc Khanh An',0,'2003-08-02','AI' UNION ALL
select 8,N'Tran Bao Chau',1,'2002-10-05','IA' UNION ALL
select 9,N'Duong Phuong Thao',0,'2003-08-07','AI' UNION ALL
select 10,N'Tran Binh Giang',1,'2003-08-05','SE' UNION ALL
select 11,N'Do Hoang Giang',1,'2000-12-06','AI';
go
set identity_insert [Student] off;