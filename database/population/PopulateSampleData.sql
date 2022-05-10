INSERT INTO Categories
(
    `Name`
)
VALUES
(
    'Food'
),
(
    'Medicine'
);

INSERT INTO Locations
(
    `Name`
)
VALUES
(
    'Kitchen'
),
(
    'Master Bathroom'
),
(
    'Fridge'
),
(
    'Pantry'
);

INSERT INTO Products
(
    `Name`,
    ExpirationDate,
    CategoryId,
    ImageId,
    LocationId
)
VALUES
(
    'Apple', -- Name
    '2022-05-17', -- ExpirationDate
    1, -- CategoryId
    null, -- ImageId
    1 -- LocationId
),
(
    'Milk', -- Name
    '2022-05-10', -- ExpirationDate
    1, -- CategoryId
    null, -- ImageId
    3 -- LocationIINSERT INTO Locations
(
    `Name`
)
VALUES
(
    'Kitchen'
),
(
    'Master Bathroom'
),
(
    'Fridge'
),
(
    'Pantry'
);

INSERT INTO Images
(
    `Name`,
	`File`,
	`Url`
)
VALUES
(
    'Apple', -- Name
	NULL, -- File
	'https://upload.wikimedia.org/wikipedia/commons/a/a6/Pink_lady_and_cross_section.jpg' -- Url
),
(
    'Milk', -- Name
	NULL, -- File
	'https://www.meijer.com/content/dam/meijer/product/0004/12/5010/20/0004125010200_2_A1C1_0600.png' -- Url
);

INSERT INTO Products
(
    `NAME`,
    ExpirationDate,
    CategoryId,
    ImageId,
    LocationId
)
VALUES
(
    'Apple', -- Name
    '2022-05-17', -- ExpirationDate
    1, -- CategoryId
    1, -- ImageId
    1 -- LocationId
),
(
    'Milk', -- Name
    '2022-05-10', -- ExpirationDate
    1, -- CategoryId
    2, -- ImageId
    3 -- LocationId
);d
);