
----------Create tables for database----------

CREATE TABLE Countries
(
	CountryID INT PRIMARY KEY,
	Name nvarchar(100) NOT NULL
);

CREATE TABLE People
(
	PersonID INT PRIMARY KEY IDENTITY(1, 1),
	NationalNumber NVARCHAR(15) NOT NULL UNIQUE,
	FirstName NVARCHAR(50) NOT NULL,
	SecondName NVARCHAR(50) NOT NULL,
	ThirdName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Gender BIT NOT NULL,
	DateOfBirth DATE NOT NULL,
	Age AS CAST(DATEDIFF(YEAR, DateOfBirth, GETDATE()) AS TINYINT),
	Address NVARCHAR(500) NOT NULL,
	Phone NVARCHAR(15) NOT NULL UNIQUE,
	Email NVARCHAR(320) NOT NULL UNIQUE,
	NationalityCountryID INT NOT NULL,
	ImagePath NVARCHAR(500) NULL,

	FOREIGN KEY (NationalityCountryID) REFERENCES Countries(CountryID)
);

CREATE TABLE Roles
(
	RoleID INT PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL UNIQUE,
	Permissions INT NOT NULL,
	Description NVARCHAR(255) NULL
);



CREATE TABLE Users
(
	UserID INT PRIMARY KEY IDENTITY(1, 1),
	PersonID INT NOT NULL UNIQUE,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	Password NVARCHAR(320) NOT NULL,
	RoleID INT NOT NULL,
	DateCreated DATETIME NOT NULL,
	IsActive BIT NOT NULL,

	FOREIGN KEY (PersonID) REFERENCES People(PersonID),
	FOREIGN KEY (RoleID) REFERENCES Roles(RoleID)
);

