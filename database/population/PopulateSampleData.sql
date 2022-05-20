/*USERS*/
DELETE FROM Users;
ALTER TABLE Users AUTO_INCREMENT = 1;
INSERT INTO Users
(
    FirstName,
    LastName,
    Username,
    HashedPassword,
    AddBy
)
VALUES
(
    'System', -- FirstName,
    'System', -- LastName,
    'SYSTEM', -- Username,
    'NotThePassword', -- HashedPassword
    1
),
(
    'John', -- FirstName,
    'Doe', -- LastName,
    'John.Doe@mailinator.com', -- Username,
    SHA1('JohnDoe123'), -- HashedPassword
    1
),
(
    'Jane', -- FirstName,
    'Doe', -- LastName,
    'Jane.Doe@mailinator.com', -- Username,
    SHA1('JaneDoe123'), -- HashedPassword
    1
);
SET @SystemUserId = (SELECT Id FROM Users WHERE Username = 'SYSTEM');
/*CATEGORIES*/
DELETE FROM Categories;
ALTER TABLE Categories AUTO_INCREMENT = 1;
INSERT INTO Categories
(
    `Name`,
    AddBy
)
VALUES
(
    'Food',
    @SystemUserId
),
(
    'Medicine',
    @SystemUserId
);

/*LOCATIONS*/
DELETE FROM Locations;
ALTER TABLE Locations AUTO_INCREMENT = 1;
INSERT INTO Locations
(
    `Name`,
    AddBy
)
VALUES
(
    'Kitchen',
    @SystemUserId
),
(
    'Master Bathroom',
    @SystemUserId
),
(
    'Fridge',
    @SystemUserId
),
(
    'Pantry',
    @SystemUserId
);

/*IMAGES*/
DELETE FROM Images;
ALTER TABLE Images AUTO_INCREMENT = 1;
INSERT INTO Images
(
    `Name`,
	`File`,
	`Url`,
    AddBy
)
VALUES
(
    'Apple', -- Name
	NULL, -- File
	'https://upload.wikimedia.org/wikipedia/commons/a/a6/Pink_lady_and_cross_section.jpg', -- Url
    @SystemUserId -- AddBy
),
(
    'Milk', -- Name
	NULL, -- File
	'https://www.meijer.com/content/dam/meijer/product/0004/12/5010/20/0004125010200_2_A1C1_0600.png', -- Url
    @SystemUserId -- AddBy
);

/*PRODUCTS*/
DELETE FROM Products;
ALTER TABLE Products AUTO_INCREMENT = 1;
INSERT INTO Products
(
    `NAME`,
    ExpirationDate,
    CategoryId,
    ImageId,
    LocationId,
    AddBy
)
VALUES
(
    'Apple', -- Name
    '2022-05-17', -- ExpirationDate
    1, -- CategoryId
    1, -- ImageId
    1, -- LocationId
    @SystemUserId -- AddBy
),
(
    'Milk', -- Name
    '2022-05-10', -- ExpirationDate
    1, -- CategoryId
    2, -- ImageId
    3, -- LocationId
    @SystemUserId -- AddBy
);
