
--CREATE PROCEDURE sp_GetQuan
--AS
--BEGIN
--    SET NOCOUNT ON;
--    select * from Quan Order By Quan;
--END

--DROP PROCEDURE sp_GetQuan

--create procedure sp_GetQuan
--as	
--	select * from Quan Order By Quan
--return

--exec sp_GetQuan


--AlTER PROCEDURE AuthenticateUser
--    @inputUsername VARCHAR(50),
--    @inputPassword VARCHAR(100)
--AS
--BEGIN
--    SET NOCOUNT ON;

--    IF EXISTS (
--        SELECT 1
--        FROM Users
--        WHERE Username = @inputUsername COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @inputPassword COLLATE SQL_Latin1_General_CP1_CS_AS
--    )
--    BEGIN
--        SELECT 1 AS Result;
--    END
--    ELSE
--    BEGIN
--        SELECT -1 AS Result;
--    END
--END;


ALTER PROCEDURE AuthenticateUser
    @inputUsername VARCHAR(20),
    @inputPassword VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @UserID VARCHAR(12);

    IF EXISTS (
        SELECT User_ID
        FROM Users
        WHERE Username = @inputUsername COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @inputPassword COLLATE SQL_Latin1_General_CP1_CS_AS
    )
    BEGIN
        -- Lấy User_ID của người dùng đã xác thực thành công
        SELECT @UserID = User_ID
        FROM Users
        WHERE Username = @inputUsername COLLATE SQL_Latin1_General_CP1_CS_AS AND Password = @inputPassword COLLATE SQL_Latin1_General_CP1_CS_AS;

        -- Trả về User_ID
        SELECT @UserID AS User_ID;
    END
    ELSE
    BEGIN
        SELECT '-1' AS User_ID;
    END
END;

ALTER PROCEDURE usp_GetUserRoles
    @User_ID VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT u.User_ID AS User_ID,
           r.RoleName AS RoleName,
           r.Role_ID AS Role_ID
    FROM Users u
    INNER JOIN User_Roles ur ON u.User_ID = ur.User_ID
    INNER JOIN Roles r ON r.Role_ID = ur.Role_ID
    WHERE u.User_ID = @User_ID;
END;

CREATE OR ALTER PROCEDURE usp_UpdateOrderStatus
    @Status_ID int,
    @Order_ID varchar(15)
AS
BEGIN
    -- Kiểm tra tính hợp lệ của Order_ID
    IF NOT EXISTS (SELECT 1 FROM Orders WHERE Order_ID = @Order_ID)
    BEGIN
        RAISERROR ('Order_ID không hợp lệ.', 16, 1)
        RETURN
    END

    -- Cập nhật trạng thái của đơn hàng
    BEGIN TRY
        UPDATE Orders SET Status_ID = @Status_ID WHERE Order_ID = @Order_ID
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi và thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000)
        SET @ErrorMessage = ERROR_MESSAGE()
        RAISERROR (@ErrorMessage, 16, 1)
    END CATCH
END;


select * from User_Roles
select * from Roles


DROP PROCEDURE AuthenticateUser
----------------------------------------------------- Create Users -------------------------------------------
CREATE TABLE Users (
    User_ID VARCHAR(12) NOT NULL PRIMARY KEY,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL
);

drop table Users

INSERT INTO Users VALUES 
	   ('K12345','admin', '123123'),
       ('K54321','cus', '123123'),
       ('K12133','c1', '123123'),
       ('K12132','c2', '123123')

ALTER TABLE Roles
ADD User_ID VARCHAR(12) NOT NULL;

ALTER TABLE User_Roles
ADD User_ID VARCHAR(12) NOT NULL;

ALTER TABLE Users
DROP CONSTRAINT PK__Account__3213E83F4399F021;


ALTER TABLE Users
ALTER COLUMN User_ID VARCHAR(12);



--EXEC sp_rename 'Account', 'Users';

EXEC sp_rename 'Users.Account_ID', 'User_ID', 'COLUMN';

CREATE TABLE [dbo].[Roles]
(
    [Role_ID] [int] NOT NULL,
    [RoleName] [nvarchar](50) NULL,

    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Role_ID] ASC)
) 

ALTER TABLE Users
ALTER COLUMN Role_ID int;


drop table [dbo].[Roles]

INSERT INTO Roles (Role_ID, RoleName) VALUES (0, N'Chủ shop');

INSERT INTO Roles (Role_ID, RoleName) VALUES (1, N'Khách hàng');

DELETE FROM Roles;

--------------------------------------Create [User_Roles] ------------------------------------------
CREATE TABLE [dbo].[User_Roles]
(
    [User_ID] [VARCHAR](12) NOT NULL,
    [Role_ID] [int] NOT NULL,

    CONSTRAINT [PK_User_Roles] PRIMARY KEY CLUSTERED ([User_id], [Role_id]),
    CONSTRAINT [UQ_ReversePK] UNIQUE ([Role_id], [User_id])
)

drop table [dbo].[User_Roles]

INSERT INTO User_Roles VALUES ('K12345', 0);
INSERT INTO User_Roles VALUES ('K54321', 1);
--------------------------------------Create Order_Status ------------------------------------------

CREATE TABLE Order_Status (
    Status_ID INT PRIMARY KEY,
    Status_Name NVARCHAR(50)
);

go 

INSERT INTO Order_Status (Status_ID, Status_Name) VALUES
(2, 'PENDING'),
(1, 'APPROVED'),
(0, 'REJECT');

select * from Order_Status
--------------------------------------Create Order ------------------------------------------

ALTER TABLE Orders
ADD Status_ID int NOT NULL;

select * from Orders

--------------------------------------Set PK ---------------------------------------------------

ALTER TABLE User_Roles
ADD CONSTRAINT FK_User_Roles_User_ID
FOREIGN KEY (User_ID)
REFERENCES Users(User_ID);

ALTER TABLE User_Roles
ADD CONSTRAINT FK_User_Roles_Role_ID
FOREIGN KEY (Role_ID)
REFERENCES Roles(Role_ID);

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_User_ID
FOREIGN KEY (User_ID)
REFERENCES Users(User_ID);

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_Status_ID
FOREIGN KEY (Status_ID)
REFERENCES Order_Status(Status_ID);
--------------------------------------Select check ---------------------------------------------------
select * from User_Roles
select * from Roles
select * from Users
select * from Phuong
select * from Quan
select * from Orders
select * from Phuong where Quan_ID = 1 Order By Phuong

-- create a new col Cus_ID 
ALTER TABLE Orders
ADD Cus_ID VARCHAR(12) NOT NULL;

ALTER TABLE Orders
ALTER COLUMN Cus_ID VARCHAR(12) NOT NULL;

ALTER TABLE Orders
ALTER COLUMN Order_ID VARCHAR(12) NOT NULL;

ALTER TABLE Orders
DROP CONSTRAINT PK_Orders;


ALTER TABLE Orders
ADD CONSTRAINT PK_Orders PRIMARY KEY (Order_ID);


DELETE FROM orders

INSERT INTO Orders (Order_ID, CusName, PhoneNum, Del_info) VALUES (1212,'Sinoo', '12311', 'Can Tho')

--------------------------------------Test QR ---------------------------------------------------

select * from User_Roles
select * from Roles
select * from Users
select * from Phuong
select * from Quan
select * from Orders
select * from Phuong where Quan_ID = 1 Order By Phuong
select * from Order_Status





