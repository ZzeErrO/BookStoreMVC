use bookstore
select * from cart
select * from books
select * from users
select * from orders

alter table users
drop column password

alter table users
add password varbinary(200)

delete from users where userId = 7

delete from cart where userId = 1
delete from cart where userId = 2

insert into cart (email, quantity, price, userId, bookId) values
(
'string@example.com',1,13220,5,2
)

select * from (cart inner join books on cart.bookId = books.bookId) inner join users on users.email = cart.userId

select * from cart inner join users on cart.userId = users.userId where users.userId =2;

Declare @Encrypt varbinary(200)  
Select @Encrypt = EncryptByPassPhrase('string@example.com', 'String01@' )  
select @Encrypt as password

select password from users where email = 'string@example.com'

Select convert(varchar(100),DecryptByPassPhrase('string@example.com',@Encrypt )) as Decrypt

exec LoginUser @email='string@example.com', @password = 'String01';
