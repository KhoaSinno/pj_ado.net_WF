
CREATE PROCEDURE sp_GetQuan
AS
BEGIN
    SET NOCOUNT ON;
    select * from Quan Order By Quan;
END

select * from Phuong
select * from Quan
select * from Orders
select * from Phuong where Quan_ID = 1 Order By Phuong

INSERT INTO Orders (Order_ID, CusName, PhoneNum, Del_info) VALUES (1212,'Sinoo', '12311', 'Can Tho')