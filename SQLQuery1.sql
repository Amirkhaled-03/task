

CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'strong_master_key_pasword';

CREATE CERTIFICATE EmployeeDataCertificate
WITH SUBJECT = 'Certificate for encrypting employee data';

CREATE SYMMETRIC KEY EmployeeSymmetricKey
WITH ALGORITHM = AES_256
ENCRYPTION BY CERTIFICATE EmployeeDataCertificate;


CREATE TABLE Employees
(
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name VARBINARY(MAX), -- Encrypted Name
    Position NVARCHAR(100), -- Unencrypted field
    Department NVARCHAR(100), -- Unencrypted field
    Salary VARBINARY(MAX), -- Encrypted Salary
    CreatedDate DATETIME DEFAULT GETDATE() -- Unencrypted field
);

CREATE TABLE EmployeeDetails
(
    DetailID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID INT, 
    Project NVARCHAR(200),
    Address NVARCHAR(300), 
    StartDate DATE,
    EndDate DATE, 
    FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE
);