CREATE TABLE LoginRecords
(
	LoginRecordID INT PRIMARY KEY IDENTITY(1, 1),
	UserID INT NOT NULL,
	LoginTime DATETIME NOT NULL,
	LoginStatus BIT NOT NULL,
	FailureReason NVARCHAR(100) NULL,

	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE LicenseClasses
(
	LicenseClassID INT PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL UNIQUE,
	MinimumAllowedAge TINYINT NOT NULL,
	DefaultValidityLength TINYINT NOT NULL,
	Fees SMALLINT NOT NULL,
);

CREATE TABLE ApplicationStatuses
(
	ApplicationStatusID INT PRIMARY KEY,
	Title NVARCHAR(15) NOT NULL UNIQUE
);

CREATE TABLE ApplicationTypes
(
	ApplicationTypeID INT PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL UNIQUE,
	Fees SMALLINT NOT NULL
);

CREATE TABLE Applications
(
	ApplicationID INT PRIMARY KEY IDENTITY(1, 1),
	ApplicantPersonID INT NOT NULL,
	ApplicationDate DATETIME NOT NULL,
	ApplicationTypeID INT NOT NULL,
	PaidFees SMALLINT NOT NULL,
	LastStatusDate DATETIME NOT NULL,
	StatusID INT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicantPersonID) REFERENCES People(PersonID),
	FOREIGN KEY (ApplicationTypeID) REFERENCES ApplicationTypes(ApplicationTypeID),
	FOREIGN KEY (StatusID) REFERENCES ApplicationStatuses(ApplicationStatusID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
);


CREATE TABLE LocalDrivingLicenseApplications
(
	LocalDrivingLicenseApplicationID INT PRIMARY KEY IDENTITY(1, 1),
	ApplicationID INT NOT NULL UNIQUE,
	LicenseClassID INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
	FOREIGN KEY (LicenseClassID) REFERENCES LicenseClasses(LicenseClassID)
);

CREATE TABLE TestTypes
(
	TestTypeID INT PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL UNIQUE,
	Description NVARCHAR(500) NOT NULL,
	Fees SMALLINT NOT NULL
);

CREATE TABLE TestAppointments
(
	TestAppointmentID INT PRIMARY KEY IDENTITY(1, 1),
	TestTypeID INT NOT NULL,
	LocalDrivingLicenseApplicationID INT NOT NULL,
	AppointmentDate DATETIME NOT NULL,
	CreatedByUserID INT NOT NULL,
	IsLocked BIT NOT NULL,

	FOREIGN KEY (TestTypeID) REFERENCES TestTypes(TestTypeID),
	FOREIGN KEY (LocalDrivingLicenseApplicationID) REFERENCES LocalDrivingLicenseApplications(LocalDrivingLicenseApplicationID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
)

CREATE TABLE Tests
(
	TestID INT PRIMARY KEY IDENTITY(1, 1),
	TestAppointmentID INT NOT NULL UNIQUE,
	Result BIT NOT NULL,
	Notes NVARCHAR(MAX) NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (TestAppointmentID) REFERENCES TestAppointments(TestAppointmentID)
)

CREATE TABLE Drivers
(
	DriverID INT PRIMARY KEY IDENTITY(1, 1),
	PersonID INT NOT NULL UNIQUE,
	CreatedDate DATETIME NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (PersonID) REFERENCES People(PersonID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
)

CREATE TABLE Licenses
(
	LicenseID INT PRIMARY KEY IDENTITY(1, 1),
	ApplicationID INT NOT NULL UNIQUE,
	DriverID INT NOT NULL,
	LicenseClassID INT NOT NULL,
	Notes NVARCHAR(MAX) NULL,
	IssueDate DATE NOT NULL,
	ExpireDate DATE NOT NULL,
	PaidFees SMALLINT NOT NULL,
	IsActive BIT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
	FOREIGN KEY (DriverID) REFERENCES Drivers(DriverID),
	FOREIGN KEY (LicenseClassID) REFERENCES LicenseClasses(LicenseClassID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
)

CREATE TABLE InternationalLicenses
(
	InternationalLicenseID INT PRIMARY KEY IDENTITY(1, 1),
	ApplicationID INT NOT NULL UNIQUE,
	IssuedUsingLocalLicenseID INT NOT NULL,
	IssueDate DATE NOT NULL,
	ExpireDate DATE NOT NULL,
	IsActive BIT NOT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (ApplicationID) REFERENCES Applications(ApplicationID),
    FOREIGN KEY (IssuedUsingLocalLicenseID) REFERENCES Licenses(LicenseID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
)


CREATE TABLE DetainedLicenses
(
	DetainID INT PRIMARY KEY IDENTITY(1, 1),
	LicenseID INT NOT NULL,
	DetainDate DATETIME NOT NULL,
	FineFees SMALLINT NOT NULL,
	IsReleased BIT NOT NULL,
	ReleaseDate DATETIME NULL,
	ReleaseApplicationID INT NULL,
	ReleasedByUserID INT NULL,
	CreatedByUserID INT NOT NULL,

	FOREIGN KEY (LicenseID) REFERENCES Licenses(LicenseID),
	FOREIGN KEY (ReleaseApplicationID) REFERENCES Applications(ApplicationID),
	FOREIGN KEY (ReleasedByUserID) REFERENCES Users(UserID),
	FOREIGN KEY (CreatedByUserID) REFERENCES Users(UserID)
)

CREATE TABLE Keys
(
	KeyID INT PRIMARY KEY,
	Name NVARCHAR(15) NOT NULL UNIQUE,
	DecryptionKey NVARCHAR(33) NOT NULL
)

Create TABLE UserSettings
(
	Title NVARCHAR(25) PRIMARY KEY,
	UserID INT NULL,
	Permissions INT NULL

	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)

CREATE TABLE InternationalLicenseSettings
(
	InternationalLicenseSettingsID INT PRIMARY KEY,
	DefaultValidityLength TINYINT NOT NULL,
)

CREATE TABLE Fees
(
	FeesID INT PRIMARY KEY,
	Title NVARCHAR(50) NOT NULL UNIQUE,
	Value SMALLINT NULL
)

----------CheckConstraint----------

ALTER TABLE People
ADD CONSTRAINT CHK_Age CHECK (DATEDIFF(YEAR, DateOfBirth, GETDATE()) >= 18);

ALTER TABLE DetainedLicenses
ADD CONSTRAINT CHK_FineFees CHECK (FineFees > 0);


----------Stored Procedures----------

CREATE PROCEDURE SP_GetPeopleInfoPerPage
	@PageNumber SMALLINT,
	@RowsPerPage SMALLINT
AS
BEGIN	
	SELECT * FROM VIEW_PeopleList
	ORDER BY 'Person ID'
	OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
	FETCH NEXT @RowsPerPage ROWS ONLY
END
--------

CREATE PROCEDURE SP_GetPeopleInfoPerPageWithFilter
	@PageNumber SMALLINT,
	@RowsPerPage SMALLINT,
	@FilterAttribute NVARCHAR(15),
	@Filter NVARCHAR(50)
AS
BEGIN	
	DECLARE @SQL NVARCHAR(MAX);

	SET @SQL = 'SELECT * FROM VIEW_PeopleList WHERE ' + QUOTENAME(@FilterAttribute);

	IF (@FilterAttribute = 'Person ID')
	BEGIN		
		SET @SQL = @SQL + ' = ' + @Filter
	END
	ELSE
	BEGIN
		IF (@FilterAttribute = 'National No.')
		BEGIN
			SET @SQL = @SQL + ' LIKE ''' + @Filter + ''''
		END
		ELSE
		BEGIN
			SET @SQL = @SQL + ' LIKE ''' + @Filter + '%'''
		END
	END
	
	SET @SQL = @SQL + ' ORDER BY ' + QUOTENAME('Person ID') + 
					' OFFSET ' + CAST((@PageNumber - 1) * @RowsPerPage AS NVARCHAR) +
					' ROWS FETCH NEXT ' + CAST(@RowsPerPage  AS NVARCHAR) + ' ROWS ONLY';
	EXEC sp_executesql @SQL
END
---------

CREATE PROCEDURE SP_CheckIfPersonAppliedForLicenseClass
	@PersonID INT,
	@LicenseClassID INT
AS
IF EXISTS 
(
SELECT Found = 1
FROM LocalDrivingLicenseApplications
INNER JOIN Applications
ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
WHERE LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID AND Applications.ApplicantPersonID = @PersonID 
AND Applications.StatusID != -1 --Cancelled application
)
BEGIN 
	RETURN 1;
END
ELSE
BEGIN
	RETURN 0;
END

--------

CREATE PROCEDURE SP_GetApplicationTypeFees
	@ApplicationTypeID INT,
	@Fees SMALLINT OUTPUT
AS 
BEGIN 
	SELECT @Fees = Fees FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID;
END
--------

CREATE PROCEDURE SP_GetCurrentUserFullName
	@FullName NVARCHAR(101) OUTPUT
AS
BEGIN
	SELECT @FullName = (FirstName + ' ' + LastName)
	FROM UserSettings 
	INNER JOIN Users
	ON Users.UserID = UserSettings.UserID
	INNER JOIN People
	ON People.PersonID = Users.PersonID
	WHERE UserSettings.Title = 'Current User'	
END
---------

CREATE PROCEDURE SP_DeleteLocalDrivingLicenseApplication
	@LocalDrivingLicenseApplicationID INT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			DECLARE @ApplicationID INT

			SELECT @ApplicationID = LocalDrivingLicenseApplications.ApplicationID
			FROM LocalDrivingLicenseApplications
			WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID

			--Delete L.D.L application
			DELETE FROM LocalDrivingLicenseApplications 
			WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID

			IF(@@ROWCOUNT = 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END

			--Delete application related first
			DELETE FROM Applications 
			WHERE ApplicationID = @ApplicationID AND StatusID = 0 --New	Application
			
			IF(@@ROWCOUNT = 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END

			--Commit changes
			COMMIT;

		END TRY

		BEGIN CATCH			
			ROLLBACK;
		END CATCH
END
----------

CREATE PROCEDURE SP_CancelApplication
@ApplicationID INT
AS
BEGIN
	IF EXISTS (SELECT Found = 1 FROM Applications 
	WHERE ApplicationID = @ApplicationID AND StatusID = 0) -- Check if new application
	BEGIN
		UPDATE Applications SET LastStatusDate = GETDATE(), StatusID = -1 -- Cancelled application
		WHERE ApplicationID = @ApplicationID
	END
END
-----------

CREATE PROCEDURE SP_CancelApplicationByLocalDrivingLicenseApplicationID
	@LocalDrivingLicenseApplicationID INT
AS
BEGIN 
	DECLARE @AppID INT

	SELECT @AppID = LocalDrivingLicenseApplications.ApplicationID FROM LocalDrivingLicenseApplications 
	WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
	
	IF (@AppID IS NOT NULL)
	BEGIN
		EXEC SP_CancelApplication @ApplicationID = @AppID
	END
END
-----------

CREATE PROCEDURE SP_CompleteApplication
@ApplicationID INT
AS
BEGIN
	IF EXISTS (SELECT Found = 1 FROM Applications 
	WHERE ApplicationID = @ApplicationID AND StatusID = 0) -- Check if new application
	BEGIN
		UPDATE Applications SET LastStatusDate = GETDATE(), StatusID = 1 -- Completed application
		WHERE ApplicationID = @ApplicationID
	END
END
-----------


CREATE PROCEDURE SP_GetLoginRecordsList
AS
BEGIN
	SELECT 
		LoginRecords.LoginRecordID AS 'Login Record ID', 
		LoginRecords.UserID AS 'User ID',
		Roles.Title AS 'User Role',
		FORMAT(CONVERT(DATETIME, LoginRecords.LoginTime, 103), 'MM/dd/yyyy hh:mm:ss tt') AS 'Login Time',
		CASE LoginRecords.LoginStatus
			WHEN 1 THEN 'Success'
			ELSE 'Failed'
		END AS 'Login Status',
		CASE 
			WHEN FailureReason IS NOT NULL THEN FailureReason
			ELSE 'N/A'
		END AS 'Failure Reason'
	FROM LoginRecords
	INNER JOIN Users
	ON Users.UserID = LoginRecords.UserID
	INNER JOIN Roles
	ON Roles.RoleID = Users.RoleID
	ORDER BY [Login Record ID] DESC
END
-----------

CREATE PROCEDURE SP_AddNewDriver
	@PersonID INT
AS
BEGIN
	DECLARE @UserID INT
	SELECT @UserID = dbo.GetCurrentUser();

	INSERT INTO Drivers (PersonID, CreatedDate, CreatedByUserID)
	VALUES (@PersonID, GETDATE(), @UserID)
	SELECT SCOPE_IDENTITY();
END
-----------

CREATE PROCEDURE SP_AddNewLincense
	@ApplicationID INT,
	@DriverID INT,
	@Notes NVARCHAR(MAX)
AS
BEGIN
	
	DECLARE @LicenseClassID INT
	DECLARE @DefaultValidityLength TINYINT
	DECLARE @Fees SMALLINT
	DECLARE @UserID INT
	SELECT @UserID = dbo.GetCurrentUser();

	SELECT @LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID, @DefaultValidityLength = LicenseClasses.DefaultValidityLength, @Fees = LicenseClasses.Fees 
	FROM LocalDrivingLicenseApplications 
	INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID
	WHERE ApplicationID = @ApplicationID


	INSERT INTO Licenses (ApplicationID, DriverID, LicenseClassID, Notes, IssueDate, ExpireDate, PaidFees, IsActive, CreatedByUserID)
	VALUES (@ApplicationID, @DriverID, @LicenseClassID, @Notes, GETDATE(), DATEADD(YEAR, @DefaultValidityLength, GETDATE()), @Fees, 1, @UserID)
	SELECT SCOPE_IDENTITY();
END
-----------

CREATE PROCEDURE SP_GetLicenseByLocalDrivingLicenseApplicationID
	@LocalDrivingLicenseApplicationID INT
AS
BEGIN
	DECLARE @ApplicationID INT

	SELECT @ApplicationID = LocalDrivingLicenseApplications.ApplicationID
	FROM  LocalDrivingLicenseApplications WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID

	SELECT * FROM Licenses WHERE ApplicationID = @ApplicationID
END
-----------

CREATE PROCEDURE SP_IsLicenseDetained
	@LicenseID INT
AS
IF EXISTS (SELECT 1 FROM DetainedLicenses WHERE LicenseID = @LicenseID AND IsReleased = 0)
	BEGIN
		SELECT 1
		RETURN
	END
	SELECT 0
END
-----------

CREATE PROCEDURE SP_CanIssueInternationalLicense
	@LicenseID INT
AS
BEGIN
	-- 0 => cant issue  Reason => license is not active or is not class 3 license
	-- 1 => can issue
	-- 2 => cant issue  Reason => license has an active international license           
	IF EXISTS 
	(
	SELECT 1 FROM InternationalLicenses 
	WHERE InternationalLicenses.IsActive = 1 
	AND InternationalLicenses.IssuedUsingLocalLicenseID = @LicenseID
	)
	BEGIN
		SELECT 2;
		RETURN;
	END

	DECLARE @IsActive BIT
	DECLARE @LicenseClassID INT

	SELECT @IsActive = Licenses.IsActive, @LicenseClassID = Licenses.LicenseClassID
	FROM Licenses WHERE LicenseID = @LicenseID

	IF (@IsActive = 0 OR @LicenseClassID != 3)
	BEGIN
		SELECT 0;
		RETURN;
	END
	SELECT 1;
END
------------

CREATE PROCEDURE SP_AddNewInternationalLicenseApplication
	@ApplicantPersonID INT,
	@ApplicationID INT OUT
AS
BEGIN
	DECLARE @PaidFees INT
	DECLARE @UserID INT
	SELECT @PaidFees = dbo.GetApplicationTypeFees(6)
	SELECT @UserID = dbo.GetCurrentUser()

	INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, PaidFees, LastStatusDate, StatusID, CreatedByUserID)
	VALUES (@ApplicantPersonID, GETDATE(), 6, @PaidFees, GETDATE(), 1, @UserID)

	SELECT @ApplicationID = SCOPE_IDENTITY()
END
-----------

CREATE PROCEDURE SP_AddNewInternationalLicense
	@LicenseID INT,
	@ApplicationID INT,
	@InternationalLicenseID INT OUTPUT
AS
BEGIN
	DECLARE @ValidityLength TINYINT
	DECLARE @UserID INT 
	SELECT @ValidityLength = dbo.GetInternationalLicenseValidityLength()
	SELECT @UserID = dbo.GetCurrentUser()

	INSERT INTO InternationalLicenses (ApplicationID, IssuedUsingLocalLicenseID, IssueDate, ExpireDate, IsActive, CreatedByUserID)
	VALUES (@ApplicationID, @LicenseID, GETDATE(), DATEADD(YEAR, @ValidityLength, GETDATE()), 1, @UserID)
	SELECT @InternationalLicenseID = SCOPE_IDENTITY()
END
---------

CREATE PROCEDURE SP_AddNewInternationalLicenseTransaction
	@LocalLicenseID INT,
	@InternationalLicenseID INT OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			DECLARE @PersonID INT 
			DECLARE @NewApplicationID INT

			--Adding new application first
			SELECT @PersonID = dbo.GetPersonIDByLicenseID(@LocalLicenseID)
			EXEC SP_AddNewInternationalLicenseApplication @ApplicantPersonID = @PersonID, @ApplicationID = @NewApplicationID OUTPUT

			IF(@@ROWCOUNT = 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END

			--Adding new international license then
			EXEC SP_AddNewInternationalLicense @LicenseID = @LocalLicenseID, @ApplicationID = @NewApplicationID
			, @InternationalLicenseID = @InternationalLicenseID OUTPUT

			IF(@@ROWCOUNT = 0)
			BEGIN
				ROLLBACK;
				RETURN;
			END

			--Commit changes
			COMMIT;
		END TRY

		BEGIN CATCH			
			ROLLBACK;
		END CATCH	
END
--------------

CREATE PROCEDURE SP_GetDriverLocalLicenses
	@DriverID INT
AS
BEGIN
	SELECT 
		Licenses.LicenseID AS [Lic.ID],
		Licenses.ApplicationID AS [App.ID],
		LicenseClasses.Title AS [Class Name],
		Licenses.IssueDate AS [Issue Date],
		Licenses.ExpireDate AS [Expiration Date],
		Licenses.IsActive AS [Is Active]
	FROM Licenses
	INNER JOIN LicenseClasses ON LicenseClasses.LicenseClassID = Licenses.LicenseClassID
	WHERE Licenses.DriverID = @DriverID
END
-----------

CREATE PROCEDURE SP_GetDriverInternationalLicenses
	@DriverID INT
AS
BEGIN
	SELECT 
		InternationalLicenses.InternationalLicenseID AS [Int.License ID],
		InternationalLicenses.ApplicationID AS [Application ID],
		InternationalLicenses.IssuedUsingLocalLicenseID AS [L.License ID],
		InternationalLicenses.IssueDate AS [Issue Date],
		InternationalLicenses.ExpireDate AS [Expiration Date],
		InternationalLicenses.IsActive AS [Is Active]
	FROM InternationalLicenses
	INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
	WHERE Licenses.DriverID = @DriverID
END
-------------

CREATE PROCEDURE SP_RefreshAllLicensesToCheckActivation
AS
BEGIN
	--Check local licenses
	UPDATE Licenses 
	SET Licenses.IsActive = 0
	WHERE Licenses.ExpireDate < GETDATE() AND Licenses.IsActive = 1

	--Check international licenses 
	UPDATE InternationalLicenses 
	SET InternationalLicenses.IsActive = 0
	WHERE InternationalLicenses.ExpireDate < GETDATE() AND InternationalLicenses.IsActive = 1
END
------------

CREATE PROCEDURE SP_CheckIfDriverLicenseRenewable
	@LicenseID INT
AS
BEGIN
	DECLARE @LicenseClassID INT
	DECLARE @DriverID INT 
	DECLARE @LatestDriverLicenseID INT
	DECLARE @IsActive BIT

	--Get driver ID and license ID
	SELECT 
		@LicenseClassID = Licenses.LicenseClassID,
		@DriverID = Licenses.DriverID,
		@IsActive = Licenses.IsActive
	FROM Licenses
	WHERE Licenses.LicenseID = @LicenseID
	
	-- Get latest driver license ID to check if the license selected is the latest
	SELECT @LatestDriverLicenseID = dbo.GetLatestDriverLicenseID(@DriverID, @LicenseClassID)

	IF (@LatestDriverLicenseID != @LicenseID)
	BEGIN
		--The driver can't renew his license because it is not latest license he has
		SELECT 1
		RETURN
	END
	
	IF (@IsActive = 1)
	BEGIN
		----The driver can't renew his license because the license is already active
		SELECT 2
		RETURN
	END

	--The driver can renew his license
	SELECT 3
END
-------------

CREATE PROCEDURE SP_AddNewApplication
	@ApplicantPersonID INT,
	@ApplicationTypeId INT,
	@NewApplicationID INT OUTPUT
AS
BEGIN
	DECLARE @PaidFees SMALLINT 
	DECLARE @StatusID INT
	DECLARE @CreatedByUserID INT
 
	--Set fees
	EXEC SP_GetApplicationTypeFees 
	@ApplicationTypeID = @ApplicationTypeId,
	@Fees = @PaidFees OUTPUT

	--Set created by user ID
	SELECT @CreatedByUserID = dbo.GetCurrentUser()

	--Set status at new if the application is (add new license for first time)
	IF (@ApplicationTypeId = 1)
	BEGIN
		SET @StatusID = 0
	END

	--Set status at completed if the application is an other type
	ELSE
	BEGIN
		Set @StatusID = 1
	END

	INSERT INTO Applications (ApplicantPersonID, ApplicationDate, ApplicationTypeID, PaidFees, LastStatusDate, StatusID, CreatedByUserID)
	VALUES (@ApplicantPersonID, GETDATE(), @ApplicationTypeId, @PaidFees, GETDATE(), @StatusID, @CreatedByUserID)
	SELECT @NewApplicationID = SCOPE_IDENTITY()
END
-------------

CREATE PROCEDURE SP_AddNewDetainLicense
	@LicenseID INT,
	@FineFees SMALLINT,
	@NewDetainID INT OUTPUT
AS
BEGIN
	DECLARE @UserID INT

	SELECT @UserID = dbo.GetCurrentUser()

	INSERT INTO DetainedLicenses 
	(LicenseID, DetainDate, FineFees, IsReleased, ReleaseDate, ReleaseApplicationID, ReleasedByUserID, CreatedByUserID)
	VALUES (@LicenseID, GETDATE(), @FineFees, 0, NULL, NULL, NULL, @UserID)
	SELECT @NewDetainID = SCOPE_IDENTITY()
END
------------

CREATE PROCEDURE SP_ReleaseDetainedLicense
	@DetainID INT,
	@IsReleased BIT OUTPUT,
	@ReleaseApplicationID INT OUTPUT
AS
BEGIN
	BEGIN TRANSACTION
		BEGIN TRY
			
			SET @IsReleased = 0
			SET @ReleaseApplicationID = NULL

			DECLARE @PersonID INT
			DECLARE @UserID INT 

			SELECT @PersonID = dbo.GetPersonIDByDetainID(@DetainID)

			--Adding new application first
			EXEC SP_AddNewApplication
			@ApplicantPersonID = @PersonID, @ApplicationTypeID = 5
			, @NewApplicationID = @ReleaseApplicationID OUTPUT
			
			IF (@@ROWCOUNT = 0)
			BEGIN
				SET @ReleaseApplicationID = NULL
				ROLLBACK;
				RETURN;
			END

			SELECT @UserID = dbo.GetCurrentUser()

			--Release detained license
			UPDATE DetainedLicenses
			SET IsReleased = 1, ReleaseDate = GETDATE(), ReleaseApplicationID = @ReleaseApplicationID, ReleasedByUserID = @UserID 
			WHERE DetainID = @DetainID

			IF (@@ROWCOUNT = 0)
			BEGIN
				SET @ReleaseApplicationID = NULL
				ROLLBACK;
			    RETURN;
			END
			--Commit changes
			COMMIT
			SET @IsReleased = 1
		END TRY
		BEGIN CATCH
			ROLLBACK;
		END CATCH
END
-----------------

CREATE PROCEDURE SP_GetNonReleasedDetainedLicense
	@LicenseID INT
AS
BEGIN
	SELECT * FROM DetainedLicenses
	WHERE LicenseID = @LicenseID
	AND IsReleased = 0
END







----------------------------------------Functions----------------------------------------

CREATE FUNCTION dbo.GetPersonFullNameByApplicationID(@ApplicationID INT)
RETURNS NVARCHAR(203)
AS
BEGIN
	DECLARE @FullName NVARCHAR(203);
	SELECT @FullName = dbo.GetPersonFullName(Applications.ApplicantPersonID)
	FROM Applications
	WHERE Applications.ApplicationID = @ApplicationID
	RETURN @FullName
END
----------

CREATE FUNCTION GetPersonNationalNumberByApplicationID(@ApplicationID INT)
RETURNS NVARCHAR(15)
AS
BEGIN
	DECLARE @NationalNumber NVARCHAR(15);
	SELECT @NationalNumber = dbo.GetPersonNationalNumber(Applications.ApplicantPersonID)
	FROM Applications
	WHERE Applications.ApplicationID = @ApplicationID
	RETURN @NationalNumber
END
----------

CREATE FUNCTION GetPersonFullName(@PersonID INT)
RETURNS NVARCHAR(203)
AS
BEGIN
	DECLARE @FullName NVARCHAR(203);
	SELECT @FullName = (People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName)
	FROM People
	WHERE PersonID = @PersonID
	RETURN @FullName
END
----------

CREATE FUNCTION GetPersonNationalNumber(@PersonID INT)
RETURNS NVARCHAR(15)
AS
BEGIN
	DECLARE @NationalNumber NVARCHAR(15);
	SELECT @NationalNumber = People.NationalNumber
	FROM People
	WHERE PersonID = @PersonID
	RETURN @NationalNumber
END
----------

CREATE FUNCTION dbo.GetLocalDrivingLicenseApplicationPassedTests(@LocalDrivingLicenseApplicationID INT)
RETURNS TINYINT
AS
BEGIN
	DECLARE @PassedTests TINYINT
	
	SELECT @PassedTests = COUNT(*)
	FROM Tests
	INNER JOIN TestAppointments
	ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
	WHERE Tests.Result = 1 AND TestAppointments.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID

	RETURN @PassedTests
END
----------

CREATE FUNCTION GetTestAppointmentsByLDLAppAndTestType(@LDLAppID INT, @TestTypeID INT)
RETURNS TABLE
AS
RETURN 
(
	SELECT 
		TestAppointments.TestAppointmentID AS 'Appointment ID',
		TestAppointments.AppointmentDate AS 'Appointment Date',
		TestTypes.Fees AS 'Paid Fees',
		TestAppointments.IsLocked AS 'Is Locked'
	
	FROM TestAppointments
	INNER JOIN TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID
	WHERE TestAppointments.LocalDrivingLicenseApplicationID = @LDLAppID AND TestAppointments.TestTypeID = @TestTypeID
)
-----------

CREATE FUNCTION dbo.GetTestTypeFees(@TestTypeID INT)
RETURNS SMALLINT
AS
BEGIN
	DECLARE @Fees SMALLINT

	SELECT @Fees = TestTypes.Fees 
	FROM TestTypes WHERE TestTypeID = @TestTypeID
	
	RETURN @Fees
END
-----------

CREATE FUNCTION dbo.GetTestTrials(@TestTypeID INT, @LDLAppID INT)
RETURNS TINYINT
AS
BEGIN 
	DECLARE @Trials TINYINT

	SELECT @Trials = COUNT(1)
	FROM Tests
	INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	WHERE 
		TestAppointments.TestTypeID =	@TestTypeID 
		AND TestAppointments.LocalDrivingLicenseApplicationID = @LDLAppID
		AND Tests.Result = 0

	RETURN @Trials
END
-----------

CREATE FUNCTION dbo.CheckTestAppointmentAvailability(@LDLAppID INT, @TestTypeID INT)
RETURNS BIT
AS
BEGIN
	IF NOT EXISTS (
	SELECT 1 FROM TestAppointments 
	WHERE LocalDrivingLicenseApplicationID = @LDLAppID AND TestTypeID = @TestTypeID AND IsLocked = 0
	)
	AND NOT EXISTS 
	(
	SELECT 1 FROM TestAppointments 
	INNER JOIN Tests ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	WHERE LocalDrivingLicenseApplicationID = @LDLAppID AND TestTypeID = @TestTypeID AND Result = 1
	)
	BEGIN
		RETURN 1;
	END
	RETURN 0;
END
-----------

CREATE FUNCTION dbo.CheckIfRetakeTest(@TestAppointmentID INT, @LDLAppID INT, @TestTypeID INT)
RETURNS BIT
AS
BEGIN	
	DECLARE @FirstTestAppointmentID INT

	SELECT TOP 1 @FirstTestAppointmentID = Tests.TestAppointmentID FROM Tests
	INNER JOIN TestAppointments ON Tests.TestAppointmentID = TestAppointments.TestAppointmentID
	WHERE TestAppointments.TestTypeID =	@TestTypeID 
		AND TestAppointments.LocalDrivingLicenseApplicationID = @LDLAppID
	
	IF (@TestAppointmentID = @FirstTestAppointmentID)
	BEGIN
		RETURN 0
	END
	RETURN 1
END
-----------

CREATE FUNCTION dbo.GetCurrentUser()
RETURNS INT
AS
BEGIN
	DECLARE @UserID INT
	SELECT @UserID = UserSettings.UserID FROM UserSettings WHERE UserSettings.Title = 'Current User'
	RETURN @UserID
END
-----------

CREATE FUNCTION dbo.GetActiveLicenses(@DriverID INT)
RETURNS TINYINT
AS
BEGIN
	DECLARE @ActiveLicenses TINYINT
	SELECT @ActiveLicenses = COUNT(Licenses.LicenseID) 
	FROM Licenses
	WHERE Licenses.DriverID = @DriverID AND Licenses.IsActive = 1
	RETURN @ActiveLicenses
END
--------

CREATE FUNCTION dbo.GetInternationalLicenseValidityLength()
RETURNS TINYINT
AS
BEGIN
	DECLARE @ValidityLength TINYINT

	SELECT @ValidityLength = DefaultValidityLength 
	FROM InternationalLicenseSettings
	WHERE InternationalLicenseSettingsID = 1
	RETURN @ValidityLength
END
--------

CREATE FUNCTION dbo.GetPersonIDByLicenseID(@LicenseID INT)
RETURNS INT
AS
BEGIN
	DECLARE @PersonID INT

	SELECT @PersonID = Applications.ApplicantPersonID 
	FROM Licenses
	INNER JOIN Applications ON Applications.ApplicationID = Licenses.ApplicationID
	WHERE Licenses.LicenseID = @LicenseID

	RETURN @PersonID
END
----------

CREATE FUNCTION dbo.GetApplicationTypeFees(@ApplicationTypeID INT)
RETURNS SMALLINT
AS
BEGIN
	DECLARE @Fees SMALLINT

	SELECT @Fees = ApplicationTypes.Fees 
	FROM ApplicationTypes
	WHERE ApplicationTypes.ApplicationTypeID = @ApplicationTypeID
	RETURN @Fees
END
-----------

CREATE FUNCTION dbo.GetInternationalLicenseIDByLocalLicenseID(@LocalLicenseID INT)
RETURNS INT
AS
BEGIN
	DECLARE @InternationalLicenseID INT
	SELECT @InternationalLicenseID = InternationalLicenseID 
	FROM InternationalLicenses
	WHERE IssuedUsingLocalLicenseID = @LocalLicenseID AND IsActive = 1
	RETURN @InternationalLicenseID
END
----------

CREATE FUNCTION dbo.GetInternationalLicensesRecordsCountByDriverID(@DriverID INT)
RETURNS INT
AS
BEGIN
	DECLARE @LicensesCount INT

	SELECT @LicensesCount = COUNT(InternationalLicenseID) 
	FROM InternationalLicenses
	INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
	WHERE Licenses.DriverID = @DriverID

	RETURN @LicensesCount
END
-----------

CREATE FUNCTION dbo.GetLocalLicensesRecordsCountByDriverID(@DriverID INT)
RETURNS INT
AS
BEGIN
	DECLARE @LicensesCount INT

	SELECT @LicensesCount = COUNT(LicenseID) 
	FROM Licenses
	WHERE Licenses.DriverID = @DriverID

	RETURN @LicensesCount
END
-----------

CREATE FUNCTION dbo.GetLatestDriverLicenseID(@DriverID INT, @LicenseClassID INT)
RETURNS INT
AS
BEGIN
	DECLARE @LatestDriverLicenseID INT

	SELECT 
		TOP 1 @LatestDriverLicenseID = LicenseID 
	FROM Licenses
	WHERE DriverID = @DriverID AND LicenseClassID = @LicenseClassID
	ORDER BY Licenses.IssueDate DESC

	RETURN @LatestDriverLicenseID
END
------------

CREATE FUNCTION dbo.GetCurrentUserUsername()
RETURNS NVARCHAR(30)
AS
BEGIN
	DECLARE @Username NVARCHAR(30)

	SELECT @Username = Users.Username
	FROM UserSettings
	INNER JOIN Users ON Users.UserID = UserSettings.UserID
	WHERE UserSettings.Title = 'Current User'
	RETURN @Username
END
--------------

ALTER FUNCTION dbo.GetLicenseIDByLocalLicenseApplicationID(@LocalLicenseApplicationID INT)
RETURNS INT
AS
BEGIN
	DECLARE @LicenseID INT
	
	SELECT @LicenseID = Licenses.LicenseID
	FROM Licenses
	INNER JOIN Applications ON Applications.ApplicationID = Licenses.ApplicationID
	INNER JOIN LocalDrivingLicenseApplications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID
	WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalLicenseApplicationID

	RETURN @LicenseID
END
-------------

CREATE FUNCTION dbo.GetRetakeFees()
RETURNS SMALLINT
AS
BEGIN
	DECLARE @Fees SMALLINT
	SELECT @Fees = Value
	FROM Fees
	WHERE FeesID = 1
	RETURN @Fees
END
--------------

CREATE FUNCTION dbo.GetActiveClass3LocalLicenseByDriverID(@DriverID INT)
RETURNS INT
AS
BEGIN
	DECLARE @LicenseID INT
	SELECT @LicenseID = LicenseID
	FROM Licenses
	WHERE DriverID = @DriverID AND IsActive = 1 AND LicenseClassID = 3
	RETURN @LicenseID
END
--------------

CREATE FUNCTION dbo.IsLocalLicenseActive(@LicenseID INT)
RETURNS BIT
AS
BEGIN
	DECLARE @IsActive BIT

	SELECT @IsActive = Licenses.IsActive
	FROM Licenses
	WHERE LicenseID = @LicenseID
	RETURN @IsActive
END
---------------

CREATE FUNCTION dbo.GetPersonIDByDetainID(@DetainID INT)
RETURNS INT
AS
BEGIN
	DECLARE @PersonID INT
	SELECT @PersonID = Drivers.PersonID
	FROM DetainedLicenses
	INNER JOIN Licenses ON Licenses.LicenseID = DetainedLicenses.LicenseID
	INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
	WHERE DetainedLicenses.DetainID = @DetainID

	RETURN @PersonID
END
---------------

ALTER FUNCTION dbo.GetNationalNumberByLicenseID(@LicenseID INT)
RETURNS NVARCHAR(25)
AS
BEGIN
	DECLARE @NationalNumber NVARCHAR(25)
	SELECT 
		@NationalNumber = People.NationalNumber
	FROM Licenses
	INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
	INNER JOIN People ON People.PersonID = Drivers.PersonID
	WHERE Licenses.LicenseID = @LicenseID

	RETURN @NationalNumber
END
---------------

CREATE FUNCTION dbo.CanPersonApplyForLicense(@PersonID INT, @LicenseClassID INT)
RETURNS BIT
AS
BEGIN
	DECLARE @PersonAge TINYINT
	DECLARE @MinimumAllowedAge TINYINT

	SELECT @PersonAge = People.Age
	FROM People WHERE People.PersonID = @PersonID

	SELECT @MinimumAllowedAge = LicenseClasses.MinimumAllowedAge
	FROM LicenseClasses WHERE LicenseClasses.LicenseClassID = @LicenseClassID

	IF @PersonAge >= @MinimumAllowedAge
	BEGIN
		RETURN 1
	END
	RETURN 0
END
-------------------

CREATE FUNCTION dbo.GetTestAppointmentCountByLDLAppID(@LDLAppID INT)
RETURNS INT
AS
BEGIN
	DECLARE @TestAppointmentCount INT

	SELECT @TestAppointmentCount = COUNT(TestAppointmentID)
	FROM TestAppointments 
	WHERE LocalDrivingLicenseApplicationID = @LDLAppID

	RETURN @TestAppointmentCount
END







----------------------------------------INDEXES----------------------------------------

CREATE INDEX IDX_Name
ON Countries (Name)

CREATE INDEX IDX_NationalNumber
ON People (NationalNumber)

CREATE INDEX IDX_Username_Password
ON Users (Username, Password)

CREATE INDEX IDX_LicenseID
ON DetainedLicenses (LicenseID)

CREATE INDEX IDX_PersonID
ON Drivers (PersonID)

CREATE INDEX IDX_IssuedUsingLocalLicenseID
ON InternationalLicenses (IssuedUsingLocalLicenseID)

CREATE INDEX IDX_ApplicationID
ON Licenses (ApplicationID)

CREATE INDEX IDX_LicenseClassID
ON Licenses (LicenseClassID)

CREATE INDEX IDX_ApplicationID
ON LocalDrivingLicenseApplications (ApplicationID)

CREATE INDEX IDX_LicenseClassID
ON LocalDrivingLicenseApplications (LicenseClassID)

CREATE INDEX IDX_TestTypeID
ON TestAppointments (TestTypeID)

CREATE INDEX IDX_TestAppointmentID
ON Tests (TestAppointmentID)


CREATE INDEX IDX_Permissions
ON UserSettings (Permissions)


----------VIEWS----------

CREATE VIEW VIEW_PeopleList AS
SELECT PersonID AS 'Person ID', NationalNumber AS 'National No.', FirstName AS 'First Name', SecondName AS 'Second Name'
, ThirdName AS 'Third Name', LastName AS 'Last Name', 
CASE Gender
	WHEN 1	THEN 'Male'
	ELSE 'Female'
END AS Gender,
	DateOfBirth AS 'Date Of Birth', Countries.Name AS Nationality, Phone, Email
FROM People
INNER JOIN Countries
ON Countries.CountryID = People.NationalityCountryID
--------------

CREATE VIEW VIEW_UsersList AS
SELECT UserID AS 'User ID', Users.PersonID AS 'Person ID', 
(People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS 'Full Name',
Username, IsActive AS 'Is Active'
FROM Users
INNER JOIN People
ON People.PersonID = Users.PersonID
--------------

CREATE VIEW VIEW_LocalDrivingLicenseApplicationsList
AS
SELECT 
	LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID AS 'L.D.L.AppID',
	LicenseClasses.Title as 'Driving Class',
	dbo.GetPersonNationalNumber(Applications.ApplicantPersonID) AS 'National No.',
	dbo.GetPersonFullName(Applications.ApplicantPersonID) AS 'Full Name',
	FORMAT(CONVERT(DATETIME, Applications.ApplicationDate, 103), 'MM/dd/yyyy hh:mm tt') AS 'Application Date',
	dbo.GetLocalDrivingLicenseApplicationPassedTests(LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID) AS 'Passed Tests',
	ApplicationStatuses.Title AS 'Status'
FROM 
	LocalDrivingLicenseApplications	
inner JOIN
	Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
INNER JOIN 
	LicenseClasses ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID
INNER JOIN
	ApplicationStatuses ON ApplicationStatuses.ApplicationStatusID = Applications.StatusID
-------------

CREATE VIEW VIEW_DriversList
AS
(
SELECT
	Drivers.DriverID AS 'Driver ID',
	Drivers.PersonID AS 'Person ID',
	People.NationalNumber AS 'National No.',
	(People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName) AS 'Full Name',
	FORMAT(CONVERT(DATETIME, Drivers.CreatedDate, 103), 'MM/dd/yyyy hh:mm tt') AS Date,
	dbo.GetActiveLicenses(Drivers.DriverID) AS 'Active Licenses'

FROM Drivers
INNER JOIN People ON People.PersonID = Drivers.PersonID
)
------------

CREATE VIEW View_InternationalLicenses
AS
SELECT 
	InternationalLicenses.InternationalLicenseID AS [Int.License ID],
	InternationalLicenses.ApplicationID AS [Application ID],
	Licenses.DriverID AS [Driver ID],
	InternationalLicenses.IssuedUsingLocalLicenseID AS [L.License ID],
	InternationalLicenses.IssueDate AS [Issue Date],
	InternationalLicenses.ExpireDate AS [Expiration Date],
	InternationalLicenses.IsActive AS [Is Active]
FROM InternationalLicenses
INNER JOIN Licenses ON Licenses.LicenseID = InternationalLicenses.IssuedUsingLocalLicenseID
--------------

CREATE VIEW VIEW_DetainedLicensesList
AS
SELECT 
	DetainedLicenses.DetainID AS [D.ID],
	DetainedLicenses.LicenseID AS [L.ID],
	DetainedLicenses.DetainDate AS [D.Date],
	DetainedLicenses.IsReleased AS [Is Released],
	DetainedLicenses.FineFees AS [Fine Fees],
	DetainedLicenses.ReleaseDate AS [Release Date],
	People.NationalNumber AS [N.No.],
	dbo.GetPersonFullName(People.PersonID) AS [Full Name],
	DetainedLicenses.ReleaseApplicationID AS [Release App.ID]
FROM DetainedLicenses
INNER JOIN Licenses ON Licenses.LicenseID = DetainedLicenses.LicenseID
INNER JOIN Drivers ON Drivers.DriverID = Licenses.DriverID
INNER JOIN People ON People.PersonID = Drivers.PersonID







----------------------------------------TRIGGERS----------------------------------------

CREATE TRIGGER TRG_AfterInsertTest ON Tests
AFTER INSERT
AS
BEGIN
	DECLARE @TestAppointmentID INT
	SELECT @TestAppointmentID = TestAppointmentID FROM inserted 
	UPDATE TestAppointments SET IsLocked = 1 WHERE TestAppointmentID = @TestAppointmentID
END
---------

CREATE TRIGGER TRG_AfterInsertLicenseComplete ON Licenses
AFTER INSERT
AS
BEGIN
	DECLARE @ApplicationID INT

	SELECT @ApplicationID = inserted.ApplicationID 
	FROM inserted
	UPDATE Applications SET StatusID = 1 WHERE ApplicationID = @ApplicationID
END
------------

CREATE TRIGGER TRG_CheckLocalLicense ON InternationalLicenses
FOR INSERT
AS
BEGIN
	DECLARE @IsActive BIT
	DECLARE	@LicenseClassID INT

	SELECT @IsActive = Licenses.IsActive, @LicenseClassID = Licenses.LicenseClassID
	FROM inserted
	INNER JOIN Licenses ON Licenses.LicenseID = inserted.IssuedUsingLocalLicenseID
	--Only active ordinary driving license (Class 3) is alowed to make international license
	IF (@IsActive = 0 OR @LicenseClassID != 3)
	BEGIN
		ROLLBACK TRANSACTION
	END
END
-------------

CREATE TRIGGER TRG_DeactivateOldLicenseAfterInsert ON Licenses
AFTER INSERT
AS
BEGIN
	DECLARE @DriverID INT
	DECLARE @LicenseClassID INT
	DECLARE @LicenseID INT

	SELECT
		@LicenseID = LicenseID,
		@DriverID = DriverID,
		@LicenseClassID = LicenseClassID
	FROM inserted

	UPDATE Licenses SET Licenses.IsActive = 0
	WHERE Licenses.DriverID = @DriverID AND
	Licenses.LicenseClassID = @LicenseClassID AND
	Licenses.LicenseID != @LicenseID
END




----------------------------------------Countries add script----------------------------------------

INSERT INTO Countries (CountryID, Name) VALUES
    (1, 'Afghanistan'),
    (2, 'Albania'),
    (3, 'Algeria'),
    (4, 'Andorra'),
    (5, 'Angola'),
    (6, 'Antigua and Barbuda'),
    (7, 'Argentina'),
    (8, 'Armenia'),
    (9, 'Australia'),
    (10, 'Austria'),
    (11, 'Azerbaijan'),
    (12, 'Bahamas'),
    (13, 'Bahrain'),
    (14, 'Bangladesh'),
    (15, 'Barbados'),
    (16, 'Belarus'),
    (17, 'Belgium'),
    (18, 'Belize'),
    (19, 'Benin'),
    (20, 'Bhutan'),
    (21, 'Bolivia'),
    (22, 'Bosnia and Herzegovina'),
    (23, 'Botswana'),
    (24, 'Brazil'),
    (25, 'Brunei'),
    (26, 'Bulgaria'),
    (27, 'Burkina Faso'),
    (28, 'Burundi'),
    (29, 'Cabo Verde'),
    (30, 'Cambodia'),
    (31, 'Cameroon'),
    (32, 'Canada'),
    (33, 'Central African Republic'),
    (34, 'Chad'),
    (35, 'Chile'),
    (36, 'China'),
    (37, 'Colombia'),
    (38, 'Comoros'),
    (39, 'Congo, Democratic Republic of the'),
    (40, 'Congo, Republic of the'),
    (41, 'Costa Rica'),
    (42, 'Croatia'),
    (43, 'Cuba'),
    (44, 'Cyprus'),
    (45, 'Czech Republic'),
    (46, 'Denmark'),
    (47, 'Djibouti'),
    (48, 'Dominica'),
    (49, 'Dominican Republic'),
    (50, 'Ecuador'),
    (51, 'Egypt'),
    (52, 'El Salvador'),
    (53, 'Equatorial Guinea'),
    (54, 'Eritrea'),
    (55, 'Estonia'),
    (56, 'Eswatini'),
    (57, 'Ethiopia'),
    (58, 'Fiji'),
    (59, 'Finland'),
    (60, 'France'),
    (61, 'Gabon'),
    (62, 'Gambia'),
    (63, 'Georgia'),
    (64, 'Germany'),
    (65, 'Ghana'),
    (66, 'Greece'),
    (67, 'Grenada'),
    (68, 'Guatemala'),
    (69, 'Guinea'),
    (70, 'Guinea-Bissau'),
    (71, 'Guyana'),
    (72, 'Haiti'),
    (73, 'Honduras'),
    (74, 'Hungary'),
    (75, 'Iceland'),
    (76, 'India'),
    (77, 'Indonesia'),
    (78, 'Iran'),
    (79, 'Iraq'),
    (80, 'Ireland'),
    (81, 'Italy'),
    (82, 'Jamaica'),
    (83, 'Japan'),
    (84, 'Jordan'),
    (85, 'Kazakhstan'),
    (86, 'Kenya'),
    (87, 'Kiribati'),
    (88, 'Korea, North'),
    (89, 'Korea, South'),
    (90, 'Kuwait'),
    (91, 'Kyrgyzstan'),
    (92, 'Laos'),
    (93, 'Latvia'),
    (94, 'Lebanon'),
    (95, 'Lesotho'),
    (96, 'Liberia'),
    (97, 'Libya'),
    (98, 'Liechtenstein'),
    (99, 'Lithuania'),
    (100, 'Luxembourg'),
    (101, 'Madagascar'),
    (102, 'Malawi'),
    (103, 'Malaysia'),
    (104, 'Maldives'),
    (105, 'Mali'),
    (106, 'Malta'),
    (107, 'Marshall Islands'),
    (108, 'Mauritania'),
    (109, 'Mauritius'),
    (110, 'Mexico'),
    (111, 'Micronesia'),
    (112, 'Moldova'),
    (113, 'Monaco'),
    (114, 'Mongolia'),
    (115, 'Montenegro'),
    (116, 'Morocco'),
    (117, 'Mozambique'),
    (118, 'Myanmar'),
    (119, 'Namibia'),
    (120, 'Nauru'),
    (121, 'Nepal'),
    (122, 'Netherlands'),
    (123, 'New Zealand'),
    (124, 'Nicaragua'),
    (125, 'Niger'),
    (126, 'Nigeria'),
    (127, 'North Macedonia'),
    (128, 'Norway'),
    (129, 'Oman'),
    (130, 'Pakistan'),
    (131, 'Palau'),
    (132, 'Palestine'),
    (133, 'Panama'),
    (134, 'Papua New Guinea'),
    (135, 'Paraguay'),
    (136, 'Peru'),
    (137, 'Philippines'),
    (138, 'Poland'),
    (139, 'Portugal'),
    (140, 'Qatar'),
    (141, 'Romania'),
    (142, 'Russia'),
    (143, 'Rwanda'),
    (144, 'Saint Kitts and Nevis'),
    (145, 'Saint Lucia'),
    (146, 'Saint Vincent and the Grenadines'),
    (147, 'Samoa'),
    (148, 'San Marino'),
    (149, 'Sao Tome and Principe'),
    (150, 'Saudi Arabia'),
    (151, 'Senegal'),
    (152, 'Serbia'),
    (153, 'Seychelles'),
    (154, 'Sierra Leone'),
    (155, 'Singapore'),
    (156, 'Slovakia'),
    (157, 'Slovenia'),
    (158, 'Solomon Islands'),
    (159, 'Somalia'),
    (160, 'South Africa'),
    (161, 'South Sudan'),
    (162, 'Spain'),
    (163, 'Sri Lanka'),
    (164, 'Sudan'),
    (165, 'Suriname'),
    (166, 'Sweden'),
    (167, 'Switzerland'),
    (168, 'Syria'),
    (169, 'Taiwan'),
    (170, 'Tajikistan'),
    (171, 'Tanzania'),
    (172, 'Thailand'),
    (173, 'Timor-Leste'),
    (174, 'Togo'),
    (175, 'Tonga'),
    (176, 'Trinidad and Tobago'),
    (177, 'Tunisia'),
    (178, 'Turkey'),
    (179, 'Turkmenistan'),
    (180, 'Tuvalu'),
    (181, 'Uganda'),
    (182, 'Ukraine'),
    (183, 'United Arab Emirates'),
    (184, 'United Kingdom'),
    (185, 'United States'),
    (186, 'Uruguay'),
    (187, 'Uzbekistan'),
    (188, 'Vanuatu'),
    (189, 'Vatican City'),
    (190, 'Venezuela'),
    (191, 'Vietnam'),
    (192, 'Yemen'),
    (193, 'Zambia'),
    (194, 'Zimbabwe');








