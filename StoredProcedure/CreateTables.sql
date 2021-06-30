use BookStore

create table books
(
 bookId int identity(1,1) primary key,
 bookName varchar(40) not null,
 price int not null,
 category varchar(40) not null,
 authors varchar(40) not null,
 arrivals datetime not null,
 availableBooks int not null
)

create table admin
(
adminId int identity(1,1) primary key,
email varchar(100) not null,
password varchar(40) not null,
)

create table users
(
userId int identity(1,1) primary key,
email varchar(100) not null,
password varchar(40) not null
)

create table cart
(
cartId int identity(1,1) primary key,
email varchar(100) not null,
quantity int not null,
price int not null,
userId int foreign key references users(userId),
bookId int foreign key references books(bookId)
)

create table wishlist
(
wishlistId int identity(1,1) primary key,
email varchar(100) not null,
price int not null,
userId int foreign key references users(userId),
bookId int foreign key references books(bookId)
)

create table orders
(
orderId int identity(1,1) primary key,
bookName varchar(40) not null,
price int not null,
email varchar(100) not null,
booksOrdered int not null
)

select * from admin
select * from books
select * from cart
select * from wishlist
select * from users
select * from orders