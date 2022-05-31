SET @currentTime = CURRENT_TIMESTAMP;

/*USERS*/
DELETE FROM Users;
ALTER TABLE Users AUTO_INCREMENT = 1;
INSERT INTO Users
(
    FirstName,
    LastName,
    Username,
    HashedPassword,
    CreatorUserId,
    CreateDate,
    UpdaterUserId,
    UpdateDate
)
VALUES
(
    'System', -- FirstName,
    'System', -- LastName,
    'SYSTEM', -- Username,
    'NotThePassword', -- HashedPassword
    1, -- CreatorUserId,
    @currentTime, -- CreateDate,
    1, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'John', -- FirstName,
    'Doe', -- LastName,
    'John.Doe@mailinator.com', -- Username,
    SHA1('JohnDoe123'), -- HashedPassword
    1, -- CreatorUserId,
    @currentTime, -- CreateDate,
    1, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Jane', -- FirstName,
    'Doe', -- LastName,
    'Jane.Doe@mailinator.com', -- Username,
    SHA1('JaneDoe123'), -- HashedPassword
    1, -- CreatorUserId,
    @currentTime, -- CreateDate,
    1, -- UpdaterUserId,
    @currentTime -- UpdateDate
);
SET @SystemUserId = (SELECT Id FROM Users WHERE Username = 'SYSTEM');

/*CATEGORIES*/
DELETE FROM Categories;
ALTER TABLE Categories AUTO_INCREMENT = 1;
INSERT INTO Categories
(
    `Name`,
    CreatorUserId,
    CreateDate,
    UpdaterUserId,
    UpdateDate
)
VALUES
(
    'Food',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Medicine',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
);

/*LOCATIONS*/
DELETE FROM Locations;
ALTER TABLE Locations AUTO_INCREMENT = 1;
INSERT INTO Locations
(
    `Name`,
    CreatorUserId,
    CreateDate,
    UpdaterUserId,
    UpdateDate
)
VALUES
(
    'Kitchen',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Master Bathroom',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Fridge',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Pantry',
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
);

/*PRODUCTS*/
DELETE FROM Products;
ALTER TABLE Products AUTO_INCREMENT = 1;
INSERT INTO Products
(
    `NAME`,
    ExpirationDate,
    ImageUri,
    CategoryId,
    LocationId,
    CreatorUserId,
    CreateDate,
    UpdaterUserId,
    UpdateDate
)
VALUES
(
    'Apple', -- Name
    '2022-05-17', -- ExpirationDate
    'https://upload.wikimedia.org/wikipedia/commons/a/a6/Pink_lady_and_cross_section.jpg', -- ImageUri
    1, -- CategoryId
    1, -- LocationId
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
),
(
    'Milk', -- Name
    '2022-05-10', -- ExpirationDate
    'https://www.meijer.com/content/dam/meijer/product/0004/12/5010/20/0004125010200_2_A1C1_0600.png', -- ImageUri
    1, -- CategoryId
    3, -- LocationId
    @SystemUserId, -- CreatorUserId,
    @currentTime, -- CreateDate,
    @SystemUserId, -- UpdaterUserId,
    @currentTime -- UpdateDate
);
