﻿Create Database QLSanPham go  use QLSanPham go Create table Categories( 	CategoryId int primary key Identity(1,1), 	CategoryName nvarchar(max) not null, ) Create table Products( 	ProductId int primary key Identity(1,1), 	ProductName nvarchar(max) not null, 	ProductPrice decimal not null, 	ProductDescription nvarchar(max), 	ProductImage nvarchar(max), 	CategoryId int references Categories(CategoryId) )  Drop table Products drop table Categories  Insert into Categories values (N'Trái Cây') Insert into Categories values (N'Rau, Củ, Quả')  select * from Categories select p.ProductId, p.ProductName, p.ProductPrice, p.ProductImage, p.ProductDescription, c.CategoryName from Products p, Categories c where p.CategoryId = c.CategoryId  Insert into Products values (N'Bông Cải Trắng', '85.000', N'Bông cải trắng hay còn gọi là súp lơ trắng, là một loại rau thuộc họ Cải. Chúng được gieo trồng bằng hạt, sau khi lớn sẽ thành những cụm bông nhỏ màu trắng. Khi chế biến, bông cải này có vị giòn, ngọt, thanh mát và được rất nhiều người yêu thích.', N'https://product.hstatic.net/200000356473/product/z5072158094906_bd1e6f10de45323cb9ab2637ccd1680c_44bd671facab4aa2a9a46bf18d461bfa_grande.jpg', '2') Insert into Products values (N'Bông Cải Xanh', '75.000', N'Bông cải xanh (hoặc súp lơ xanh) là một loại cây thuộc loài Cải bắp dại, có hoa lớn ở đầu, thường được dùng như rau. Bông cải xanh thường được chế biến bằng cách luộc hoặc hấp, nhưng cũng có thể được ăn sống như là rau sống trong những đĩa đồ nguội khai vị.', N'https://product.hstatic.net/200000356473/product/bong_cai_xanh_c83017205334490fb7f7ef70570b80b9_grande.png', '2')   select * from Products   UPDATE Products SET ProductName = N'Bông cải xanh',     ProductDescription = N'Bông cải xanh là một loại cây thuộc loài Cải bắp dại, có hoa lớn ở đầu, thường được dùng như rau.' WHERE ProductId = 3003; select * from Products Create table Users ( 	Id int primary key Identity(1,1), 	UserName nvarchar(max) not null, 	Password nvarchar(max) not null, 	Phone char(10) not null, 	DiaChi nvarchar(max) ) drop table Users insert into Users values (N'Vinh', '12345', '1234567890', N'Chung Cư Nguyễn Hoàng') select * from Users  select * from Products where ProductName like  N'%a%'