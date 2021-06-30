use bookstore
select * from users
select * from cart

create proc [dbo].[RegisterUser]
@email varchar(100),
@password varchar(40)
as
begin
begin try

insert into users (email, password) values
(
@email,@password
)
end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO




create proc [dbo].[RegisterUser]
@email varchar(100),
@password varchar(40)
as
begin
begin try

Declare @Encrypt varbinary(200)  
Select @Encrypt = EncryptByPassPhrase(@email, @password ) 

insert into users (email, password) values
(
@email,@Encrypt
)
end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO



create proc [dbo].[LoginUser]
@email varchar(100),
@password varchar(40)
as
begin
begin try

DECLARE @result int = 0;
Declare @Encrypt varbinary(200)
Select @Encrypt = EncryptByPassPhrase(@email, @password )


if((Select convert(varchar(100),DecryptByPassPhrase(@email,(select password from users where email = @email) ))) = @password)
begin
	set @result = 1;
	print @result;
	return @result;
end

end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO







create proc [dbo].[AddToCart]
@email varchar(100),
@quantity int,
@userId int,
@bookId int
as
begin
begin try
insert into cart (email, quantity, userId, bookId) values
(
@email,@quantity,@userId,@bookId
)
end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO




create proc [dbo].[AddToWishList]
@email varchar(100),
@price int,
@userId int,
@bookId int
as
begin
begin try
insert into wishlist(email, price, userId, bookId) values
(
@email,@price,@userId,@bookId
)
end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO




create proc [dbo].[spGetCartBooks]
@email varchar(100)
as
begin
begin try

select * from cart inner join users on users.email = @email

end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO







create proc [dbo].[spCheckout]
@email varchar(100)
as
begin
begin try

delete from cart where email = @email;

end try
begin catch
print('Raised the caught error');
throw;
end catch
end
GO



