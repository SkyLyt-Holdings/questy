IF NOT EXISTS (SELECT * FROM UserTypes WHERE Description LIKE 'User')
BEGIN
	INSERT INTO UserTypes VALUES ('User', 'Slimelord', GETDATE())
END

IF NOT EXISTS (SELECT * FROM UserTypes WHERE Description LIKE 'Admin')
BEGIN
	INSERT INTO UserTypes VALUES ('Admin', 'Slimelord', GETDATE())
END