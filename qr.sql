
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


CREATE PROCEDURE AuthenticateUser
    @inputUsername VARCHAR(50),
    @inputPassword VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1
        FROM Account
        WHERE username = @inputUsername COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @inputPassword COLLATE SQL_Latin1_General_CP1_CS_AS
    )
    BEGIN
        SELECT 1 AS Result;
    END
    ELSE
    BEGIN
        SELECT -1 AS Result;
    END
END;

DROP PROCEDURE AuthenticateUser

CREATE TABLE Account (
    id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(100) NOT NULL
    --created_at DATETIME DEFAULT GETDATE()
);
INSERT INTO Account (username, password)
VALUES ('admin', '123123'),
       ('a1', 'sa2'),
       ('a2', 'sa3'),
       ('a3', 'sa4')

select * from Account
select * from Phuong
select * from Quan
select * from Orders
select * from Phuong where Quan_ID = 1 Order By Phuong
select * from

INSERT INTO Orders (Order_ID, CusName, PhoneNum, Del_info) VALUES (1212,'Sinoo', '12311', 'Can Tho')