create database QLCT
go

use QLCT
go

--account
create table Tk
(
	--id int identity primary key,
	--DisplayName nvarchar(100) not null,
	--UserName nvarchar(100) not null,
	--PassWord nvarchar(1000) not null
	UserName varchar(100) primary key,
	DisplayName nvarchar(100) not null default N'Chưa đặt tên',
	PassWord varchar(1000) not null default 0
)
go

insert into dbo.Tk
(
	UserName,
	DisplayName,
	PassWord
)
values 
(
	N'admin',  --UserName
	N'admin',  --DisplayName
	N'admin'  --PassWord
)		
go

create proc USP_GetAccountByUserName
@userName varchar(100)
as
begin
	select * from dbo.Tk where UserName = @userName
end
go

exec dbo.USP_GetAccountByUserName @userName = N'admin' --nvarchar(100)
go

create proc USP_Login
@userName varchar(100), @passWord varchar(1000)
as
begin
	select * from dbo.Tk where UserName = @userName and PassWord = @passWord
end
go

select * from dbo.Tk