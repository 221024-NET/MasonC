CREATE PROCEDURE dbo.GetStudentFname
            @Fname varchar(255)
        AS
        BEGIN
            SET NOCOUNT ON;
            select * from Student where Fname like @Fname +'%'
        END
GO