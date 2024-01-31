IF EXISTS(SELECT 1 FROM sys.databases WHERE name = 'school')
BEGIN
  USE school;
END
GO

create table teacher(
  id        uniqueidentifier default newid()  not null,
  name      varchar(250)                     not null
)
go

create procedure teacher_insert
  @name varchar(250)
as
begin
  declare @id uniqueidentifier = newid()

  insert into teacher(id, name)
  values(@id, @name)

  select id as Id, name as Name
  from teacher
  where id = @id
  for json auto, without_array_wrapper
end
go

insert into teacher(name) values('John')
insert into teacher(name) values('Mary')
insert into teacher(name) values('Peter')
insert into teacher(name) values('Paul')
insert into teacher(name) values('James')
insert into teacher(name) values('Jude')
insert into teacher(name) values('Simon')
insert into teacher(name) values('Thomas')
insert into teacher(name) values('Andrew')
insert into teacher(name) values('Philip')
insert into teacher(name) values('Bartholomew')
insert into teacher(name) values('Matthew')
insert into teacher(name) values('Thaddaeus')
insert into teacher(name) values('Matthias')
insert into teacher(name) values('Mark')
