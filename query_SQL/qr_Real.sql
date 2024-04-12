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

select Order_ID, CusName from Orders where Status_ID = 2