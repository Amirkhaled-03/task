
-- ========================= get by id ===============================

create procedure SP_GetEmployeeData @EmployeeId int
as
-- Open the symmetric key for decryption
OPEN SYMMETRIC KEY EmployeeSymmetricKey
DECRYPTION BY CERTIFICATE EmployeeDataCertificate;

-- Fetch employee data with decrypted fields and associated details
SELECT 
    e.EmployeeID,
    CONVERT(NVARCHAR(MAX), DECRYPTBYKEY(e.Name)) AS Name,
    e.Position,
    e.Department,
    CONVERT(NVARCHAR(MAX), DECRYPTBYKEY(e.Salary)) AS Salary,
    e.CreatedDate,
    ed.Project,
    ed.Address,
    ed.StartDate,
    ed.EndDate
FROM Employees e
JOIN EmployeeDetails ed ON e.EmployeeID = ed.EmployeeID
where e.EmployeeID = @EmployeeId;

-- Close the symmetric key
CLOSE SYMMETRIC KEY EmployeeSymmetricKey;


-- ======================== get all ===================================

create procedure SP_GetEmployeesData
as
-- Open the symmetric key for decryption
OPEN SYMMETRIC KEY EmployeeSymmetricKey
DECRYPTION BY CERTIFICATE EmployeeDataCertificate;

-- Fetch employee data with decrypted fields and associated details
SELECT 
    e.EmployeeID,
    CONVERT(NVARCHAR(MAX), DECRYPTBYKEY(e.Name)) AS Name,
    e.Position,
    e.Department,
    CONVERT(NVARCHAR(MAX), DECRYPTBYKEY(e.Salary)) AS Salary,
    e.CreatedDate,
    ed.Project,
    ed.Address,
    ed.StartDate,
    ed.EndDate
FROM Employees e
JOIN EmployeeDetails ed ON e.EmployeeID = ed.EmployeeID
order by e.EmployeeID desc
-- Close the symmetric key
CLOSE SYMMETRIC KEY EmployeeSymmetricKey;

--========================= add =====================================

create procedure SP_AddEmployeesData 
		@Name nvarchar(100),@Position NVARCHAR(100),@Department NVARCHAR(100), @Salary NVARCHAR(MAX),
		@Project NVARCHAR(200), @Address NVARCHAR(300), @StartDate DATE, @EndDate DATE
as
BEGIN TRANSACTION;

-- Open the symmetric key to encrypt data
OPEN SYMMETRIC KEY EmployeeSymmetricKey
DECRYPTION BY CERTIFICATE EmployeeDataCertificate;

BEGIN TRY
    DECLARE @EmployeeID INT;
    INSERT INTO Employees (Name, Position, Department, Salary)
    VALUES (
        ENCRYPTBYKEY(KEY_GUID('EmployeeSymmetricKey'), CAST(@Name AS NVARCHAR(MAX))),
        @Position,
        @Department,
        ENCRYPTBYKEY(KEY_GUID('EmployeeSymmetricKey'), CAST(@Salary AS NVARCHAR(50)))
    );

    SET @EmployeeID = SCOPE_IDENTITY();

    INSERT INTO EmployeeDetails (EmployeeID, Project, Address, StartDate, EndDate)
    VALUES (
        @EmployeeID,
        @Project,
        @Address,
        @StartDate,
        @EndDate
    );

    -- Commit the transaction
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    -- Rollback the transaction if any error occurs
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

-- Close the symmetric key
CLOSE SYMMETRIC KEY EmployeeSymmetricKey;

--======================= edit ====================

create procedure SP_EditEmployeeDeta @employeeId int,
    @Name nvarchar(100),@Position NVARCHAR(100),@Department NVARCHAR(100), @Salary NVARCHAR(MAX),
	@Project NVARCHAR(200), @Address NVARCHAR(300), @StartDate DATE, @EndDate DATE
as 
BEGIN TRANSACTION;

OPEN SYMMETRIC KEY EmployeeSymmetricKey
DECRYPTION BY CERTIFICATE EmployeeDataCertificate;

BEGIN TRY
update Employees 
set
  Name = ENCRYPTBYKEY(KEY_GUID('EmployeeSymmetricKey'), CAST(@Name AS NVARCHAR(MAX))),
  Position =  @Position,
  Department =    @Department,
  Salary =   ENCRYPTBYKEY(KEY_GUID('EmployeeSymmetricKey'), CAST(@Salary AS NVARCHAR(50)))
  where EmployeeID = @employeeId;

  update EmployeeDetails 
  set 
     Project =  @Project,
     Address =  @Address,
     StartDate =   @StartDate,
     EndDate= @EndDate
	 where EmployeeID = @employeeId;

	   -- Commit the transaction
    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    -- Rollback the transaction if any error occurs
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

-- Close the symmetric key
CLOSE SYMMETRIC KEY EmployeeSymmetricKey;

--================================== delete =========================

create procedure SP_DeleteEmployeeData @EmployeeId int
as
BEGIN TRANSACTION;

OPEN SYMMETRIC KEY EmployeeSymmetricKey
DECRYPTION BY CERTIFICATE EmployeeDataCertificate;

BEGIN TRY
  DELETE FROM Employees WHERE EmployeeID = @EmployeeId;
     COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    -- Rollback the transaction if any error occurs
    ROLLBACK TRANSACTION;
    THROW;
END CATCH;

-- Close the symmetric key
CLOSE SYMMETRIC KEY EmployeeSymmetricKey;


-- get by id
SP_GetEmployeeData 2

-- get all desc
SP_GetEmployeesData 

SP_AddEmployeesData 'amir mohamed','Software engineer','Development','1200',
'Project E-learning','Maadi','2024-03-10','2024-08-10'

SP_EditEmployeeDeta 1 ,'amir mohamed','web developer','Development','1200',
'Project E-learning','Maadi','2024-03-10','2024-08-10'

SP_DeleteEmployeeData 2


SELECT * FROM sys.symmetric_keys WHERE name = 'EmployeeSymmetricKey';


SELECT * FROM sys.certificates WHERE name = 'EmployeeDataCertificate';

