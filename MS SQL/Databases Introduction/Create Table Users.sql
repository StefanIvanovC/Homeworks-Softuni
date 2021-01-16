CREATE TABLE Users
(
   Id BIGINT PRIMARY KEY IDENTITY,
   Username VARCHAR(30) NOT NULL,
   [Password] VARCHAR(30) NOT NULL,
   ProfilePicture VARCHAR(MAX),
   LastLoginTime DATETIME,
   IsDeleted BIT
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Stefan', 'stefancho', 'https://avatars3.githubusercontent.com/u/3106986?s=64&v=4', '7/15/2020', 0),
('Stefana', 'stefanchods', 'https://avatars3.githubusercontent.com/u/3106986?s=64&v=4', '2/15/2020', 0),
('Stefans', 'stefanchsdo', 'https://avatars3.githubusercontent.com/u/3106986?s=64&v=4', '3/15/2020', 0),
('Stefand', 'stefancdsho', 'https://avatars3.githubusercontent.com/u/3106986?s=64&v=4', '5/15/2020', 0),
('Stsefand', 'stefanscdsho', 'https://avatars3.githubusercontent.com/u/3106986?s=64&v=4', '4/15/2020', 0)