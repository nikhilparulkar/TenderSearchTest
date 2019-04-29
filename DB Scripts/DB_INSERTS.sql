INSERT INTO [User] (Email,Passwd) VALUES
('a@gmail.com','1234'),
('b@gmail.com','1234'),
('c@gmail.com','1234')
GO

insert into [TenderDetails] ([UserID],
[ReferenceNumber],[Name],[ReleaseDate],[ClosingDate])
Values
(1,0001,'tender1','12-mar-2019','13-mar-2019'),
(1,0002,'tender2','12-mar-2019','13-mar-2019'),
(2,0003,'tender1','12-mar-2019','13-mar-2019'),
(3,0004,'tender4','12-mar-2019','13-mar-2019')
