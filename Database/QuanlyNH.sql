USE [QLNH]
GO
/****** Object:  Table [dbo].[AccountB]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccountB](
	[UserName] [nvarchar](100) NOT NULL,
	[PassWord] [nvarchar](500) NOT NULL DEFAULT ('0'),
	[QUYENHAN] [nvarchar](10) NOT NULL,
	[Tennhanvien] [nvarchar](30) NOT NULL,
	[Diachi] [nvarchar](30) NOT NULL,
	[Dienthoai] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](30) NOT NULL,
	[Chucvu] [nvarchar](30) NOT NULL,
	[Ngaysinh] [nvarchar](10) NOT NULL,
	[Gioitinh] [nvarchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillCopy]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillCopy](
	[BillID] [int] NOT NULL,
	[TableName] [nvarchar](100) NOT NULL,
	[CheckIn] [datetime] NOT NULL,
	[CheckOut] [datetime] NOT NULL,
	[Discount] [int] NOT NULL,
	[TotalPrice] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BillInfos]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillInfos](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IdBill] [int] NOT NULL,
	[IdFood] [int] NOT NULL,
	[Count] [int] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Bills]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bills](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateCheckIn] [date] NOT NULL DEFAULT (getdate()),
	[DateCheckOut] [date] NULL,
	[IdTable] [int] NOT NULL,
	[Status] [int] NOT NULL DEFAULT ((0)),
	[discount] [int] NULL,
	[TotalPrice] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CV]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV](
	[Name] [nvarchar](100) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Food]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Food](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa có tên.'),
	[IdCategory] [int] NOT NULL,
	[Price] [float] NOT NULL,
 CONSTRAINT [PK_Food] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodCategory]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodCategory](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa có tên.'),
 CONSTRAINT [PK_FoodCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KiemsoatDN]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KiemsoatDN](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TableFood]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TableFood](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL DEFAULT (N'Chưa có tên.'),
	[Status] [nvarchar](100) NOT NULL DEFAULT (N'Trống'),
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[BillInfos]  WITH CHECK ADD FOREIGN KEY([IdBill])
REFERENCES [dbo].[Bills] ([Id])
GO
ALTER TABLE [dbo].[BillInfos]  WITH CHECK ADD  CONSTRAINT [FK_BillInfos_Food] FOREIGN KEY([IdFood])
REFERENCES [dbo].[Food] ([ID])
GO
ALTER TABLE [dbo].[BillInfos] CHECK CONSTRAINT [FK_BillInfos_Food]
GO
ALTER TABLE [dbo].[Bills]  WITH CHECK ADD FOREIGN KEY([IdTable])
REFERENCES [dbo].[TableFood] ([ID])
GO
ALTER TABLE [dbo].[Food]  WITH CHECK ADD  CONSTRAINT [FK_Food_FoodCategory] FOREIGN KEY([IdCategory])
REFERENCES [dbo].[FoodCategory] ([ID])
GO
ALTER TABLE [dbo].[Food] CHECK CONSTRAINT [FK_Food_FoodCategory]
GO
/****** Object:  StoredProcedure [dbo].[CardAccount]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CardAccount]
as
begin
	select a.UserName as [Tên người dùng],a.PassWord as [Mật khẩu],a.QUYENHAN as [Quyền Hạn],a.Tennhanvien as [Tên nhân viên],a.Diachi as [Địa chỉ],a.Dienthoai as [Điện Thoại],a.Email as [Email],a.Chucvu as [Chức vụ],a.Ngaysinh as [Ngày sinh],a.Gioitinh as [Giới tính]
	from AccountB as a
	where QUYENHAN!='admin'
end 
GO
/****** Object:  StoredProcedure [dbo].[checkDT]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[checkDT]
as
begin
	select c.Name,c.Price,b.Count,c.Price*b.Count as 'TotalPrice', a.Id from Bills as a , BillInfos as b, Food as c
	where b.IdFood = c.ID and a.DateCheckOut is not null and a.Id = b.IdBill
end
GO
/****** Object:  StoredProcedure [dbo].[checkout]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[checkout]
as
begin
	select a.IdTable,c.Name,c.Price,b.Count,c.Price * b.Count as TotalPrice from Bills as a , BillInfos as b, Food as c
	where a.DateCheckOut is NULL and a.Id = b.IdBill and b.IdFood = c.ID
end
GO
/****** Object:  StoredProcedure [dbo].[GopTable]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GopTable] @tableId1 int,@tableId2 int
as
Begin
	Declare @billId1 int
	declare @billId2 int
	declare @IdFood int
	declare @Count int
	select @billId1 = Id
	from dbo.Bills
	where IdTable = @tableId1 and Status =0

	select @IdFood = IdFood
	from BillInfos
	where IdBill = @billId1

	select @Count = Count 
	from BillInfos
	where IdBill = @billId1

	select @billId2 = Id
	from dbo.Bills
	where IdTable = @tableId2

	Insert dbo.BillInfos (IdBill,IdFood,Count) values (@billId2, @IdFood,@Count)

	
End

GO
/****** Object:  StoredProcedure [dbo].[Hoadon]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Hoadon]
as
Begin
	select a.Id,a.IdTable,C.Name,b.Count,c.Price
	from Bills as a,BillInfos as b,Food as c
	where a.Id = (select Max(Id) from Bills) and a.Id = b.IdBill and b.IdFood = c.ID
end

EXEC Hoadon

EXEC KALI

GO
/****** Object:  StoredProcedure [dbo].[Hoadond]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Proc [dbo].[Hoadond]
as
Begin
	select a.Id,a.IdTable,C.Name,b.Count,c.Price
	from Bills as a,BillInfos as b,Food as c
	where a.Id = (select Max(Id) from Bills) and a.Id = b.IdBill and b.IdFood = c.ID
end
GO
/****** Object:  StoredProcedure [dbo].[Insert_table]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[Insert_table]
as
Begin
DECLARE @i INT = 0
WHILE @i <= 1
BEGIN
	INSERT dbo.TableFood ( name)VALUES  ( N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
End

GO
/****** Object:  StoredProcedure [dbo].[KALI]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROC [dbo].[KALI]
as
Begin
Declare @i int = (select MAX(Id) from TableFood)
Delete from TableFood where ID = @i
end
GO
/****** Object:  StoredProcedure [dbo].[Menu]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[Menu]
as
Begin
	select a.Name,a.Price,b.Name as N'Loại'
	from Food as a,FoodCategory as b
	where b.ID = A.IdCategory
end

GO
/****** Object:  StoredProcedure [dbo].[MITA]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MITA]
AS
BEGIN
Declare @i int = (select COUNT(Id)+1  from dbo.TableFood)
Insert dbo.TableFood values(N'Bàn ' + CAST(@i as nvarchar(20)),N'Trống')
end
GO
/****** Object:  StoredProcedure [dbo].[PP_getlistbillbydate]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[PP_getlistbillbydate]
@checkin date, @checkout date
as
begin
	select t.Name , b.TotalPrice , DateCheckIn , DateCheckOut, discount
	from Bills as b,FoodCategory as t
	where DateCheckIn >= @checkin and DateCheckOut <= @checkout and b.Status =1
	and t.ID = b.TotalPrice
end

GO
/****** Object:  StoredProcedure [dbo].[Store_InsertBillByTableId]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[Store_InsertBillByTableId] @tableId int
AS
BEGIN
	INSERT INTO dbo.Bill
	        ( DateCheckIn ,
	          DateCheckOut ,
	          IdTable ,
	          Status
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @tableId , -- IdTable - int
	          0  -- Status - int
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[Store_InsertBillInfo]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Store_InsertBillInfo] @billId int,@foodId int,@count int
AS
BEGIN

	DECLARE @billInfoId INT = 0
	DECLARE @newCount INT = 0

	SELECT @billInfoId = ID, @newCount = Count + @count
	FROM dbo.BillInfos 
	WHERE IdBill = @billId AND IdFood = @foodId

	IF @billInfoId = 0
		BEGIN
			IF @count > 0
				INSERT INTO dbo.BillInfos
					( IdBill, IdFood, Count )
				VALUES  ( @billId, -- IdBill - int
					@foodId, -- IdFood - int
					@count  -- Count - int
					)
		END
	ELSE
		IF @newCount <= 0
			DELETE dbo.BillInfos
			WHERE ID = @billInfoId
		ELSE
			UPDATE dbo.BillInfos
			SET
            Count = @newCount
			WHERE ID = @billInfoId
END

GO
/****** Object:  StoredProcedure [dbo].[StorePP_InsertBillByTableId]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StorePP_InsertBillByTableId] @tableId int
AS
BEGIN
	INSERT INTO dbo.Bills
	        ( DateCheckIn ,
	          DateCheckOut ,
	          IdTable ,
	          Status,
			  discount
			  
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @tableId , -- IdTable - int
	          0,  -- Status - int
			  0
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_CheckOutBill]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_CheckOutBill] @billId int, @discount int , @totalPrice int
AS
BEGIN
	UPDATE dbo.Bills
	SET DateCheckOut = GETDATE() , Status = 1, discount = @discount , TotalPrice = @totalPrice
	WHERE Id = @billId

	DECLARE @name nvarchar(100)
	DECLARE @checkin DATETIME
	DECLARE @checkout DATETIME

	SELECT @name = dbo.TableFood.Name , @checkin = dbo.Bills.DateCheckIn , @checkout = dbo.Bills.DateCheckOut
	FROM dbo.Bills , dbo.TableFood
	WHERE dbo.Bills.IdTable = dbo.TableFood.ID AND dbo.Bills.Id = @billId 

 	EXEC StoreProc_InsertBillCopy @billid  , @name , @checkin , @checkout , @discount  , @totalprice 
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_GetBillIdUncheck]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_GetBillIdUncheck] @idTable int
AS
BEGIN
	SELECT * FROM dbo.Bills WHERE IdTable = @idTable AND Status = 0
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_GetBillIdUnchecks]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_GetBillIdUnchecks] @idTable int
AS
BEGIN
	SELECT * FROM dbo.Bills WHERE IdTable = @IdTable AND Status = 0
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_GetCheckOutBillListByDate]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_GetCheckOutBillListByDate] @dateTime1 datetime , @dateTime2 datetime
AS
BEGIN
	SELECT  Id AS N'ID Hóa đơn',DateCheckIn as N'Ngày vào', DateCheckOut AS N'Ngày ra', discount AS N'Giảm giá (%)', TotalPrice AS N'Tổng tiền'
	FROM Bills 
	WHERE DateCheckOut BETWEEN @dateTime1 and @dateTime2
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_GetFoodListByCategoryId]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_GetFoodListByCategoryId] @categoryId int
AS
BEGIN
	SELECT ID,Name,IdCategory,Price
	FROM dbo.Food
	WHERE IdCategory = @categoryId
	ORDER BY Name
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_GetTableList]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[StoreProc_GetTableList]
AS
BEGIN
	SELECT * FROM dbo.TableFood
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_InsertBillCopy]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[StoreProc_InsertBillCopy] @billid int , @tablename nvarchar(100), @checkin datetime, @checkout datetime, @discount int , @totalprice int
AS BEGIN
	INSERT INTO dbo.BillCopy
	        ( BillID ,
	          TableName ,
	          CheckIn ,
	          CheckOut ,
	          Discount ,
	          TotalPrice
	        )
	VALUES  ( @billid , -- BillID - int
	          @tablename , -- TableName - nvarchar(100)
	          @checkin , -- CheckIn - datetime
	          @checkout , -- CheckOut - datetime
	          @discount , -- Discount - int
	          @totalprice  -- TotalPrice - int
	        )
END

GO
/****** Object:  StoredProcedure [dbo].[StoreProc_SwapBillForTable]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[StoreProc_SwapBillForTable] @tableId1 int,@tableId2 int
AS
BEGIN
	DECLARE @billId1 INT
	DECLARE @billId2 INT

	SELECT @billId1 = Id
    FROM dbo.Bills
	WHERE IdTable = @tableId1 AND Status = 0

	IF(@billId1 IS NULL) RETURN

	SELECT @billId2 = Id
    FROM dbo.Bills
	WHERE IdTable = @tableId2 AND Status = 0

	IF(@billId2 IS NULL)
		BEGIN
			UPDATE dbo.Bills
			SET
            IdTable = @tableId2
			WHERE  Id = @billId1

			UPDATE dbo.TableFood
			SET
            Status = N'Trống'
			WHERE ID = @tableId1
			PRINT @tableId1
		END
    ELSE
		BEGIN
			UPDATE dbo.Bills
			SET
            IdTable = @tableId2
			WHERE  Id = @billId1

			UPDATE dbo.Bills
			SET
            IdTable = @tableId1
			WHERE  Id = @billId2
		END
        
END

GO
/****** Object:  StoredProcedure [dbo].[StoreTotalDT]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Proc [dbo].[StoreTotalDT] @dateTime1 datetime , @dateTime2 datetime
as
Begin
	select Sum(TotalPrice) as 'Tổng tiền'
	from Bills
	where DateCheckOut between @dateTime1 and @dateTime2
end

GO
/****** Object:  StoredProcedure [dbo].[StoreTotalNow]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Proc [dbo].[StoreTotalNow] @dateTime1 datetime
as
begin
	select sum(TotalPrice) as N'Tổng tiền'
	from Bills
	where DateCheckOut = @dateTime1
end

GO
/****** Object:  StoredProcedure [dbo].[tablea]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[tablea]
as
begin
	select * from TableFood
end
GO
/****** Object:  StoredProcedure [dbo].[USP_GetTableList]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[USP_GetTableList]
AS SELECT * FROM dbo.TableFood

GO
/****** Object:  StoredProcedure [dbo].[USPGetTableLists]    Script Date: 09/05/2019 11:20:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc	[dbo].[USPGetTableLists]
as select * from TableFood

GO
