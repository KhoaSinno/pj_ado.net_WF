select * 
from Users u
inner join User_Roles ur on u.User_ID = ur.User_ID
inner join Roles r on r.Role_ID = ur.Role_ID
where u.User_ID = 'K12345'

SELECT u.User_ID AS User_ID, r.RoleName AS RoleName, r.Role_ID as Role_ID
FROM Users u
INNER JOIN User_Roles ur ON u.User_ID = ur.User_ID
INNER JOIN Roles r ON r.Role_ID = ur.Role_ID
WHERE u.User_ID = 'K12345';

select * from Users

select Order_ID, CusName, PhoneNum, Del_Info from Orders where Status_ID = 2

update Orders set Status_ID = 2 where Order_ID = 'D83004'
update Orders set Status_ID = 2 where Order_ID = 'D68663'
update Orders set Status_ID = 2 where Order_ID = 'D79342'
update Orders set Status_ID = 2 where Order_ID = 'D02001'

update Orders set Status_ID = 0 where Order_ID = 'D68663'

select * from Orders 
select * from Order_Status 
select * from Users 
select * from User_Roles

