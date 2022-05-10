-- the type of product we're looking at (e.g. food)
CREATE OR REPLACE TABLE Categories
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Category_Name` UNIQUE (`Name`)
);