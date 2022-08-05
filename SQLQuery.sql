use db
create table Customers
(
	Id int primary key identity,
	Name nvarchar(20)
)
create table Orders
(
	Id int primary key identity,
	CustomerId int foreign key references Customers(Id)
)
insert into Customers (Name) values ('Max'),( 'Pavel'), ('Ivan'), ('Leonid')
insert into Orders (CustomerId) values (2),(4)

select Name from Customers
where Customers.Id not in (select CustomerId from Orders)