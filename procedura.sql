CREATE PROCEDURE PromoteStudents @Studies NVARCHAR(100), @Semester INT
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRANSACTION;
	
	DECLARE @IdEnrollment INT = (SELECT IdEnrollment FROM Enrollment WHERE Semester=@Semester+1 AND IdStudy=@IdStudies);
	IF @IdEnrollment IS NULL
	BEGIN
		SET @IdEnrollment = (SELECT MAX(IdEnrollment) FROM Enrollment) + 1;
		INSERT INTO Enrollment(IdEnrollment, Semester, IdStudy, StartDate) VALUES (@IdEnrollment, (@Semester+1), @IdStudies, GETDATE());
	END
	
	UPDATE Student SET IdEnrollment=@IdEnrollment 
	FROM ((Student INNER JOIN Enrollment ON Student.IdEnrollment = Enrollment.IdEnrollment) INNER JOIN Studies ON Enrollment.IdStudy = Studies.IdStudy)
	WHERE Enrollment.Semester=@Semester AND Studies.Name=@Studies;
	
	COMMIT;
	
	RETURN @IdEnrollment;
END;