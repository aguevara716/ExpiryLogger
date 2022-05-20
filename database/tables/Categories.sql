-- the type of product we're looking at (e.g. food)
CREATE OR REPLACE TABLE Categories
(
    Id INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
    `Name` VARCHAR(200) NOT NULL,
    CONSTRAINT `UX_Category_Name` UNIQUE (`Name`),
    AddBy INT NOT NULL,
    CONSTRAINT `FK_Category_AddBy`
        FOREIGN KEY (AddBy) REFERENCES Users(Id)
        ON DELETE CASCADE
        ON UPDATE RESTRICT,
    AddDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
