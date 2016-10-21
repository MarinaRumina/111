--select 
--	dbo.Categories.id, 
--	dbo.Products.CategoryID
--from 
--	dbo.Categories 
--inner join 
--	dbo.Products
--on 
--	dbo.Categories.id = dbo.Products.CategoryID;

--insert into dbo.Categories([CategoryName])
--values ('Salads');

--insert into dbo.Categories([CategoryName])
--values ('Main Dishes');

--insert into dbo.Categories([CategoryName])
--values ('Beverages');

select * from dbo.Categories;