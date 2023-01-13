CREATE PROCEDURE dbo.GetStudentLname
            @Lname varchar(255)
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Student where Lname like @Lname +'%'
        END
GO